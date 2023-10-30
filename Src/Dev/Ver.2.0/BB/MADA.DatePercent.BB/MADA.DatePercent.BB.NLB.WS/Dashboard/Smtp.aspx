<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Smtp.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Dashboard.Smtp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DatePercent - Smtp</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hyperLinkDatePercent" runat="server" NavigateUrl="http://apps.facebook.com/date-percent"
                Target="_blank">DatePercent</asp:HyperLink>
            &nbsp;
            <asp:HyperLink ID="hyperLinkDashboard" runat="server" NavigateUrl="~/Dashboard/Dashboard.aspx"
                Target="_top">Dashboard</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkSessions" runat="server" NavigateUrl="~/Dashboard/Sessions.aspx"
                Target="_top">Sessions</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkMap" runat="server" NavigateUrl="~/Dashboard/Map.aspx"
                Target="_top">Map</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkRegisters" runat="server" NavigateUrl="~/Dashboard/Registers.aspx"
                Target="_top">Registers</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkHostings" runat="server" NavigateUrl="~/Dashboard/Hostings.aspx"
                Target="_top">Hostings</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkServers" runat="server" NavigateUrl="~/Dashboard/Servers.aspx"
                Target="_top">Servers</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkServerTypes" runat="server" NavigateUrl="~/Dashboard/ServerTypes.aspx"
                Target="_top">Server Types</asp:HyperLink>
            &nbsp;
            <asp:HyperLink ID="hyperLinkLog" runat="server" NavigateUrl="http://log.datepercent.com/"
                Target="_top">Log</asp:HyperLink>
            <strong><span style="font-size: 14pt">Smtp</span></strong>
            <asp:HyperLink ID="hyperLinkUsersCount" runat="server" NavigateUrl="~/Dashboard/UsersCount.aspx"
                Target="_top">Users Count</asp:HyperLink>
            <hr />
        </div>
        <asp:HyperLink ID="hyperLinkComposeEMail" runat="server" NavigateUrl="http://www.dp68457.com/ComposeEMail.aspx"
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
        <asp:SqlDataSource ID="SqlDataSourceT_EMAILCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSmtp %>"
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
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSmtp %>"
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
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_UNTISPAMCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSmtp %>"
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
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_UNTISPAM" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSmtp %>"
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
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_HISTORYCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSmtp %>"
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
        <asp:SqlDataSource ID="SqlDataSourceT_EMAIL_HISTORY" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSmtp %>"
            SelectCommand="SELECT * FROM [T_EMAIL_HISTORY]"></asp:SqlDataSource>
        <hr />
    </form>
</body>
</html>
