<%@ Page Language="C#" AutoEventWireup="true" Codebehind="IpLatLng.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Dashboard.IpLatLng" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent - IP LatLng</title>
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
            <asp:HyperLink ID="hyperLinkIpLatLng" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Servers.aspx"
                Target="_top">Servers</asp:HyperLink>
            <strong><span style="font-size: 14pt">IP LatLng</span></strong> &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLinkRegisters" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Registers.aspx"
                Target="_top">Registers</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkHostings" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Hostings.aspx"
                Target="_top">Hostings</asp:HyperLink>
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
            CellPadding="3" DataKeyNames="IPL_IP" DataSourceID="sqlDataSourceIpLatLng" GridLines="Vertical"
            Width="100%" AllowSorting="True">
            <PagerSettings Position="TopAndBottom" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="IPL_IP" HeaderText="IP" ReadOnly="True" SortExpression="IPL_IP" />
                <asp:HyperLinkField DataNavigateUrlFields="IPL_LAT,IPL_LNG" DataNavigateUrlFormatString="http://maps.google.com/maps?sll={0},{1}"
                    DataTextField="IPL_LAT" DataTextFormatString="<img src='../Res/Map.png'/>" HeaderText="Location"
                    ItemStyle-HorizontalAlign="Center" Target="_blank" />
                <asp:ImageField DataAlternateTextField="SRT_DESCRIPTION_IIS" DataImageUrlField="SRT_PIC_URL_IIS"
                    ItemStyle-HorizontalAlign="Center" HeaderText="IIS">
                </asp:ImageField>
                <asp:BoundField DataField="SRV_REG_DNS_IIS" HeaderText="DNS" SortExpression="SRV_REG_DNS_IIS" />
                <asp:BoundField DataField="SRV_REG_SUB_DOMAIN_NAME_IIS" HeaderText="Sub Domain" SortExpression="SRV_REG_SUB_DOMAIN_NAME_IIS" />
                <asp:ImageField DataAlternateTextField="SRT_DESCRIPTION_BL" DataImageUrlField="SRT_PIC_URL_BL"
                    ItemStyle-HorizontalAlign="Center" HeaderText="BL">
                </asp:ImageField>
                <asp:BoundField DataField="SRV_REG_DNS_BL" HeaderText="DNS" SortExpression="SRV_REG_DNS_BL" />
                <asp:BoundField DataField="SRV_REG_SUB_DOMAIN_NAME_BL" HeaderText="Sub Domain" SortExpression="SRV_REG_SUB_DOMAIN_NAME_BL" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlDataSourceIpLatLng" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT T_IP_LAT_LNG.IPL_IP, T_IP_LAT_LNG.IPL_LAT, T_IP_LAT_LNG.IPL_LNG, T_SERVER_IIS.SRV_REG_DNS AS SRV_REG_DNS_IIS, T_SERVER_IIS.SRV_REG_SUB_DOMAIN_NAME AS SRV_REG_SUB_DOMAIN_NAME_IIS, T_SERVER_TYPE_ENUM_IIS.SRT_DESCRIPTION AS SRT_DESCRIPTION_IIS, T_SERVER_TYPE_ENUM_IIS.SRT_PIC_URL AS SRT_PIC_URL_IIS, T_SERVER_BL.SRV_REG_DNS AS SRV_REG_DNS_BL, T_SERVER_BL.SRV_REG_SUB_DOMAIN_NAME AS SRV_REG_SUB_DOMAIN_NAME_BL, T_SERVER_TYPE_ENUM_BL.SRT_DESCRIPTION AS SRT_DESCRIPTION_BL, T_SERVER_TYPE_ENUM_BL.SRT_PIC_URL AS SRT_PIC_URL_BL FROM T_IP_LAT_LNG LEFT OUTER JOIN T_SERVER_TYPE_ENUM AS T_SERVER_TYPE_ENUM_BL RIGHT OUTER JOIN T_SERVER AS T_SERVER_BL ON T_SERVER_TYPE_ENUM_BL.SRT_CODE = T_SERVER_BL.SRV_SERVER_TYPE ON T_IP_LAT_LNG.IPL_BL_SERVER_ID = T_SERVER_BL.SRV_ID LEFT OUTER JOIN T_SERVER_TYPE_ENUM AS T_SERVER_TYPE_ENUM_IIS RIGHT OUTER JOIN T_SERVER AS T_SERVER_IIS ON T_SERVER_TYPE_ENUM_IIS.SRT_CODE = T_SERVER_IIS.SRV_SERVER_TYPE ON T_IP_LAT_LNG.IPL_IIS_SERVER_ID = T_SERVER_IIS.SRV_ID">
        </asp:SqlDataSource>
        <hr />
    </form>
</body>
</html>
