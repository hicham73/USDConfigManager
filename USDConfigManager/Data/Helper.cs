using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDManager.Model;

namespace USDManager.Data
{
    class Helper
    {

        public static Configuration GetConfigurationByName(string name, OrganizationServiceProxy proxy)
        {
            var config = new Configuration();

            var fetchXml = string.Format("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true' >" +
                                    "  <entity name='msdyusd_configuration' >" +
                                    "    <attribute name='msdyusd_configurationid' />" +
                                    "    <filter type='and' >" +
                                    "       <condition attribute='msdyusd_name' operator='eq' value='{0}'/>" +
                                    "     </filter>" +
                                    "  </entity>" +
                                    "</fetch>", name);

            var result = proxy.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;

            if (result.Count > 0)
            {
                config.Id = result[0].Id;
                config.Name = result[0].GetAttributeValue<string>("msdyusd_name");
            }

            return config;
        }
    }
}
