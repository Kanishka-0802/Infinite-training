<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="ElectricBill.Billing" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Electricity Bill</title>
    <style>
       
        h2 {
            color: darkgreen;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .label {
            display: inline-block;
            width: 150px;
            font-weight: bold;
        }
        .textbox {
            padding: 6px;
            width: 200px;
        }
        .button {
            padding: 6px 12px;
            background-color: darkgreen;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
        .button:hover {
            background-color: gray;
        }
        .error {
            color: red;
            margin-top: 10px;
            display: block;
        }
        .container {
            margin: 40px auto;
            max-width: 500px;
            background: #fff;
            padding: 20px 30px;
            border-radius: 6px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add Electricity Bill</h2>

            <div class="form-group">
                <asp:Label runat="server" Text="Consumer Number:" CssClass="label" />
                <asp:TextBox ID="txtConsumerNumber" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Consumer Name:" CssClass="label" />
                <asp:TextBox ID="txtConsumerName" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Units Consumed:" CssClass="label" />
                <asp:TextBox ID="txtUnits" runat="server" CssClass="textbox" />
            </div>

            <asp:Button ID="btnAdd" runat="server" Text="Add Bill" CssClass="button" OnClick="btnAdd_Click" />
            <br /><br />

            <asp:Label ID="lblStatus" runat="server" CssClass="error" />
        </div>
    </form>
</body>
</html>
