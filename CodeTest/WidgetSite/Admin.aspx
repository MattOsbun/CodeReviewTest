<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Widget Name: "></asp:Label>
        <asp:TextBox ID="txtWidgetName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDescription" runat="server" Text="Widget Description: "></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Widget" />
    
    </div>
    </form>
</body>
</html>
