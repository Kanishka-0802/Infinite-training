<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectricBill.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <style>
        h2 {
            color: black;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .label {
            display: inline-block;
            margin-right: 10px;
            font-weight: bold;
        }
        .textbox {
            padding: 6px;
            width: 200px;
            margin-right: 10px;
        }
        .button {
            padding: 6px 12px;
            background-color: green;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
        .button:hover {
            background-color: grey;
        }
        .error {
            color: red;
            margin-top: 10px;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:50px;">
            <h2>Admin Login</h2>

            <div class="form-group">
                <asp:Label ID="lblUser" runat="server" Text="Username:" CssClass="label" />
                <asp:TextBox ID="txtUser" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblPass" runat="server" Text="Password:" CssClass="label" />
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="textbox" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClick="btnLogin_Click" />
            <br /><br />

            <asp:Label ID="lblMsg" runat="server" CssClass="error" />
        </div>
    </form>
</body>
</html>
