using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USDManager.Connection
{
    class ConnectionManager
    {
        static CRMConnection _leftConn;
        static CRMConnection _rightConn;


        public static CRMConnection LeftConn
        {
            get
            {
                return _leftConn;
            }
            set
            {
                _leftConn = value;
            }
        }
        public static CRMConnection RightConn
        {
            get
            {
                return _rightConn;
            }
            set
            {
                _rightConn = value;
            }
        }

        public static Dictionary<string, OrganizationServiceProxy> Proxies { get; set; } = new Dictionary<string, OrganizationServiceProxy>();

        public static void LoadConfiguration(TreeView tv)
        {

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

                servers[node.Hostname].Add(node);


            }

            foreach (var hostname in servers.Keys)
            {
                var serverNode = new TreeNode(hostname);
                tv.Nodes.Add(serverNode);

                var connections = servers[hostname];
                foreach (var conn in connections)
                {
                    serverNode.Nodes.Add(conn);
                }
            }

        }

        public static void ToggleConnectionState(CRMConnection node)
        {

            if (node.Proxy == null)
            {
                var helper = new ConnectionHelper
                {
                    DiscoveryServiceAddress = "https://" + node.Hostname + "/XRMServices/2011/Discovery.svc",
                    OrganizationUniqueName = node.Organization,
                    UserName = node.Username,
                    Password = node.Password,
                    Domain = node.Domain
                };

                node.Proxy = helper.GetOrganizationProxy();
            }

            if ((_leftConn != null && _rightConn != null) || (_leftConn == null && _rightConn == null))
            {
                if(_leftConn != null)
                    _leftConn.BackColor = Color.White;
                _leftConn = node;
                _leftConn.BackColor = Color.Pink;

                if(_rightConn != null)
                    _rightConn.BackColor = Color.White;
                _rightConn = null;
            }
            else
            {
                _rightConn = node;
                _rightConn.BackColor = Color.Pink;
            }

        }
    }
}
