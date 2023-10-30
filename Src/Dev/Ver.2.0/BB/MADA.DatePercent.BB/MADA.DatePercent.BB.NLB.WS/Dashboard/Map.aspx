<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Map.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Dashboard.Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent - Map</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hyperLinkFacebook" runat="server" NavigateUrl="http://www.facebook.com"
                Target="_blank">FB</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkAds" runat="server" NavigateUrl="http://www.facebook.com/ads/manage/campaigns/?act=68255647"
                Target="_blank">Ads</asp:HyperLink>
            <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl="http://apps.facebook.com/datepercent_vtwo"
                Target="_blank">DatePercent</asp:HyperLink>
            &nbsp; &nbsp;
            <asp:HyperLink ID="hyperLink2" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Dashboard.aspx"
                Target="_top">Dashboard</asp:HyperLink>
            <asp:HyperLink ID="hyperLink3" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Sessions.aspx"
                Target="_top">Sessions</asp:HyperLink>
            <strong><span style="font-size: 14pt">Map</span></strong>
            <asp:HyperLink ID="hyperLink4" runat="server" NavigateUrl="http://www.datepercent.info/Dashboard/UsersCount.aspx"
                Target="_top">Users Count</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLink5" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Servers.aspx"
                Target="_top">Servers</asp:HyperLink>
            <asp:HyperLink ID="hyperLinkIpLatLng" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/IpLatLng.aspx"
                Target="_top">IP LatLng</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLink6" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Registers.aspx"
                Target="_top">Registers</asp:HyperLink>
            <asp:HyperLink ID="hyperLink7" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/Hostings.aspx"
                Target="_top">Hostings</asp:HyperLink>
            <asp:HyperLink ID="hyperLink8" runat="server" NavigateUrl="http://nlb2.datepercent.com/Dashboard/ServerTypes.aspx"
                Target="_top">Server Types</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hyperLink9" runat="server" NavigateUrl="http://log.datepercent.com/"
                Target="_top">Log</asp:HyperLink>
            <asp:HyperLink ID="hyperLink10" runat="server" NavigateUrl="http://smtp.datepercent.com/"
                Target="_top">Smtp</asp:HyperLink>
            <hr />
        </div>
    </form>
</body>
</html>
