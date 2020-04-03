<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AutoInventory1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <p>We are a small convenience store with a prime location in a prominent city ran by a friendly shopkeeper named Alison.
        We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date.
        We currently update our inventory manually.</p>
    <p>Your task is to write a program to automate the inventory management based on the following rules:</p>
    <p>Rules:</p>
    <ul>
        <li>All items have a SellIn value which denotes the number of days we have to sell the item</li>
        <li>All items have a Quality value which denotes how valuable the item is</li>
        <li>At the end of each day our system lowers both values for every item</li>
        <li>Once the sell by date has passed, Quality degrades twice as fast</li>
        <li>The Quality of an item is never negative</li>
        <li>The Quality of an item is never more than 50</li>
        <li>"Aged Brie" actually increases in Quality the older it gets</li>
        <li>“Frozen Item” decreases in Quality by 1</li>
        <li>"Soap" never has to be sold or decreases in Quality</li>
        <li>"Christmas Crackers", like “Aged Brie”, increases in Quality as its SellIn value approaches;<br />Its quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but quality drops to 0 after Christmas</li>
        <li>"Fresh Item" degrade in Quality twice as fast as “Frozen Item”</li>
    </ul>

    <p>Input: A list of items in the current inventory. Each line in the input represents an inventory item with Item name, its sell-in value and quality
        e.g. “Christmas Crackers -1 2” => Christmas Crackers are past sellin value by 1 day with quality 2.</p>
    <p>Output: Updated inventory after adjusting the quality and sellin days for each item after 1 day.</p>

    <table style="border: 1px solid #000000; padding: 10px;">
        <thead>
            <tr>
                <td>Test Input :</td>
                <td>Expected Output :</td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Aged Brie 1 1</td>
                <td>Aged Brie 0 2</td>
            </tr>
            <tr>
                <td>Christmas Crackers -1 2</td>
                <td>Christmas Crackers -2 0</td>
            </tr>
            <tr>
                <td>Christmas Crackers 9 2</td>
                <td>Christmas Crackers 8 4</td>
            </tr>
            <tr>
                <td>Soap 2 2</td>
                <td>Soap 2 2</td>
            </tr>
            <tr>
                <td>Frozen Item -1 55</td>
                <td>Frozen Item -2 50</td>
            </tr>
            <tr>
                <td>Frozen Item 2 2</td>
                <td>Frozen Item 1 1</td>
            </tr>
            <tr>
                <td>INVALID ITEM 2 2</td>
                <td>NO SUCH ITEM</td>
            </tr>
            <tr>
                <td>Fresh Item 2 2</td>
                <td>Fresh Item 1 0</td>
            </tr>
            <tr>
                <td>Fresh Item -1 5</td>
                <td>Fresh Item -2 1</td>
            </tr>
        </tbody>
    </table>

    <div style="clear: both;"></div>

</asp:Content>
