using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USDManager.Connection
{
    class CRMConnection : TreeNode
    {
        public string Hostname { get; set; }
        public string Organization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public bool IsConnected { get; set; } = false;
        public OrganizationServiceProxy Proxy { get; set; }

    }
}