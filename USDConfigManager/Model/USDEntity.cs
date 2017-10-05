using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace USDManager.Model
{
    class USDEntity
    {
        #region "Variables"
        string _logicalName;
        string _idFieldName;
        int _leftCount = 0;
        int _rightCount = 0;
        #endregion

        #region "Properties"
        public Model.Configuration LeftConfiguration { get; set; }
        public Model.Configuration RightConfiguration { get; set; }
        public List<string> KeyFieldNames { get; set; } = new List<string>();
        public string LogicalName {
            get
            {
                return _logicalName;
            }
            set
            {
                _logicalName = value;
                _idFieldName = value + "id";

            }
        }
        public string DisplayName { get; set; }
        public string PrimaryFieldName { get; set; }
        public string IdFieldName { get; set; }

        public List<string> _columns;
        public string LinkEntity { get; set; }
        public string LinkEntityFrom { get; set; }
        public string LinkEntityTo { get; set; }
        public List<string> Columns {
            get { return _columns;  }
            set { _columns = value; }
        }

        private Dictionary<string, RecordPair> _records;
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();
        public List<Data.Relationship> Relationships { get; set; } = new List<Data.Relationship>();
        public int LeftCount { get { return _leftCount; } set { _leftCount = value; } }
        public int RightCount { get { return _rightCount; } set { _rightCount = value; } }
        #endregion

        #region "Constructors"
        public USDEntity()
        {
        }
        #endregion

        #region "Methods"
        internal void GetData(OrganizationServiceProxy leftProxy, OrganizationServiceProxy rightProxy, bool isFirst, TreeNode node)
        {
            _records = new Dictionary<string, RecordPair>();
            string[] ret = { string.Empty , string.Empty };
            StringBuilder fetchAttrs = new StringBuilder();
            StringBuilder orderAttrs = new StringBuilder();

            foreach (var col in _columns)
            {
                fetchAttrs.Append($"<attribute name='{col}' />");
            }
            
            /*foreach (var field in KeyFieldNames)
            {
                orderAttrs.Append($"<order attribute name='{field}' />");
            }*/

            orderAttrs.Append($"<order attribute='{PrimaryFieldName}' />");

            string fetchXml = string.Empty;
            if (LinkEntity != null)
                fetchXml = string.Format("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true' >" +
                                        "  <entity name='{0}' >" +
                                        "    <attribute name='{7}' />" +
                                        "    <attribute name='modifiedon' />" +
                                        "    <attribute name='modifiedby' />" +
                                        "    <attribute name='{1}' /> {2}" +
                                        "    {8}" +
                                        "    <link-entity name='{3}' from='{4}' to='{5}' visible='false' intersect='true' >" +
                                        "        <filter type='and' >" +
                                        "          <condition attribute='msdyusd_configurationid' operator='eq' value='{6}'/>" +
                                        "        </filter>" +
                                        "    </link-entity>" +
                                        "  </entity>" +
                                        "</fetch>", LogicalName, PrimaryFieldName, fetchAttrs.ToString(), LinkEntity, LinkEntityFrom, LinkEntityTo, LeftConfiguration.Id.ToString(), _idFieldName, orderAttrs.ToString());
            else
                fetchXml = string.Format("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true' >" +
                                    "  <entity name='{0}' >" +
                                    "    <attribute name='{3}' />" +
                                    "    <attribute name='{1}' /> {2}" +
                                    "    {4}" +
                                    "  </entity>" +
                                    "</fetch>", LogicalName, PrimaryFieldName, fetchAttrs.ToString(), _idFieldName, orderAttrs.ToString());

            DataCollection<Entity> lEntities = leftProxy.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;

            if (LinkEntity != null)
                fetchXml = string.Format("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true' >" +
                                        "  <entity name='{0}' >" +
                                        "    <attribute name='{7}' />" +
                                        "    <attribute name='modifiedon' />" +
                                        "    <attribute name='modifiedby' />" +
                                        "    <attribute name='{1}' /> {2}" +
                                        "    {8}" +
                                        "    <link-entity name='{3}' from='{4}' to='{5}' visible='false' intersect='true' >" +
                                        "        <filter type='and' >" +
                                        "          <condition attribute='msdyusd_configurationid' operator='eq' value='{6}'/>" +
                                        "        </filter>" +
                                        "    </link-entity>" +
                                        "  </entity>" +
                                        "</fetch>", LogicalName, PrimaryFieldName, fetchAttrs.ToString(), LinkEntity, LinkEntityFrom, LinkEntityTo, RightConfiguration.Id.ToString(), _idFieldName, orderAttrs.ToString());
            else
                fetchXml = string.Format("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true' >" +
                                    "  <entity name='{0}' >" +
                                    "    <attribute name='{3}' />" +
                                    "    <attribute name='{1}' /> {2}" +
                                    "    {4}" +
                                    "  </entity>" +
                                    "</fetch>", LogicalName, PrimaryFieldName, fetchAttrs.ToString(), _idFieldName, orderAttrs.ToString());


            DataCollection<Entity> rEntities = rightProxy.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;
            _leftCount = lEntities.Count;
            _rightCount = rEntities.Count;

            ProcessData(0, lEntities);
            ProcessData(1, rEntities);
            
            var sortedDict = from entry in _records orderby entry.Value.LastModifiedOn descending select entry;

            foreach (var kv in sortedDict)
            {
                var k = kv.Key;
                var v = kv.Value;

                if (v.IsDiff())
                {
                    //if (v.LastModifiedBy != null && v.LastModifiedBy.Name == "Hicham Wahbi")
                    if(v.LRecord.Attributes.Count == 0)
                        v.ForeColor = System.Drawing.Color.Red;
                    else if(v.RRecord.Attributes.Count == 0)
                        v.ForeColor = System.Drawing.Color.Blue;

                    if (v.LRecord.Attributes.Count > 0)
                        v.Text = v.LRecord.Path; 
                    else
                        v.Text = v.RRecord.Path;

                    var diff = DateTime.Now - v.LastModifiedOn.ToLocalTime();

                    if (v.LastModifiedBy != null && v.LastModifiedBy.Name == "Hicham Wahbi")
                        v.NodeFont = new System.Drawing.Font(SystemFonts.DefaultFont, System.Drawing.FontStyle.Bold);
                    //if ( diff.Days <= 1)
                    node.Nodes.Add(v);
                }
            }
        }
        public void ProcessData(int side, DataCollection<Entity> entities)
        {
            Record record;

            foreach (var e in entities)
            {
                var primaryName = e.GetAttributeValue<string>(PrimaryFieldName);
                var path = primaryName;

                if (KeyFieldNames != null)
                {
                    var sb = new StringBuilder();

                    foreach (var fieldName in KeyFieldNames)
                    {
                        var val = e.GetAttributeValue<Object>(fieldName);
                        if(val != null)
                        {
                            switch (val.GetType().Name)
                            {
                                case "OptionSetValue":
                                    sb.Append(((OptionSetValue)val).Value.ToString());
                                    break;
                                case "EntityReference":
                                    sb.Append(((EntityReference)val).Name);
                                    break;
                                default:
                                    sb.Append(val.ToString());
                                    break;

                            }
                            sb.Append(" - ");
                        }
                    }

                    path = $"{sb.ToString()} {primaryName}";
                }

                RecordPair r;
                if (_records.ContainsKey(path))
                    r = _records[path];
                else
                {
                    r = new RecordPair();
                    r.Entity = this;
                    _records[path] = r;
                }

                record = side == 0 ? r.LRecord : r.RRecord;
                record.Id = e.GetAttributeValue<Guid>(_idFieldName);
                record.Entity = this;
                record.Name = primaryName;
                record.Path = path;

                foreach (var attr in e.Attributes)
                {
                    record.Attributes[attr.Key] = new Model.Attribute()
                    {
                        Object = attr.Value,
                    };
                }

                r.LastModifiedOn = e.GetAttributeValue<DateTime>("modifiedon");
                r.LastModifiedBy = e.GetAttributeValue<EntityReference>("modifiedby");

                foreach (var attr in e.FormattedValues)
                {
                    ((Model.Attribute)(record.Attributes[attr.Key])).Name = attr.Value;
                }
            }
        }
        #endregion
    }
}
