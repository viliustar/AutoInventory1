using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoInventory1
{
    public class Product
    {
        public ProductType Type { get; set; }
        public int SellInDays { get; set; }
        public int Quality { get; set; }

        public Product()
        {
            Type = ProductType.INVALID;
            SellInDays = 0;
            Quality = 0;
        }

        public Product(ProductType prodType, int sellIn, int prodQuality)
        {
            Type = prodType;
            SellInDays = sellIn;
            Quality = prodQuality;
        }

        public void CreateFromCSVLine(string[] csvLine)
        {
            switch (csvLine[0].ToLower().Replace(" ", ""))
            {
                case "agedbrie":
                    Type = ProductType.AgedBrie;
                    break;
                case "christmascrackers":
                    Type = ProductType.ChristmasCrackers;
                    break;
                case "freshitem":
                    Type = ProductType.FreshItem;
                    break;
                case "frozenitem":
                    Type = ProductType.FrozenItem;
                    break;
                case "soap":
                    Type = ProductType.Soap;
                    break;
                default:
                    Type = ProductType.INVALID;
                    break;
            }

            SellInDays = Int32.Parse(csvLine[1]);
            Quality = Int32.Parse(csvLine[2]);
        }

        public void EndDay()
        {
            int reduceQualityBy = 1;
            // Once the sell by date has passed, Quality degrades twice as fast
            if (SellInDays <= 0)
                reduceQualityBy = 2;

            switch (Type)
            {
                case ProductType.FrozenItem:
                    Quality -= reduceQualityBy;
                    break;
                case ProductType.FreshItem:
                    Quality -= reduceQualityBy * 2;
                    break;
                case ProductType.AgedBrie:
                    // Aged Brie increases the older it gets
                    // Rules not clear: requires more info; 1 per turn? indefinitely? even after SellIn date?
                    Quality += 1;
                    break;
                case ProductType.ChristmasCrackers:
                    if (SellInDays > 0)
                    {
                        // Rules not clear: 10 days or less until Christmas or 10 days or less until SellIn date?
                        // Rules not clear: does Quality drop to 0 only after Christas or after SellIn date too?

                        #region NOT USED -- until Christmas
                        /* Misunderstanding: To be used when quality changes depending on the number of days left until Christmas
                        // Current year Christmas day - today
                        double daysToChristmas = (TimeSpan.FromTicks(new DateTime(DateTime.Today.Year, 12, 25).Ticks) - TimeSpan.FromTicks(DateTime.Today.Ticks)).TotalDays;

                        if (daysToChristmas > 10)
                            Quality += 1;
                        else if (daysToChristmas > 5)
                            Quality += 2;
                        else if (daysToChristmas >= 0)
                            Quality += 3;
                        else
                            Quality = 0;    // Drop quality after Christmas
                        */
                        #endregion

                        // Until SellIn date
                        if (SellInDays <= 5)
                            Quality += 3;
                        else if (SellInDays <= 10)
                            Quality += 2;
                        else
                            Quality += 1;

                        // Drop quality after Christmas
                        // TODO: should it stay 0 until next December?
                        if (DateTime.Today.Month == 12 && DateTime.Today.Day > 25)
                            Quality = 0;
                    }
                    else
                    {
                        // According to input/output values, Christmas Crackers reduce in quality at the same speed as frozen items past SellIn date
                        Quality -= reduceQualityBy;
                    }
                    break;
                case ProductType.INVALID:
                    SellInDays = 0;
                    Quality = 0;
                    break;
            }

            // Quality is never more than 50
            if (Quality > 50)
                Quality = 50;

            // Quality is never negative
            if (Quality < 0)
                Quality = 0;

            // Soap/Invalid products do not have SellIn date
            if (Type != ProductType.Soap && Type != ProductType.INVALID)
                SellInDays -= 1;
        }
    }

    public enum ProductType
    {
        AgedBrie,
        ChristmasCrackers,
        FreshItem,
        FrozenItem,
        Soap,
        INVALID
    }
}