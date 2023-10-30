<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersCount.aspx.cs" Inherits="MADA.DatePercent.BB.Storage.WS.Dashboard.UsersCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DatePercent - Users Count</title>
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
            <strong><span style="font-size: 14pt">Users Count</span></strong>
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
        <asp:SqlDataSource ID="SqlDataSourceUserCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select count(*) as 'Users Count' from T_USER"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceTodaysNewUsersCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select count(*) as 'Today''s new Users Count' from T_USER where USR_ADDED_TIMEDATE > CAST( CONVERT( CHAR(8), GetDate(), 112) AS DATETIME)">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceLogonUsersCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select count(*) as 'Logon Users Count' from T_USER_LOGON"></asp:SqlDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceUserCount"
            GridLines="Vertical" Height="20px">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Users Count" HeaderText="Users Count" ReadOnly="True"
                    SortExpression="Users Count" />
            </Fields>
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:DetailsView>
        <hr />
        <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceLogonUsersCount"
            GridLines="Vertical" Height="20px">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Logon Users Count" HeaderText="Logon Users Count" ReadOnly="True"
                    SortExpression="Logon Users Count" />
            </Fields>
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:DetailsView>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"
            DataSourceID="SqlDataSourceLogonUsers" GridLines="Vertical" Width="100%">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="USL_USER_ID" HeaderText="ID" SortExpression="USL_USER_ID" />
                <asp:HyperLinkField DataNavigateUrlFields="Profile" DataTextField="Profile" HeaderText="Profile" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Pic" HeaderText="Pic" SortExpression="Pic" />
                <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                <asp:BoundField DataField="Profile" HeaderText="Profile" SortExpression="Profile" />
                <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceLogonUsers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT T_USER_LOGON.USL_USER_ID, T_USER.USR_FB_FIRST_NAME + ' ' + T_USER.USR_FB_LAST_NAME AS Name, T_USER_LOGON.USL_AGE AS Age, T_USER.USR_FB_PICX_URL AS Pic, T_USER.USR_FB_BIRTHDAY_DATE AS Birthday, T_USER.USR_FB_PROFILE_URL AS Profile, T_SEX_TYPE_ENUM.SEX_DESCRIPTION AS Sex FROM T_USER_LOGON INNER JOIN T_USER ON T_USER_LOGON.USL_USER_ID = T_USER.USR_ID INNER JOIN T_SEX_TYPE_ENUM ON T_USER.USR_SEX_CODE = T_SEX_TYPE_ENUM.SEX_CODE">
        </asp:SqlDataSource>
        <hr />
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceTodaysNewUsersCount"
            GridLines="Vertical" Height="20px">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Today's new Users Count" HeaderText="Today's new Users Count"
                    ReadOnly="True" SortExpression="Today's new Users Count" />
            </Fields>
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:DetailsView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="USR_ID"
            DataSourceID="SqlDataSourceTodaysNewUsers" GridLines="Vertical" Width="100%">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="USR_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="USR_ID" />
                <asp:BoundField DataField="USR_FB_FIRST_NAME" HeaderText="First Name" SortExpression="USR_FB_FIRST_NAME" />
                <asp:BoundField DataField="USR_FB_LAST_NAME" HeaderText="Last Name" SortExpression="USR_FB_LAST_NAME" />
                <asp:ImageField DataImageUrlField="USR_FB_PICX_URL" HeaderText="Pic">
                </asp:ImageField>
                <asp:BoundField DataField="USR_FB_BIRTHDAY_DATE" HeaderText="Birthday"
                    SortExpression="USR_FB_BIRTHDAY_DATE" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceTodaysNewUsers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="SELECT T_USER.USR_ID, T_USER.USR_FB_FIRST_NAME, T_USER.USR_FB_LAST_NAME, T_USER.USR_FB_PICX_URL, T_USER.USR_FB_BIRTHDAY_DATE, T_USER.USR_ADDED_TIMEDATE, T_SEX_TYPE_ENUM.SEX_DESCRIPTION AS Expr1 FROM T_USER INNER JOIN T_SEX_TYPE_ENUM ON T_USER.USR_SEX_CODE = T_SEX_TYPE_ENUM.SEX_CODE where USR_ADDED_TIMEDATE > CAST( CONVERT( CHAR(8), GetDate(), 112) AS DATETIME) ORDER BY T_USER.USR_ID DESC">
        </asp:SqlDataSource>
        <hr />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceNewUsersCount"
            GridLines="Vertical" Width="100%" AllowPaging="True" PageSize="31">
            <PagerSettings Position="TopAndBottom" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                <asp:BoundField DataField="Count" HeaderText="Count" ReadOnly="True" SortExpression="Count" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceNewUsersCount" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProd %>"
            SelectCommand="select convert(char(8), USR_ADDED_TIMEDATE, 112) as Date, count(*) AS Count from T_USER group by convert(char(8), USR_ADDED_TIMEDATE, 112) order by Date desc&#13;&#10;">
        </asp:SqlDataSource>
        <hr />
    </form>
</body>
</html>
