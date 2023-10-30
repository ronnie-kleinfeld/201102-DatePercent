<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserCount.aspx.cs" Inherits="MADA.DatePercent.WL.Registration.UserCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent</title>
    <meta http-equiv="REFRESH" content="30">
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<asp:SqlDataSource ID="SqlDataSourceUserCount" runat="server" ConnectionString="<%$ ConnectionStrings:datepercentcomConnectionString %>"
            SelectCommand="select count(*) as 'Users Count' from T_USER"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceTodaysNewUsersCount" runat="server" ConnectionString="<%$ ConnectionStrings:datepercentcomConnectionString %>"
            SelectCommand="select count(*) as 'Today''s new Users Count' from T_USER where USR_ADDED_DATETIME > CAST( CONVERT( CHAR(8), GetDate(), 112) AS DATETIME)">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceLogonUsersCount" runat="server" ConnectionString="<%$ ConnectionStrings:datepercentcomConnectionString %>"
            SelectCommand="select count(*) as 'Logon Users Count' from T_LOGON"></asp:SqlDataSource>
        <hr />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" DataSourceID="SqlDataSourceUserCount" GridLines="Vertical" Height="20px">
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
        </asp:DetailsView><hr />
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
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:DetailsView>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="LGN_USER_ID"
            DataSourceID="SqlDataSourceLogonUsers" GridLines="Vertical" Width="100%">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:ImageField DataImageUrlField="Pic" HeaderText="Pic">
                </asp:ImageField>
                <asp:HyperLinkField DataNavigateUrlFields="Profile" DataTextField="Name" HeaderText="Profile"
                    Target="_parent" />
                <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                <asp:BoundField DataField="Birthday" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Birthday"
                    SortExpression="Birthday" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Requests" HeaderText="Requests" SortExpression="Requests" />
                <asp:BoundField DataField="Messages" HeaderText="Messages" SortExpression="Messages" />
                <asp:BoundField DataField="Notifications" HeaderText="Notifications" SortExpression="Notifications" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceLogonUsers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringInterspace %>"
            SelectCommand="SELECT T_LOGON.LGN_USER_ID, T_USER.USR_NAME AS Name, T_LOGON.LGN_AGE AS Age, T_LOGON.LGN_RMN_REQUEST_COUNT AS Requests, T_LOGON.LGN_RMN_MESSAGE_COUNT AS Messages, T_LOGON.LGN_RMN_NOTIFICATION_COUNT AS Notifications, T_USER.USR_PIC_URL AS Pic, T_USER.USR_PROP_BIRTHDATE AS Birthday, T_USER.USR_PROFILE_URL AS Profile, T_PROP_SEX_TYPE_ENUM.SEX_DESCRIPTION AS Sex FROM T_LOGON INNER JOIN T_USER ON T_LOGON.LGN_USER_ID = T_USER.USR_ID INNER JOIN T_PROP_SEX_TYPE_ENUM ON T_USER.USR_PROP_SEX_CODE = T_PROP_SEX_TYPE_ENUM.SEX_CODE">
        </asp:SqlDataSource><hr />
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
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:DetailsView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="USR_ID"
            DataSourceID="SqlDataSourceTodaysNewUsers" GridLines="Vertical" Width="100%">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="USR_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="USR_ID" />
                <asp:HyperLinkField DataNavigateUrlFields="USR_PROFILE_URL" DataTextField="USR_NAME"
                    HeaderText="Profile" Target="_blank" />
                <asp:ImageField DataImageUrlField="USR_PIC_URL" HeaderText="Pic">
                </asp:ImageField>
                <asp:BoundField DataField="SEX_DESCRIPTION" HeaderText="Sex" SortExpression="SEX_DESCRIPTION" />
                <asp:BoundField DataField="USR_PROP_BIRTHDATE" DataFormatString="{0:dd/MM/yyyy}"
                    HeaderText="Birthday" SortExpression="USR_PROP_BIRTHDATE" />
                <asp:BoundField DataField="USL_ADDRESS" HeaderText="Address" SortExpression="USL_ADDRESS" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceTodaysNewUsers" runat="server" ConnectionString="<%$ ConnectionStrings:datepercentcomConnectionString %>"
            SelectCommand="SELECT T_USER.USR_ID, T_USER.USR_NAME, T_USER.USR_PIC_URL, T_USER.USR_PROP_BIRTHDATE, T_PROP_SEX_TYPE_ENUM.SEX_DESCRIPTION, T_USER.USR_ADDED_DATETIME, T_USER.USR_PROFILE_URL, T_USER_LOCATION.USL_ADDRESS, T_USER_LOCATION.USL_USER_LOCATION_TYPE FROM T_USER INNER JOIN T_USER_LOCATION ON T_USER.USR_ID = T_USER_LOCATION.USL_USER_ID INNER JOIN T_PROP_SEX_TYPE_ENUM ON T_USER.USR_PROP_SEX_CODE = T_PROP_SEX_TYPE_ENUM.SEX_CODE WHERE (T_USER_LOCATION.USL_USER_LOCATION_TYPE = 10) AND (T_USER.USR_ADDED_DATETIME > CAST(CONVERT (CHAR(8), GETDATE(), 112) AS DATETIME)) ORDER BY T_USER.USR_ID DESC">
        </asp:SqlDataSource><hr />
    </form>
</body>
</html>
