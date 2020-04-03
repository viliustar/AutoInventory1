using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

namespace AutoInventory1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Check if file has been uploaded
            if (Upload.HasFile)
            {
                // Create a list of products
                List<Product> products = new List<Product>();

                // Go through each line of CSV file
                using (TextFieldParser parser = new TextFieldParser(Upload.PostedFile.InputStream))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        // Read one row
                        string[] fields = parser.ReadFields();

                        // Create product object and fill in data from CSV row
                        Product product = new Product();
                        product.CreateFromCSVLine(fields);

                        // Add product to the list
                        products.Add(product);
                    }
                }

                // Use the list of products to 
                CurrentInventory.DataSource = products;
                CurrentInventory.DataBind();

                Cache["CurrentInv"] = products;

                // Apply the end of day rules to all the products
                foreach (Product product in products)
                {
                    product.EndDay();
                }

                // Display updated inventory
                EndDayInventory.DataSource = products;
                EndDayInventory.DataBind();

                Cache["EndDayInv"] = products;

                Inventories.Visible = true;
            }
        }

        protected void EndDayButton_Click(object sender, EventArgs e)
        {
            // Get end of day inventory
            List<Product> products = (List<Product>)Cache["EndDayInv"];

            // Display as current inventory
            CurrentInventory.DataSource = products;
            CurrentInventory.DataBind();

            Cache["CurrentInv"] = products;

            // Apply the end of day rules to all the products
            foreach (Product product in products)
            {
                product.EndDay();
            }

            // Display updated inventory
            EndDayInventory.DataSource = products;
            EndDayInventory.DataBind();

            Cache["EndDayInv"] = products;
        }
    }
}