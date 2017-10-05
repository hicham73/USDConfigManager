using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USDManager.Connection;

namespace USDManager.Forms
{
    public partial class FormDuplicateActions : Form
    {
        public FormDuplicateActions()
        {
            InitializeComponent();

            var connStrs = ConfigurationManager.ConnectionStrings;
            var servers = new Dictionary<string, List<CRMConnection>>();

            for (int i = 0; i < connStrs.Count; i++)
            {
                var connStr = connStrs[i];
                var name = connStr.Name;
                var str = connStr.ConnectionString;

                if (name.StartsWith("Local"))
                    continue;

                CRMConnection node = new CRMConnection();
                node.Name = name;
                node.Text = name;

                string[] tokens = str.Split(';');

                foreach (var token in tokens)
                {
                    var subTokens = token.Split('=');
                    var key = subTokens[0];
                    var val = subTokens[1];
                    switch (key.ToLower())
                    {
                        case "hostname":
                            node.Hostname = val;
                            break;
                        case "organization":
                            node.Organization = val;
                            break;
                        case "username":
                            node.Username = val;
                            break;
                        case "password":
                            node.Password = val;
                            break;
                        case "domain":
                            node.Domain = val;
                            break;
                    }

                }

                if (!servers.ContainsKey(node.Hostname))
                    servers[node.Hostname] = new List<CRMConnection>();

                cbConnectionStrings.Items.Add(node);
            }
        }

        private void cbConnectionStrings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnRemoveDuplicates_Click(object sender, EventArgs e)
        {
            /*
            var qaCM = new ConnectionHelper
            {
                DiscoveryServiceAddress = "https://crm.qa.teksavvy.ca/XRMServices/2011/Discovery.svc",
                OrganizationUniqueName = "TSI",
                UserName = "hwahbi",
                Password = "Test123",
                Domain = "qa"
            };

            var proxy = qaCM.GetOrganizationProxy();
            var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical'>" +
                            "  <entity name='uii_action' >" +
                            "    <attribute name='uii_name' />" +
                            "    <attribute name='uii_hostedapplicationid' />" +
                            "  </entity>" +
                            "</fetch> ";
            
            var data = proxy.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;

            Dictionary<string, string> map = new Dictionary<string, string>();
            Dictionary<Guid, string> toBeDeleted = new Dictionary<Guid, string>();

            foreach (var entity in data)
            {
                var id = entity.Id;
                var name = entity.GetAttributeValue<string>("uii_name");
                var app = entity.GetAttributeValue<EntityReference>("uii_hostedapplicationid");

                if (!string.IsNullOrEmpty(name) && app != null)
                {
                    var appName = app.Name;
                    var appId = app.Id;

                    var keyId = app.Id.ToString() + "-" + name;
                    var keyName = app.Name + "-" + name;

                    if (map.ContainsKey(keyId))
                    {
                        toBeDeleted[id] = keyName;
                    }
                    else
                    {
                        map[keyId] = name;
                    }
                }
            }
            */
            /*
            foreach (var id in toBeDeleted.Keys)
            {
                proxy.Delete("uii_action", id);
            }
            */
        }
    }
}
