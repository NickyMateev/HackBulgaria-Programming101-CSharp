<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClickCounter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label" runat="server" Text="Enter your name:"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="152px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Invalid input!" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    </div>
    </form>
</body>
</html>
