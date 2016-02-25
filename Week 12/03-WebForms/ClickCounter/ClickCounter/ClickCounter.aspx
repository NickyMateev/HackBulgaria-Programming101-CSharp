<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClickCounter.aspx.cs" Inherits="ClickCounter.ClickCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="welcomeLabel" runat="server">Welcome, <%: Session["username"] %></asp:Label>
        </div>
        <div>
            <asp:Button ID="clickButton" runat="server" Text="Click" OnClick="clickButton_Click" />
        </div>
        <div>
            <asp:Label ID="userClickLabel" runat="server">User clicks: <%: Application[(string)Session["username"]] %></asp:Label>
        </div>
        <div>
            <asp:Label ID="globalClickLabel" runat="server" Text="Label">Global clicks: <%: Application["globalClicks"]%></asp:Label>
        </div>
        <div>
        <table style="width: 100%;">
        <%
            Response.Write("<tr>");
            Response.Write("<td>Name:</td>");
            Response.Write("<td>Clicks</td>");
            Response.Write("</tr>");

            foreach (string user in Application.AllKeys)
            {
                if(user != "globalClicks")
                {
                    Response.Write("<tr>");
                    Response.Write($"<td>{user}</td>");
                    Response.Write($"<td>{Application[user]}</td>");
                    Response.Write("</tr>");
                }
            }
            %>
        </table>
        </div>
    </form>
</body>
</html>
