<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Dashboard.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Dashboard.Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent - Dashboard</title>
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
            &nbsp; &nbsp; <strong><span style="font-size: 14pt">Dashboard</span></strong>
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
        <table id="table" width="100%" cellspacing="10">
            <tr>
                <td colspan="3" style="height: 100%" valign="top">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="SRV_ID"
                        DataSourceID="sqlDataSourceServers" GridLines="Vertical" Width="100%" AllowSorting="True">
                        <PagerSettings Position="TopAndBottom" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="SRV_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="SRV_ID" />
                            <asp:ImageField DataAlternateTextField="SRT_DESCRIPTION" DataImageUrlField="SRT_PIC_URL"
                                HeaderText="Type">
                            </asp:ImageField>
                            <asp:HyperLinkField DataNavigateUrlFields="REG_WEB_SITE" DataTextField="REG_DESCRIPTION"
                                HeaderText="Register" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_REG_DNS" DataNavigateUrlFormatString="http://www.{0}"
                                DataTextField="SRV_REG_DNS" DataTextFormatString="www.{0}" HeaderText="DNS" SortExpression="SRV_REG_DNS"
                                Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_REG_SUB_DOMAIN_NAME" DataNavigateUrlFormatString="http://{0}"
                                DataTextField="SRV_REG_SUB_DOMAIN_NAME" DataTextFormatString="{0}" HeaderText="Sub Domain"
                                SortExpression="SRV_REG_SUB_DOMAIN_NAME" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_REG_DNS_CONTROL_PANEL" DataTextField="SRV_REG_DNS_CONTROL_PANEL"
                                HeaderText="CP" DataTextFormatString="CP" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="HST_WEB_SITE" DataTextField="HST_DESCRIPTION"
                                HeaderText="Hosting" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_HOST_CONTROL_PANEL_1" DataTextField="SRV_HOST_CONTROL_PANEL_1"
                                HeaderText="CP1" DataTextFormatString="CP1" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_HOST_CONTROL_PANEL_2" DataTextField="SRV_HOST_CONTROL_PANEL_2"
                                HeaderText="CP2" DataTextFormatString="CP2" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_HOST_APP_POOL_URL" DataTextField="SRV_HOST_APP_POOL_URL"
                                HeaderText="App Pool" DataTextFormatString="AP" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_HOST_PDF" DataTextField="SRV_HOST_PDF"
                                HeaderText="pdf" DataTextFormatString="pdf" Target="_blank" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_HOST_LAT,SRV_HOST_LNG" DataNavigateUrlFormatString="http://maps.google.com/maps?sll={0},{1}"
                                DataTextField="SRV_HOST_LOCATION" HeaderText="Location" Target="_blank" SortExpression="SRV_HOST_LOCATION" />
                            <asp:BoundField DataField="SRV_DB_NAME" HeaderText="Database" SortExpression="SRV_DB_NAME" />
                            <asp:BoundField DataField="SRV_DB_DNS" HeaderText="DNS" SortExpression="SRV_DB_DNS" />
                            <asp:HyperLinkField DataNavigateUrlFields="SRV_DB_CONTROL_PANEL" DataTextField="SRV_DB_CONTROL_PANEL"
                                HeaderText="CP" DataTextFormatString="CP" Target="_blank" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="Gainsboro" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sqlDataSourceServers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
                        SelectCommand="SELECT T_SERVER.SRV_ID, T_SERVER_TYPE_ENUM.SRT_DESCRIPTION, T_SERVER_TYPE_ENUM.SRT_PIC_URL, T_REGISTER.REG_DESCRIPTION, T_REGISTER.REG_WEB_SITE, T_SERVER.SRV_REG_DNS, T_SERVER.SRV_REG_DNS_CONTROL_PANEL, T_SERVER.SRV_REG_SUB_DOMAIN_NAME, T_HOSTING.HST_DESCRIPTION, T_HOSTING.HST_WEB_SITE, T_SERVER.SRV_HOST_CONTROL_PANEL_1, T_SERVER.SRV_HOST_CONTROL_PANEL_2, T_SERVER.SRV_HOST_PDF, T_SERVER.SRV_HOST_LOCATION, T_SERVER.SRV_HOST_LAT, T_SERVER.SRV_HOST_LNG, T_SERVER.SRV_HOST_APP_POOL_URL, T_SERVER.SRV_DB_DNS, T_SERVER.SRV_DB_CONTROL_PANEL, T_SERVER.SRV_DB_NAME FROM T_SERVER INNER JOIN T_REGISTER ON T_SERVER.SRV_REG_CODE = T_REGISTER.REG_ID INNER JOIN T_HOSTING ON T_SERVER.SRV_HOST_CODE = T_HOSTING.HST_ID INNER JOIN T_SERVER_TYPE_ENUM ON T_SERVER.SRV_SERVER_TYPE = T_SERVER_TYPE_ENUM.SRT_CODE ORDER BY SRV_SERVER_TYPE">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 33%" valign="top">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="REG_ID"
                        DataSourceID="sqlDataSourceRegisters" GridLines="Vertical" Width="100%" AllowSorting="True"
                        PageSize="4">
                        <PagerSettings Position="TopAndBottom" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="REG_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="REG_ID" />
                            <asp:HyperLinkField DataNavigateUrlFields="REG_WEB_SITE" DataTextField="REG_DESCRIPTION"
                                HeaderText="Register" Target="_blank" />
                            <asp:HyperLinkField DataTextField="Count" DataTextFormatString="{0:d} Servers" HeaderText="Servers Count"
                                NavigateUrl="http://nlb2.datepercent.com/Dashboard/Servers.aspx" Target="_top" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="Gainsboro" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sqlDataSourceRegisters" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
                        SelectCommand="SELECT T_REGISTER.REG_ID, T_REGISTER.REG_DESCRIPTION, T_REGISTER.REG_WEB_SITE, COUNT(T_SERVER.SRV_ID) AS Count FROM T_REGISTER INNER JOIN T_SERVER ON T_REGISTER.REG_ID = T_SERVER.SRV_REG_CODE GROUP BY T_REGISTER.REG_ID, T_REGISTER.REG_DESCRIPTION, T_REGISTER.REG_WEB_SITE">
                    </asp:SqlDataSource>
                </td>
                <td style="width: 33%" valign="top">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="HST_ID"
                        DataSourceID="sqlDataSourceHostings" GridLines="Vertical" Width="100%" AllowSorting="True"
                        PageSize="4">
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
                </td>
                <td style="width: 33%" valign="top">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="SRT_CODE"
                        DataSourceID="sqlDataSourceServerTypes" GridLines="Vertical" Width="100%" AllowSorting="True"
                        PageSize="4">
                        <PagerSettings Position="TopAndBottom" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="SRT_CODE" HeaderText="Code" ReadOnly="True" SortExpression="SRT_CODE" />
                            <asp:ImageField DataAlternateTextField="SRT_DESCRIPTION" DataImageUrlField="SRT_PIC_URL"
                                NullDisplayText="Server">
                            </asp:ImageField>
                            <asp:BoundField DataField="SRT_DESCRIPTION" HeaderText="Server Type" SortExpression="SRT_DESCRIPTION" />
                            <asp:HyperLinkField DataTextField="Count" DataTextFormatString="{0:d} Servers" HeaderText="Servers Count"
                                NavigateUrl="http://nlb2.datepercent.com/Dashboard/Servers.aspx" Target="_top" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="Gainsboro" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sqlDataSourceServerTypes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
                        SelectCommand="SELECT T_SERVER_TYPE_ENUM.SRT_CODE, T_SERVER_TYPE_ENUM.SRT_DESCRIPTION, T_SERVER_TYPE_ENUM.SRT_PIC_URL, COUNT(T_SERVER.SRV_ID) AS Count FROM T_SERVER RIGHT OUTER JOIN T_SERVER_TYPE_ENUM ON T_SERVER.SRV_SERVER_TYPE = T_SERVER_TYPE_ENUM.SRT_CODE GROUP BY T_SERVER_TYPE_ENUM.SRT_CODE, T_SERVER_TYPE_ENUM.SRT_DESCRIPTION, T_SERVER_TYPE_ENUM.SRT_PIC_URL">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
