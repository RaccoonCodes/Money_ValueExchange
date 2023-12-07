<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Page.aspx.cs" Inherits="Money_ValueExchange.Website.Main_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Money Exchange</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <link href="../Styles/site.css"  rel="stylesheet"/>
    <link href ="../Content/bootstrap.min.css" rel ="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.7.0.min.js"></script>

</head>

<body class ="mainPage">
    <form id="form1" runat="server">
        <div class ="center">
            <h1>Money Exchange</h1>
            <p>Updated:12/7/2023</p>
        </div>
        <div class = "pad">
            <asp:Label ID="MoneyIN1" runat="server" Text="I want to exchange"></asp:Label>
            <asp:TextBox ID="InputCashID" runat="server"></asp:TextBox>
            <asp:DropDownList ID="CurrencyID" runat="server"></asp:DropDownList>
            <asp:Label ID="MoneyIN2" runat="server" Text="to"></asp:Label>
            <asp:DropDownList ID="Currency2ID" runat="server"></asp:DropDownList>
            <asp:Button runat="server" Text="Enter" CssClass="btn btn-primary" ID="BtnEnterID" OnClick="BtnEnterID_Click"></asp:Button>
            <asp:RegularExpressionValidator ID="Reg_Expr_Input" runat="server" ErrorMessage="Please input valid value" ValidationExpression="^\d*(\.\d+)?$" ControlToValidate="InputCashID" ForeColor="Red"></asp:RegularExpressionValidator>
            <p>&nbsp</p>
            <asp:Label ID="ResultsID" runat="server" Text=""></asp:Label>
            <p>&nbsp</p>
            <asp:Label ID="MathWork" runat="server" Text=""></asp:Label>


        </div>
    </form>
</body>
</html>
