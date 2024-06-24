<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblSearch" Text="Widget to search for: "></asp:Label>
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" ID="lblDisplay" Text="Widget searched for: "></asp:Label>
        <asp:Label runat="server" ID="lblSearchTerm"></asp:Label>
        <br />
        Widget:<br />
        <asp:TextBox ID="txtWidgetResults" runat="server" Height="124px" ReadOnly="True" Width="254px"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
