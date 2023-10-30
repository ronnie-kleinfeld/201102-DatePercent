<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Login.aspx.cs" Inherits="MADA.DatePercent.WL.Registration.Login.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent </title>
    <meta property="fb:app_id" content="224260514289069" />

    <script type="text/javascript">var _gaq = _gaq || [];_gaq.push(['_setAccount', 'UA-2915423-3']);_gaq.push(['_trackPageview']);(function() {var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);})();</script>

    <script type="text/javascript" src="../../Script/swfobject.js"></script>

    <script type="text/javascript">
        function DoLoad3DWallFX()
        {
            var flashvars = {};
            var params = {};
            params.scale = "noscale";
            params.salign = "tl";
            var attributes = {};
            swfobject.embedSWF("3DWallFX.swf", "div3DWallFX", "100%", "100%", "9.0.0", false, flashvars, params, attributes, swfobject3DWallFXCallBack);
        }
        function swfobject3DWallFXCallBack(e)
        {
			DoLoadDummyApp();
		}
        
        function DoLoadDummyApp()
        {
            swfobject.embedSWF("<%= m_strRootFlexUrl %>DummyApp.swf", "divDummy", "0", "0", "10.0.0", false);
        }
		
		function DoSignUp()
		{
            var flashvars = {};
            var params = {};
            params.scale = "noscale";
            params.salign = "tl";
            var attributes = {};
            swfobject.embedSWF("<%= m_strRootFlexUrl %>RegistrationApp.swf" + document.location.search, "divRegistration", "100%", "100%", "10.0.0", false, flashvars, params, attributes, swfobjectRegistrationAppCallBack);
		}
		function swfobjectRegistrationAppCallBack(e)
        {
		    document.getElementById("div3DWallFX").style.width = "0px";
		    document.getElementById("div3DWallFX").style.height = "0px";
		    document.getElementById("divRegistration").style.width = "750px";
		    document.getElementById("divRegistration").style.height = "340px";
		    document.getElementById("trBottom").style.visibility = "hidden";
		    document.getElementById("trBottom").style.height = "5px";
		}
    </script>

</head>
<body onload="DoLoad3DWallFX()">
    <form runat="server">
        <center>
            <table border="1" style="width: 752px; border-spacing: 0px; text-align: left; font-family: Georgia;
                color: #3b5998;">
                <tr style="vertical-align: middle;">
                    <td style="width: 100%; background-color: #3b5998; border-left: 0px; border-top: 0px;">
                        <div style="padding-left: 20px; font-size: xx-large; font-weight: bold; color: #b4e3e9;
                            border-style: none">
                            <a href="../../RedirectToApp.htm" style="text-decoration: none; color: #b4e3e9">DatePercent
                                - Looking for love?</a></div>
                    </td>
                    <td align="right" style="border-left: 0px; border-right: 0px; border-top: 0px; background-color: #3b5998;">
                        <img src="../../Res/50x50.png" alt="DatePercent" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; height: 340px; border-left: 0px; border-right: 0px;
                        border-top: 0px; border-bottom: 0px; padding-left: 1px; padding-right: 1px;">
                        <div id="div3DWallFX" style="width: 748px; height: 340px; vertical-align: middle;">
                            <div style="padding-left: 20px; font-size: x-large; font-weight: bold; color: #3b5998;
                                text-align: center;">
                                Loading... Please wait</div>
                            <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                                alt="Get Adobe Flash player" onclick="location.href='http://www.adobe.com/go/getflashplayer'" />
                        </div>
                        <div id="divRegistration" style="width: 0px; height: 0px; visibility: hidden;" />
                        <div id="divDummy" style="width: 0px; height: 0px; visibility: hidden;" />
                    </td>
                </tr>
                <tr id="trBottom" style="width: 100%;">
                    <td colspan="2" style="width: 100%; border-left: 0px; border-right: 0px; border-top: 0px;
                        border-bottom: 0px;">
                        <table border="0" style="width: 752px; border-spacing: 0px; text-align: left; font-family: Georgia;
                            color: #3b5998;">
                            <tr>
                                <td rowspan="2" style="width: 270px; vertical-align: bottom; border: 0px;">
                                    <div style="text-align: center; font-size: larger; font-style: italic; font-weight: bold;">
                                        New to DatePercent?</div>
                                </td>
                                <td colspan="3" style="background-color: #3b5998; border: 0px;">
                                    <div style="text-align: left; font-size: larger; font-style: italic; font-weight: bold;
                                        color: #b4e3e9; padding-left: 10px;">
                                        Login to your account:</div>
                                </td>
                                <td colspan="2" rowspan="4" style="vertical-align: middle; background-color: #3b5998;
                                    border: 0px;">
                                    <div style="padding-top: 20px; text-align: center; font-size: larger; font-style: italic;
                                        font-weight: bold; color: #b4e3e9;">
                                        <asp:LinkButton ID="linkButtonLogIn" Text="Log In>>" OnClick="linkButtonLogIn_Click"
                                            Style="color: #b4e3e9; text-decoration: underline;" runat="server" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #3b5998; border: 0px; width: 209px;">
                                    <div style="text-align: left; font-size: medium; font-style: italic; color: #b4e3e9;
                                        padding-left: 15px;">
                                        EMail:</div>
                                </td>
                                <td style="background-color: #3b5998; border: 0px;">
                                    <div style="text-align: left; font-size: medium; font-style: italic; color: #b4e3e9;">
                                        Password:</div>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="1" style="text-align: center;">
                                    <div style="font-size: medium; font-style: italic;">
                                        <a id="hrefSignUp" href="javascript:DoSignUp()" style="background-color: #68a54c;
                                            color: #ffffff; text-decoration: underline;">&nbsp;Sign Up&nbsp;</a></div>
                                </td>
                                <td style="background-color: #3b5998; border: 0px; width: 209px;">
                                    <div style="text-align: left; font-size: larger; font-style: italic; color: #b4e3e9;
                                        padding-left: 15px;">
                                        <asp:TextBox ID="textBoxEMail" runat="server" Width="200px" /></div>
                                </td>
                                <td style="background-color: #3b5998; border: 0px;">
                                    <div style="text-align: left; font-size: larger; font-style: italic; color: #b4e3e9;">
                                        <asp:TextBox ID="textBoxPassword" TextMode="Password" runat="server" Width="120px" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2" />
                                <td style="background-color: #3b5998; border: 0px; width: 209px;">
                                    <div style="text-align: left; font-size: small; font-style: italic; color: #b4e3e9;
                                        padding-left: 15px;">
                                        <asp:CheckBox ID="checkBoxKeepMeLoggedIn" Text="Keep me logged in" runat="server" /></div>
                                </td>
                                <td style="background-color: #3b5998; border: 0px;">
                                    <div style="text-align: left; font-size: x-small; font-style: italic; color: #b4e3e9;">
                                        <a href="../ForgotPassword.aspx" style="color: #b4e3e9; text-decoration: underline;">
                                            Forgot password</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="background-color: #3b5998; border: 0px;">
                                    <div style="text-align: left; font-size: medium; color: #ff0000; padding-left: 15px;">
                                        <%=m_strMessage %>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <div style="font-size: x-small;">
                <a href="http://www.datepercent.com">Home</a> &nbsp; |&nbsp; <a href="mailto:support@datepercent.com">
                    Contact Us</a> &nbsp; |&nbsp; <a href="http://www.datepercent.com/web/PrivacyPolicy.htm">
                        Privacy Policy</a> &nbsp; |&nbsp; <a href="http://www.datepercent.com/web/TermsOfUse.htm">
                            Terms of Use</a>
            </div>
        </center>
    </form>
</body>
</html>
