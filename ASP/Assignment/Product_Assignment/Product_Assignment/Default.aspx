<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Product_Assignment.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Selector</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }

        form {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background: #ffffff;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            text-align: center;
            width: 320px;
        }

        h2 {
            margin-bottom: 20px;
            color: black;
        }

        
        #ddl_Product {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        
        #img_Product {
            border: 1px solid #ddd;
            border-radius: 6px;
            margin-bottom: 15px;
        }

        
        #btnGetPrice {
            background-color: green;
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
            display:block;
            margin:0 auto;
        }

        #btnGetPrice:hover {
            background-color: dimgrey;
        }

       
        #lblPrice {
            display: block;
            margin-top: 12px;
            font-size: 15px;
            color: #444;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Select Your Product</h2>

            <asp:DropDownList ID="ddl_Product" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="ddl_Product_SelectedIndexChanged">
                <asp:ListItem Text="Kurthas" Value="Kurthas"></asp:ListItem>
                <asp:ListItem Text="Jeans" Value="Jeans"></asp:ListItem>
                <asp:ListItem Text="Sarees" Value="Sarees"></asp:ListItem>
                <asp:ListItem Text="T-Shirts" Value="TShirts"></asp:ListItem>
                <asp:ListItem Text="Shoes" Value="Shoes"></asp:ListItem>
                <asp:ListItem Text="Watches" Value="Watches"></asp:ListItem>
                <asp:ListItem Text="Bags" Value="Bags"></asp:ListItem>
                <asp:ListItem Text="Jackets" Value="Jackets"></asp:ListItem>
            </asp:DropDownList>

            <asp:Image ID="img_Product" runat="server" Width="200px" Height="200px" />

            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />

            <asp:Label ID="lblPrice" runat="server" Font-Bold="true"></asp:Label>
        </div>
    </form>
</body>
</html>
