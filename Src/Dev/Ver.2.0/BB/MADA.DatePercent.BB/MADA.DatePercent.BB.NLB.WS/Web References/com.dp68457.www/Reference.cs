﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5448
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.5448.
// 
#pragma warning disable 1591

namespace MADA.DatePercent.BB.NLB.WS.com.dp68457.www {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SmtpWSSoap", Namespace="http://tempuri.org/")]
    public partial class SmtpWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ComposeOperationCompleted;
        
        private System.Threading.SendOrPostCallback PingOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SmtpWS() {
            this.Url = global::MADA.DatePercent.BB.NLB.WS.Properties.Settings.Default.MADA_DatePercent_BB_NLB_WS_com_dp68457_www_SmtpWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ComposeCompletedEventHandler ComposeCompleted;
        
        /// <remarks/>
        public event PingCompletedEventHandler PingCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Compose", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Compose(string p_strSessionID, string p_strEML_SENDER_NAME, string p_strEML_GETTER_EMAIL, string p_strEML_GETTER_NAME, string p_strEML_SUBJECT, string p_strEML_BODY) {
            object[] results = this.Invoke("Compose", new object[] {
                        p_strSessionID,
                        p_strEML_SENDER_NAME,
                        p_strEML_GETTER_EMAIL,
                        p_strEML_GETTER_NAME,
                        p_strEML_SUBJECT,
                        p_strEML_BODY});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ComposeAsync(string p_strSessionID, string p_strEML_SENDER_NAME, string p_strEML_GETTER_EMAIL, string p_strEML_GETTER_NAME, string p_strEML_SUBJECT, string p_strEML_BODY) {
            this.ComposeAsync(p_strSessionID, p_strEML_SENDER_NAME, p_strEML_GETTER_EMAIL, p_strEML_GETTER_NAME, p_strEML_SUBJECT, p_strEML_BODY, null);
        }
        
        /// <remarks/>
        public void ComposeAsync(string p_strSessionID, string p_strEML_SENDER_NAME, string p_strEML_GETTER_EMAIL, string p_strEML_GETTER_NAME, string p_strEML_SUBJECT, string p_strEML_BODY, object userState) {
            if ((this.ComposeOperationCompleted == null)) {
                this.ComposeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnComposeOperationCompleted);
            }
            this.InvokeAsync("Compose", new object[] {
                        p_strSessionID,
                        p_strEML_SENDER_NAME,
                        p_strEML_GETTER_EMAIL,
                        p_strEML_GETTER_NAME,
                        p_strEML_SUBJECT,
                        p_strEML_BODY}, this.ComposeOperationCompleted, userState);
        }
        
        private void OnComposeOperationCompleted(object arg) {
            if ((this.ComposeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ComposeCompleted(this, new ComposeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Ping", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Ping() {
            object[] results = this.Invoke("Ping", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PingAsync() {
            this.PingAsync(null);
        }
        
        /// <remarks/>
        public void PingAsync(object userState) {
            if ((this.PingOperationCompleted == null)) {
                this.PingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPingOperationCompleted);
            }
            this.InvokeAsync("Ping", new object[0], this.PingOperationCompleted, userState);
        }
        
        private void OnPingOperationCompleted(object arg) {
            if ((this.PingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PingCompleted(this, new PingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void ComposeCompletedEventHandler(object sender, ComposeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ComposeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ComposeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void PingCompletedEventHandler(object sender, PingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591