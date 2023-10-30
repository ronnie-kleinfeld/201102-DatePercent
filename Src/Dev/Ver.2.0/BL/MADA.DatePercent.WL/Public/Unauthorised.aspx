<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Unauthorised.aspx.cs" Inherits="MADA.DatePercent.WL.Public.Unauthorised" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DatePercent </title>

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-2915423-3']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div dir='ltr'>
                <div style='margin: 8px auto; width: 600px;'>
                    <table border='0' cellspacing='0' cellpadding='0' width='595'>
                        <tbody>
                            <tr>
                                <td style='padding: 10px 8px; background-color: rgb(59, 89, 152);' valign='top' width='100%'>
                                    <a href='<%= MADA.DatePercent.BE.Constants.UIRedirectToAppUrl %>' style='color: rgb(255, 255, 255);
                                        font-family: verdana, arial, sans-serif; font-size: 22px; font-weight: bold;
                                        text-decoration: none' target='_blank'>
                                        <img style='margin: 0px 10px 0px 0px; padding: 0px; border: 0px currentColor; float: left;
                                            width: 36px; height: 36px;' border='0' hspace='2' vspace='2' align='left' width='36px'
                                            height='36px' src='../Res/50x50.png' alt='DatePercent' /></a>
                                    <a href='<%= MADA.DatePercent.BE.Constants.UIRedirectToAppUrl %>' style='color: rgb(255, 255, 255);
                                        font-family: verdana, arial, sans-serif; font-size: 22px; font-weight: bold;
                                        text-decoration: none' target='_blank'>DatePercent - Good Bye</a><br />
                                    <br />
                                    <table border='0' cellspacing='0' cellpadding='0' width='579'>
                                        <tbody>
                                            <tr>
                                                <td style='padding: 0px 12px; color: rgb(0, 0, 0); font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 12px; background-color: rgb(255, 255, 255);' valign='top'>
                                                    <div style='clear: both; float: none;'>
                                                        <br />
                                                        <h2 style='margin: 0px 0px 0px 0px; padding: 0px; color: rgb(59, 89, 152); font-size: 14px;'>
                                                            Goodbye, Thank you for using DatePercent.
                                                        </h2>
                                                        <br clear='all' />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style='padding: 8px 8px 0px; font-family: verdana, arial, sans-serif; font-size: 11px;'
                                                    valign='middle' colspan='3' align='center'>
                                                    <p style='color: rgb(255, 255, 255);'>
                                                        © Copyright 2011 <a href='<%= MADA.DatePercent.BE.Constants.UIRedirectToAppUrl %>' style='color: rgb(255, 255, 255);'
                                                            target='_blank'>DatePercent</a>. All rights reserved.</p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br clear='all' />
            </div>
    </form>
</body>
</html>
