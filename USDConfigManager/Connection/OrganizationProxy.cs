using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDManager.Connection
{
    class OrganizationProxy
    {
        public String DiscoveryServiceAddress { get; set; } = "https://crm2016fe1qa.test.teksavvy.ca/XRMServices/2011/Discovery.svc";
        public String OrganizationUniqueName { get; set; } = "TSI";
        public String UserName { get; set; } = "hwahbi";
        public String Password { get; set; } = "Test123";
        public String Domain { get; set; } = "test";

    }
}
