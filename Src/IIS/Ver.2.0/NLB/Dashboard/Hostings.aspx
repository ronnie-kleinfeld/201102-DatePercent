<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Hostings.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Dashboard.Hostings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DatePercent - Hostings</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hyperLinkFacebook" runat="server" NavigateUrl="http://www.facebook.com"
                Target="_blank">FB</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkAds" runat="server" NavigateUrl="http://www.facebook.com/ads/manage/campaigns/?act=68255647"
                Target="_blank">Ads</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkDatePercent" runat="server" NavigateUrl="http://apps.facebook.com/datepercent_vtwo"
                Target="_blank">DatePercent</asp:HyperLink>
            &nbsp; &nbsp;
            <asp:HyperLink ID="hyperLinkDashboard" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Dashboard.aspx"
                Target="_top">Dashboard</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkSessions" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Sessions.aspx"
                Target="_top">Sessions</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkMap" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Map.aspx"
                Target="_top">Map</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkUsersCount" runat="server" NavigateUrl="http://www.datepercent.info/Dashboard/UsersCount.aspx"
                Target="_top">Users Count</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLinkServers" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Servers.aspx"
                Target="_top">Servers</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkIpLatLng" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/IpLatLng.aspx"
                Target="_top">IP LatLng</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLinkRegisters" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Registers.aspx"
                Target="_top">Registers</asp:HyperLink>
            <strong><span style="font-size: 14pt">Hostings</span></strong>
            <asp:HyperLink ID="hyperLinkServerTypes" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/ServerTypes.aspx"
                Target="_top">Server Types</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLinkLog" runat="server" NavigateUrl="http://log.datepercent.com/"
                Target="_top">Log</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkSmtp" runat="server" NavigateUrl="http://smtp.datepercent.com/"
                Target="_top">Smtp</asp:HyperLink>
            <hr />
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" DataKeyNames="HST_ID" DataSourceID="sqlDataSourceHostings" GridLines="Vertical"
            Width="100%" AllowSorting="True">
            <PagerSettings Position="TopAndBottom" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="HST_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="HST_ID" />
                <asp:HyperLinkField DataNavigateUrlFields="HST_WEB_SITE" DataTextField="HST_DESCRIPTION"
                    HeaderText="Hosting" Target="_blank" />
                <asp:HyperLinkField DataTextField="Count" DataTextFormatString="{0:d} Servers" HeaderText="Servers Count"
                    NavigateUrl="http://nlb2.datepercent.com/Dashboard/Servers.aspx" Target="_top" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlDataSourceHostings" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT T_HOSTING.HST_ID, T_HOSTING.HST_DESCRIPTION, T_HOSTING.HST_WEB_SITE, COUNT(T_SERVER.SRV_ID) AS Count FROM T_SERVER INNER JOIN T_HOSTING ON T_SERVER.SRV_HOST_CODE = T_HOSTING.HST_ID GROUP BY T_HOSTING.HST_ID, T_HOSTING.HST_DESCRIPTION, T_HOSTING.HST_WEB_SITE">
        </asp:SqlDataSource>
        <hr />
    </form>
</body>
</html>
