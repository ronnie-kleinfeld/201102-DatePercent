﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace MADA.DatePercent.Worker {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("RMNEMailNotifierDataSet")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class RMNEMailNotifierDataSet : global::System.Data.DataSet {
        
        private T_RMNDataTable tableT_RMN;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public RMNEMailNotifierDataSet() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected RMNEMailNotifierDataSet(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["T_RMN"] != null)) {
                    base.Tables.Add(new T_RMNDataTable(ds.Tables["T_RMN"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public T_RMNDataTable T_RMN {
            get {
                return this.tableT_RMN;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            RMNEMailNotifierDataSet cln = ((RMNEMailNotifierDataSet)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["T_RMN"] != null)) {
                    base.Tables.Add(new T_RMNDataTable(ds.Tables["T_RMN"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableT_RMN = ((T_RMNDataTable)(base.Tables["T_RMN"]));
            if ((initTable == true)) {
                if ((this.tableT_RMN != null)) {
                    this.tableT_RMN.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "RMNEMailNotifierDataSet";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/RMNEMailNotifierDataSet.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableT_RMN = new T_RMNDataTable();
            base.Tables.Add(this.tableT_RMN);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeT_RMN() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            RMNEMailNotifierDataSet ds = new RMNEMailNotifierDataSet();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void T_RMNRowChangeEventHandler(object sender, T_RMNRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class T_RMNDataTable : global::System.Data.DataTable, global::System.Collections.IEnumerable {
            
            private global::System.Data.DataColumn columnRMN_ID;
            
            private global::System.Data.DataColumn columnRMN_RMT_TYPE;
            
            private global::System.Data.DataColumn columnRMN_SENT_DATETIME;
            
            private global::System.Data.DataColumn columnRMN_SENDER_READ;
            
            private global::System.Data.DataColumn columnRMN_SENDER_USER_ID;
            
            private global::System.Data.DataColumn columnRMN_GETTER_USER_ID;
            
            private global::System.Data.DataColumn columnRMN_GETTER_EMAILED;
            
            private global::System.Data.DataColumn columnRMN_GETTER_READ;
            
            private global::System.Data.DataColumn columnRMN_TEXT;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNDataTable() {
                this.TableName = "T_RMN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal T_RMNDataTable(global::System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected T_RMNDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_IDColumn {
                get {
                    return this.columnRMN_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_RMT_TYPEColumn {
                get {
                    return this.columnRMN_RMT_TYPE;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_SENT_DATETIMEColumn {
                get {
                    return this.columnRMN_SENT_DATETIME;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_SENDER_READColumn {
                get {
                    return this.columnRMN_SENDER_READ;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_SENDER_USER_IDColumn {
                get {
                    return this.columnRMN_SENDER_USER_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_GETTER_USER_IDColumn {
                get {
                    return this.columnRMN_GETTER_USER_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_GETTER_EMAILEDColumn {
                get {
                    return this.columnRMN_GETTER_EMAILED;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_GETTER_READColumn {
                get {
                    return this.columnRMN_GETTER_READ;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RMN_TEXTColumn {
                get {
                    return this.columnRMN_TEXT;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNRow this[int index] {
                get {
                    return ((T_RMNRow)(this.Rows[index]));
                }
            }
            
            public event T_RMNRowChangeEventHandler T_RMNRowChanging;
            
            public event T_RMNRowChangeEventHandler T_RMNRowChanged;
            
            public event T_RMNRowChangeEventHandler T_RMNRowDeleting;
            
            public event T_RMNRowChangeEventHandler T_RMNRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddT_RMNRow(T_RMNRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNRow AddT_RMNRow(int RMN_RMT_TYPE, System.DateTime RMN_SENT_DATETIME, bool RMN_SENDER_READ, int RMN_SENDER_USER_ID, int RMN_GETTER_USER_ID, bool RMN_GETTER_EMAILED, bool RMN_GETTER_READ, string RMN_TEXT) {
                T_RMNRow rowT_RMNRow = ((T_RMNRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        null,
                        RMN_RMT_TYPE,
                        RMN_SENT_DATETIME,
                        RMN_SENDER_READ,
                        RMN_SENDER_USER_ID,
                        RMN_GETTER_USER_ID,
                        RMN_GETTER_EMAILED,
                        RMN_GETTER_READ,
                        RMN_TEXT};
                rowT_RMNRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowT_RMNRow);
                return rowT_RMNRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNRow FindByRMN_ID(int RMN_ID) {
                return ((T_RMNRow)(this.Rows.Find(new object[] {
                            RMN_ID})));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual global::System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                T_RMNDataTable cln = ((T_RMNDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new T_RMNDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnRMN_ID = base.Columns["RMN_ID"];
                this.columnRMN_RMT_TYPE = base.Columns["RMN_RMT_TYPE"];
                this.columnRMN_SENT_DATETIME = base.Columns["RMN_SENT_DATETIME"];
                this.columnRMN_SENDER_READ = base.Columns["RMN_SENDER_READ"];
                this.columnRMN_SENDER_USER_ID = base.Columns["RMN_SENDER_USER_ID"];
                this.columnRMN_GETTER_USER_ID = base.Columns["RMN_GETTER_USER_ID"];
                this.columnRMN_GETTER_EMAILED = base.Columns["RMN_GETTER_EMAILED"];
                this.columnRMN_GETTER_READ = base.Columns["RMN_GETTER_READ"];
                this.columnRMN_TEXT = base.Columns["RMN_TEXT"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnRMN_ID = new global::System.Data.DataColumn("RMN_ID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_ID);
                this.columnRMN_RMT_TYPE = new global::System.Data.DataColumn("RMN_RMT_TYPE", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_RMT_TYPE);
                this.columnRMN_SENT_DATETIME = new global::System.Data.DataColumn("RMN_SENT_DATETIME", typeof(global::System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_SENT_DATETIME);
                this.columnRMN_SENDER_READ = new global::System.Data.DataColumn("RMN_SENDER_READ", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_SENDER_READ);
                this.columnRMN_SENDER_USER_ID = new global::System.Data.DataColumn("RMN_SENDER_USER_ID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_SENDER_USER_ID);
                this.columnRMN_GETTER_USER_ID = new global::System.Data.DataColumn("RMN_GETTER_USER_ID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_GETTER_USER_ID);
                this.columnRMN_GETTER_EMAILED = new global::System.Data.DataColumn("RMN_GETTER_EMAILED", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_GETTER_EMAILED);
                this.columnRMN_GETTER_READ = new global::System.Data.DataColumn("RMN_GETTER_READ", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_GETTER_READ);
                this.columnRMN_TEXT = new global::System.Data.DataColumn("RMN_TEXT", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRMN_TEXT);
                this.Constraints.Add(new global::System.Data.UniqueConstraint("Constraint1", new global::System.Data.DataColumn[] {
                                this.columnRMN_ID}, true));
                this.columnRMN_ID.AutoIncrement = true;
                this.columnRMN_ID.AllowDBNull = false;
                this.columnRMN_ID.ReadOnly = true;
                this.columnRMN_ID.Unique = true;
                this.columnRMN_RMT_TYPE.AllowDBNull = false;
                this.columnRMN_SENT_DATETIME.AllowDBNull = false;
                this.columnRMN_SENDER_READ.AllowDBNull = false;
                this.columnRMN_SENDER_USER_ID.AllowDBNull = false;
                this.columnRMN_GETTER_USER_ID.AllowDBNull = false;
                this.columnRMN_GETTER_EMAILED.AllowDBNull = false;
                this.columnRMN_GETTER_READ.AllowDBNull = false;
                this.columnRMN_TEXT.AllowDBNull = false;
                this.columnRMN_TEXT.MaxLength = 2000;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNRow NewT_RMNRow() {
                return ((T_RMNRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new T_RMNRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(T_RMNRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.T_RMNRowChanged != null)) {
                    this.T_RMNRowChanged(this, new T_RMNRowChangeEvent(((T_RMNRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.T_RMNRowChanging != null)) {
                    this.T_RMNRowChanging(this, new T_RMNRowChangeEvent(((T_RMNRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.T_RMNRowDeleted != null)) {
                    this.T_RMNRowDeleted(this, new T_RMNRowChangeEvent(((T_RMNRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.T_RMNRowDeleting != null)) {
                    this.T_RMNRowDeleting(this, new T_RMNRowChangeEvent(((T_RMNRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveT_RMNRow(T_RMNRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                RMNEMailNotifierDataSet ds = new RMNEMailNotifierDataSet();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "T_RMNDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class T_RMNRow : global::System.Data.DataRow {
            
            private T_RMNDataTable tableT_RMN;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal T_RMNRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableT_RMN = ((T_RMNDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int RMN_ID {
                get {
                    return ((int)(this[this.tableT_RMN.RMN_IDColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int RMN_RMT_TYPE {
                get {
                    return ((int)(this[this.tableT_RMN.RMN_RMT_TYPEColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_RMT_TYPEColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime RMN_SENT_DATETIME {
                get {
                    return ((global::System.DateTime)(this[this.tableT_RMN.RMN_SENT_DATETIMEColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_SENT_DATETIMEColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool RMN_SENDER_READ {
                get {
                    return ((bool)(this[this.tableT_RMN.RMN_SENDER_READColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_SENDER_READColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int RMN_SENDER_USER_ID {
                get {
                    return ((int)(this[this.tableT_RMN.RMN_SENDER_USER_IDColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_SENDER_USER_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int RMN_GETTER_USER_ID {
                get {
                    return ((int)(this[this.tableT_RMN.RMN_GETTER_USER_IDColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_GETTER_USER_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool RMN_GETTER_EMAILED {
                get {
                    return ((bool)(this[this.tableT_RMN.RMN_GETTER_EMAILEDColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_GETTER_EMAILEDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool RMN_GETTER_READ {
                get {
                    return ((bool)(this[this.tableT_RMN.RMN_GETTER_READColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_GETTER_READColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string RMN_TEXT {
                get {
                    return ((string)(this[this.tableT_RMN.RMN_TEXTColumn]));
                }
                set {
                    this[this.tableT_RMN.RMN_TEXTColumn] = value;
                }
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class T_RMNRowChangeEvent : global::System.EventArgs {
            
            private T_RMNRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNRowChangeEvent(T_RMNRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public T_RMNRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591