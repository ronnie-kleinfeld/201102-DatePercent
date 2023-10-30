﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.5446.
// 
#pragma warning disable 1591

namespace MADA.ContactFetcher.com.stescodes.www {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="stescodescontactgrabberSoap", Namespace="http://tempuri.org/")]
    public partial class stescodescontactgrabber : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GrabContactsOperationCompleted;
        
        private System.Threading.SendOrPostCallback unusedOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public stescodescontactgrabber() {
            this.Url = global::MADA.ContactFetcher.Properties.Settings.Default.MADA_ContactFetcher_com_stescodes_www_stescodescontactgrabber;
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
        public event GrabContactsCompletedEventHandler GrabContactsCompleted;
        
        /// <remarks/>
        public event unusedCompletedEventHandler unusedCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GrabContacts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public contactdetails[] GrabContacts(string servicename, string strUserName, string strPassword, string signature) {
            object[] results = this.Invoke("GrabContacts", new object[] {
                        servicename,
                        strUserName,
                        strPassword,
                        signature});
            return ((contactdetails[])(results[0]));
        }
        
        /// <remarks/>
        public void GrabContactsAsync(string servicename, string strUserName, string strPassword, string signature) {
            this.GrabContactsAsync(servicename, strUserName, strPassword, signature, null);
        }
        
        /// <remarks/>
        public void GrabContactsAsync(string servicename, string strUserName, string strPassword, string signature, object userState) {
            if ((this.GrabContactsOperationCompleted == null)) {
                this.GrabContactsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGrabContactsOperationCompleted);
            }
            this.InvokeAsync("GrabContacts", new object[] {
                        servicename,
                        strUserName,
                        strPassword,
                        signature}, this.GrabContactsOperationCompleted, userState);
        }
        
        private void OnGrabContactsOperationCompleted(object arg) {
            if ((this.GrabContactsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GrabContactsCompleted(this, new GrabContactsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/unused", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public unuseddetails[] unused(string key) {
            object[] results = this.Invoke("unused", new object[] {
                        key});
            return ((unuseddetails[])(results[0]));
        }
        
        /// <remarks/>
        public void unusedAsync(string key) {
            this.unusedAsync(key, null);
        }
        
        /// <remarks/>
        public void unusedAsync(string key, object userState) {
            if ((this.unusedOperationCompleted == null)) {
                this.unusedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnunusedOperationCompleted);
            }
            this.InvokeAsync("unused", new object[] {
                        key}, this.unusedOperationCompleted, userState);
        }
        
        private void OnunusedOperationCompleted(object arg) {
            if ((this.unusedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.unusedCompleted(this, new unusedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class contactdetails {
        
        private string nameField;
        
        private string emailField;
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class unuseddetails {
        
        private string servicenameField;
        
        private string statusField;
        
        /// <remarks/>
        public string servicename {
            get {
                return this.servicenameField;
            }
            set {
                this.servicenameField = value;
            }
        }
        
        /// <remarks/>
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void GrabContactsCompletedEventHandler(object sender, GrabContactsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GrabContactsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GrabContactsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public contactdetails[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((contactdetails[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void unusedCompletedEventHandler(object sender, unusedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class unusedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal unusedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public unuseddetails[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((unuseddetails[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591