<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ComposeEMail.aspx.cs" Inherits="MADA.DatePercent.SMTP.WS.ComposeEMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMTP Server</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; background-color: Teal;">
                <tr>
                    <td style="width: 206px">
                        Sender Name:
                    </td>
                    <td style="width: 100%;">
                        <asp:TextBox ID="textBoxSenderName" runat="server" Width="100%" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 206px">
                        Getter Name:
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxGetterName" runat="server" Width="100%" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 206px">
                        Getter EMail:
                    </td>
                    <td>
                        <textarea id="textAreaGetterEMail" runat="server" rows="5" style="width: 100%" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 206px; height: 22px;">
                        Seperator:
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxSeperator" runat="server" Width="100%">\n</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 206px">
                        Subject:
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxSubject" runat="server" Width="100%" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 206px">
                        Body:
                    </td>
                    <td>
                        <textarea id="textAreaBody" runat="server" rows="5" style="width: 100%" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input id="checkboxDoNotSendDuplicates" runat="server" type="checkbox" checked="checked" />
                        Do not send duplicates in T_EMAIL_HISTORY</td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:HyperLink ID="hyperLinkDefault" runat="server" NavigateUrl="~/Default.aspx" Target="_self">Default</asp:HyperLink>
                        <asp:Button ID="btnCompose" runat="server" OnClick="btnCompose_Click" Text="Compose" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
