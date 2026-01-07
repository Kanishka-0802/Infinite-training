<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Validation_Assignment.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Form</title>
</head>
    <style>
    .btn-green {
        background-color: green;
        color: white;
        border: none;
        border-radius: 20px;
        padding: 10px 20px;
        font-size: 16px;
        cursor: pointer;
    }

    .btn-green:hover {
        background-color: darkgreen;
    }
    h1{
        color:green;
    }
</style>

<body>
    <form id="form1" runat="server">
        <div>
            <h1> Insert Your Details:</h1><br /><br />

            
            First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="TextBox1" ErrorMessage=" *Name cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />

            
            Family Name:&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="TextBox2" ErrorMessage="*Family name required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server"
                ControlToValidate="TextBox2" ControlToCompare="TextBox1"
                Operator="NotEqual" ErrorMessage="*Family Name must differ from First Name"
                ForeColor="Blue"></asp:CompareValidator>
            <br /><br />

            
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="TextBox3" ErrorMessage="*Address required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegexAddress" runat="server"
                ControlToValidate="TextBox3" ValidationExpression="^.{2,}$"
                ErrorMessage="At least 2 characters" ForeColor="Blue"></asp:RegularExpressionValidator>
            <br /><br />

            
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="TextBox4" ErrorMessage="*City required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegexCity" runat="server"
                ControlToValidate="TextBox4" ValidationExpression="^.{2,}$"
                ErrorMessage="At least 2 characters" ForeColor="Blue"></asp:RegularExpressionValidator>
            <br /><br />

            
            Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="TextBox5" ErrorMessage="*Zip Code required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegexZip" runat="server"
                ControlToValidate="TextBox5" ValidationExpression="^\d{5}$"
                ErrorMessage="Zip must be 5 digits" ForeColor="Blue"></asp:RegularExpressionValidator>
            <br /><br />

            
            Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                ControlToValidate="TextBox6" ErrorMessage="*Phone required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegexPhone" runat="server"
                ControlToValidate="TextBox6" ValidationExpression="^\d{2,3}-\d{7}$"
                ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX" ForeColor="Blue"></asp:RegularExpressionValidator>
            <br /><br />

            
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                ControlToValidate="TextBox7" ErrorMessage="*Email required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegexEmail" runat="server"
                ControlToValidate="TextBox7"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="example@example.com" ForeColor="Blue"></asp:RegularExpressionValidator>
            <br /><br />

            
            <asp:Button ID="Button1" runat="server" Text="Check" OnClick="Button1_Click" CssClass="btn-green"  />
            <br /><br />

            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                ForeColor="Red" HeaderText="Validation Summary" ShowMessageBox="True" />
        </div>
    </form>
</body>
</html>
