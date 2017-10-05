using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USDManager.Model
{
    class USDRelationship
    {
        string _name = "msdyusd_toolbarbutton_agentscriptaction";

        string _fromEntityName = "msdyusd_toolbarbutton";
        string _fromEntityPrimaryName = "msdyusd_name";

        string _toEntityName = "msdyusd_agentscriptaction";
        string _toEntityPrimaryName = "msdyusd_name";

        Dictionary<string, int> diff = new Dictionary<string, int>();
        
        public string Name { get { return _name; } set { _name = value; } }
        public string FromEntityName { get { return _fromEntityName; } set { _fromEntityName = value; } }
        public string FromEntityPrimaryName { get { return _fromEntityPrimaryName; } set { _fromEntityPrimaryName = value; } }
        public string ToEntityPrimaryName { get { return _toEntityPrimaryName; } set { _toEntityPrimaryName = value; } }
        public string ToEntityName { get { return _toEntityName; } set { _toEntityName = value; } }
        public void GetData(TreeNode node, OrganizationServiceProxy leftProxy, OrganizationServiceProxy rightProxy)
        {
            string fetchXml = string.Format( " <fetch>" +
                                             "   <entity name='{0}'>" +
                                             "     <link-entity name='{1}' from='{1}id' to='{1}id' alias='a'>" +
                                             "         <attribute name='{2}'/>" +
                                             "     </link-entity>" +
                                             "     <link-entity name='{3}' from='{3}id' to='{3}id' alias='b'>" +
                                             "         <attribute name='{4}'/>" +
                                             "     </link-entity>" +
                                             "  </entity>" +
                                             " </fetch>", _name, _fromEntityName, _fromEntityPrimaryName, _toEntityName, _toEntityPrimaryName);

            DataCollection <Entity> lEntities = leftProxy.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;
            var fromPrimaryName = "a." + _fromEntityPrimaryName;
            var toPrimaryName = "b." + _toEntityPrimaryName;
            foreach (var e in lEntities)
            {
                var from = e.GetAttributeValue<AliasedValue>(fromPrimaryName);
                var to = e.GetAttributeValue<AliasedValue>(toPrimaryName);
                var key = from.Value + "-" + to.Value;
                diff[key] = 1;
            }

            DataCollection<Entity> rEntities = rightProxy.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;
            foreach (var e in lEntities)
            {
                var from = e.GetAttributeValue<AliasedValue>(fromPrimaryName);
                var to = e.GetAttributeValue<AliasedValue>(toPrimaryName);

                
                var key = from.Value + "-" + to.Value;
                if (diff.ContainsKey(key))
                    diff[key] = diff[key] + 10;
                else
                    diff[key] = 10;

                if (diff[key] != 11)
                    node.Nodes.Add(key);
            }

        }
    }
}
