<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MADA.DatePercent.SMTP.WS.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SMTP Server</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:Button ID="btnStop" runat="server" OnClick="btnStop_Click" Text="Stop" />
        <asp:Button ID="btnStart" runat="server" OnClick="btnStart_Click" Text="Start" />
        <asp:Button ID="btnDoWork" runat="server" OnClick="btnDoWork_Click" Text="DoWork" />
        &nbsp;
        <asp:Button ID="btnSendTestEMail" runat="server" OnClick="btnSendTestEMail_Click"
            Text="Send Test EMail" />
        &nbsp;
        <asp:HyperLink ID="hyperLinkComposeEMail" runat="server" NavigateUrl="~/ComposeEMail.aspx"
            Target="_blank">Compose EMail</asp:HyperLink><br />
        <hr />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataSourceID="SqlDataSourceT_EMAILCount" ForeColor="#333333" GridLines="None"
            Height="30px" Width="200px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <RowStyle BackColor="#EFF3FB" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Column1" HeaderText="EMails Count" ReadOnly="True" SortExpression="Column1" />
            </Fields>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSourceT_EMAILCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select count(*) from T_EMAIL"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" DataKeyNames="EML_ID" DataSourceID="SqlDataSourceT_EMAIL"
            GridLines="Vertical" Width="100%">
            <PagerSettings Position="TopAndBottom" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="EML_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="EML_ID" />
                <asp:BoundField DataField="EML_SENDER_NAME" HeaderText="Sender Name" SortExpression="EML_SENDER_NAME" />
                <asp:BoundField DataField="EML_GETTER_NAME" HeaderText="Getter Name" SortExpression="EML_GETTER_NAME" />
                <asp:BoundField DataField="EML_GETTER_EMAIL" HeaderText="Getter EMail" SortExpression="EML_GETTER_EMAIL" />
                <asp:BoundField DataField="EML_SUBJECT" HeaderText="Subject" SortExpression="EML_SUBJECT" />
                <asp:BoundField DataField="EML_BODY" HeaderText="Body" SortExpression="EML_BODY" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT * FROM [T_EMAIL]"></asp:SqlDataSource>
        <hr />
    
    </div>
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataSourceID="SqlDataSourceT_EMAIL_UNTISPAMCount" ForeColor="#333333" GridLines="None"
            Height="30px" Width="200px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <RowStyle BackColor="#EFF3FB" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Column1" HeaderText="EMails Antispam Count" ReadOnly="True"
                    SortExpression="Column1" />
            </Fields>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_UNTISPAMCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select count(*) from T_EMAIL_UNTISPAM"></asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" DataKeyNames="EMM_EMAIL" DataSourceID="SqlDataSourceT_EMAIL_UNTISPAM"
            GridLines="Vertical" Width="100%">
            <PagerSettings Position="TopAndBottom" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="EMM_EMAIL" HeaderText="EMail" ReadOnly="True" SortExpression="EMM_EMAIL" />
                <asp:BoundField DataField="EMM_DATE_TIME" HeaderText="DateTime" SortExpression="EMM_DATE_TIME" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_UNTISPAM" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT * FROM [T_EMAIL_UNTISPAM]"></asp:SqlDataSource>
        <hr />
        <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataSourceID="SqlDataSourceT_EMAIL_HISTORYCount" ForeColor="#333333" GridLines="None"
            Height="30px" Width="200px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <RowStyle BackColor="#EFF3FB" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Column1" HeaderText="EMail History Count" ReadOnly="True"
                    SortExpression="Column1" />
            </Fields>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_HISTORYCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select count(*) from T_EMAIL_HISTORY"></asp:SqlDataSource>
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" DataKeyNames="EMH_ID" DataSourceID="SqlDataSourceT_EMAIL_HISTORY"
            GridLines="Vertical" Width="100%">
            <PagerSettings Position="TopAndBottom" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="EMH_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="EMH_ID" />
                <asp:BoundField DataField="EMH_DATETIME" HeaderText="DateTime" SortExpression="EMH_DATETIME" />
                <asp:BoundField DataField="EMH_GETTER_NAME" HeaderText="Getter Name" SortExpression="EMH_GETTER_NAME" />
                <asp:BoundField DataField="EMH_GETTER_EMAIL" HeaderText="Getter EMail" SortExpression="EMH_GETTER_EMAIL" />
                <asp:BoundField DataField="EMH_SUBJECT" HeaderText="Subject" SortExpression="EMH_SUBJECT" />
                <asp:BoundField DataField="EMH_BODY" HeaderText="Body" SortExpression="EMH_BODY" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_HISTORY" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT * FROM [T_EMAIL_HISTORY]"></asp:SqlDataSource>
        <hr />
    </form>
</body>
</html>