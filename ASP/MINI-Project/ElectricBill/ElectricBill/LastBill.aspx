<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LastBill.aspx.cs" Inherits="ElectricBill.LastBill" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Last Bills</title>
</head>
       <style>
       
        h2 {
            color: darkgreen;
        }
        .textbox {
            padding: 5px;
            width: 150px;
        }
        .button {
            padding: 5px 10px;
            background-color: darkgreen;
            color: white;
            border: none;
            cursor: pointer;
        }
        .button:hover {
            background-color: gray;
        }
        .error {
            color: red;
        }
        .grid {
            margin-top: 15px;
            border-collapse: collapse;
            width: 100%;
        }
        .grid th, .grid td {
            border: 1px solid #ccc;
            padding: 6px;
            text-align: left;
        }
        .grid th {
            background-color: darkgreen;
            color: white;
        }
        .summary {
            margin-top: 15px;
            padding: 8px;
            background-color: #eef;
            border-radius: 4px;
        }
    </style>
   

<body>
    <form id="form1" runat="server">
        <div style="margin:40px;">
            <h2>Last Bills</h2>

            <asp:Label runat="server" Text="Enter N (number of bills to view):" />
            <asp:TextBox ID="txtN" runat="server" />
            <asp:Button ID="btnGet" runat="server" Text="Get Bills" CssClass="button" OnClick="btnGet_Click" />
            <br /><br />

            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
            <br /><br />

          
            <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
                    <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
                    <asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
                    <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" DataFormatString="{0:F2}" />
                </Columns>
            </asp:GridView>

            <h3>Summary</h3>
            
            <asp:Repeater ID="repSummary" runat="server">
                <ItemTemplate>
                    EB Bill for <%# Eval("ConsumerName") %> is <%# Eval("BillAmount", "{0:F2}") %><br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
