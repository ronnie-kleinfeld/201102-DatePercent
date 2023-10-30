<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Loader.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Flex.Loader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DatePercent</title>
    <meta name="google" value="notranslate">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css" media="screen"> 
			html, body	{ height:100%; }
			body { margin:0; padding:0; overflow:auto; text-align:center; 
			       background-color: #666666; }   
			object:focus { outline:none; }
			#flashContent { display:none; }
        </style>
    <meta property="fb:app_id" content="349821425034185" />

    <script type="text/javascript">var _gaq = _gaq || [];_gaq.push(['_setAccount', 'UA-2915423-3']);_gaq.push(['_trackPageview']);(function() {var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);})();</script>

    <script type="text/javascript" src="../Script/swfobject.js"></script>

    <script type="text/javascript">
        function DoOnLoad()
        {
            DoLoadAnimation();
        }    
        function DoLoadAnimation()
        {
            var swfVersionStr = "10.0.0";
            var xiSwfUrlStr = "playerProductInstall.swf";
            var flashvars = {};
            var params = {};
            params.quality = "high";
            params.loop = "false";
            params.bgcolor = "#666666";
            params.allowscriptaccess = "always";
            params.allowfullscreen = "true";
            var attributes = {};
            attributes.id = "Animation";
            attributes.align = "middle";
            swfobject.embedSWF(
                "http://<%= m_strIISServer %>/Flex/<%= m_strAnimationApp %>.swf",
                "divAnimation", 
                "100%", "100%", 
                swfVersionStr, xiSwfUrlStr, 
                flashvars, params, attributes,
                swfobjectAnimationCallBack);
		    swfobject.createCSS("#flashContent", "display:block;text-align:left;");

            document.getElementById("divAnimation").style.height = "600px";
            document.getElementById("divPlatform").style.height = "100%";
        }
        function swfobjectAnimationCallBack(e)
        {
			DoLoadPlatformApp();
		}
        function DoLoadPlatformApp()
        {
            var swfVersionStr = "10.0.0";
            var xiSwfUrlStr = "playerProductInstall.swf";
            var flashvars = {};
            flashvars.SID = "<%= m_strSID %>";
            flashvars.IISServer = "<%= m_strIISServer %>";
            flashvars.BLServer = "<%= m_strBLServer %>";
            flashvars.Token = "<%= m_strToken %>";
            flashvars.Locale = "<%= m_strLocale %>";
            var params = {};
            params.quality = "high";
            params.loop = "false";
            params.bgcolor = "#ffffff";
            params.allowscriptaccess = "always";
            params.allowfullscreen = "true";
            var attributes = {};
            attributes.id = "PlatformApp";
            attributes.align = "middle";
            swfobject.embedSWF(
                "http://<%= m_strIISServer %>/Flex/PlatformApp.swf",
                "divPlatform", 
                "100%", "0", 
                swfVersionStr, xiSwfUrlStr, 
                flashvars, params, attributes);
		    swfobject.createCSS("#flashContent", "display:block;text-align:left;");
        }
        function DoShowPlatformApp()
        {
            var objects = document.getElementsByTagName('object');
            objects[0].height = "1";
            objects[1].height = "100%";
            
            //var element = objects[0];
            //element.parentNode.removeChild(element);
        }
    </script>

</head>
<body style="width: 100%; height: 100%; margin: 0; padding: 0; overflow-y: hidden;
    background-color: #666666" onload="DoOnLoad();">
    <div id="divAnimation" style="width: 100%; height: 100%; top: 0px; margin: 0; padding: 0;">
        <noscript>
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%"
                id="oAnimation">
                <param name="movie" value="http://<%= m_strIISServer %>/Flex/<%= m_strAnimationApp %>.swf" />
                <param name="quality" value="high" />
                <param name="bgcolor" value="#ffffff" />
                <param name="allowScriptAccess" value="sameDomain" />
                <param name="allowFullScreen" value="true" />
                <!--[if !IE]>-->
                <object type="application/x-shockwave-flash" data="http://<%= m_strIISServer %>/Flex/<%= m_strAnimationApp %>.swf"
                    width="100%" height="100%">
                    <param name="quality" value="high" />
                    <param name="bgcolor" value="#ffffff" />
                    <param name="allowScriptAccess" value="sameDomain" />
                    <param name="allowFullScreen" value="true" />
                    <!--<![endif]-->
                    <!--[if gte IE 6]>-->
                    <p>
                        Either scripts and active content are not permitted to run or Adobe Flash Player
                        version 10.0.0 or greater is not installed.
                    </p>
                    <!--<![endif]-->
                    <a href="http://www.adobe.com/go/getflashplayer">
                        <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                            alt="Get Adobe Flash Player" />
                    </a>
                    <!--[if !IE]>-->
                </object>
                <!--<![endif]-->
            </object>
        </noscript>
    </div>
    <div id="divPlatform" style="width: 100%; height: 100%; top: 0px; margin: 0; padding: 0;">
        <noscript>
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%"
                id="Object1">
                <param name="movie" value="http://<%= m_strIISServer %>/Flex/PlatformApp.swf" />
                <param name="quality" value="high" />
                <param name="bgcolor" value="#ffffff" />
                <param name="allowScriptAccess" value="sameDomain" />
                <param name="allowFullScreen" value="true" />
                <!--[if !IE]>-->
                <object type="application/x-shockwave-flash" data="http://<%= m_strIISServer %>/Flex/PlatformApp.swf"
                    width="100%" height="100%">
                    <param name="quality" value="high" />
                    <param name="bgcolor" value="#ffffff" />
                    <param name="allowScriptAccess" value="sameDomain" />
                    <param name="allowFullScreen" value="true" />
                    <!--<![endif]-->
                    <!--[if gte IE 6]>-->
                    <p>
                        Either scripts and active content are not permitted to run or Adobe Flash Player
                        version 10.0.0 or greater is not installed.
                    </p>
                    <!--<![endif]-->
                    <a href="http://www.adobe.com/go/getflashplayer">
                        <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                            alt="Get Adobe Flash Player" />
                    </a>
                    <!--[if !IE]>-->
                </object>
                <!--<![endif]-->
            </object>
        </noscript>
    </div>
</body>
</html>
