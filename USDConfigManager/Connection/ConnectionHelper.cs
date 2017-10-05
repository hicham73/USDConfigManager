using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Reflection;

// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly
// located in the SDK\bin folder of the SDK download.
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Crm.Sdk.Messages;

namespace USDManager
{
    /// <summary>
    /// Demonstrate how to do basic authentication using IServiceManagement and SecurityTokenResponse.
    /// </summary>
    class ConnectionHelper
    {
        #region Class Level Members
        public String DiscoveryServiceAddress { get; set; }  = "https://crm2016fe1qa.test.teksavvy.ca/XRMServices/2011/Discovery.svc";
        public String OrganizationUniqueName { get; set; } = "TSI";
        public String UserName { get; set; } = "hwahbi";
        public String Password { get; set; } = "Test123";
        public String Domain { get; set; } = "test";

        #endregion Class Level Members

        #region How To Sample Code
        /// <summary>
        /// 
        /// </summary>
        public OrganizationServiceProxy GetOrganizationProxy()
        {
            IServiceManagement<IDiscoveryService> serviceManagement = ServiceConfigurationFactory.CreateManagement<IDiscoveryService>(new Uri(DiscoveryServiceAddress));
            AuthenticationProviderType endpointType = serviceManagement.AuthenticationType;
            AuthenticationCredentials authCredentials = GetCredentials(serviceManagement, endpointType);


            String organizationUri = String.Empty;
            // Get the discovery service proxy.
            using (DiscoveryServiceProxy discoveryProxy =  GetProxy<IDiscoveryService, DiscoveryServiceProxy>(serviceManagement, authCredentials))
            {
                // Obtain organization information from the Discovery service. 
                if (discoveryProxy != null)
                {
                    // Obtain information about the organizations that the system user belongs to.
                    OrganizationDetailCollection orgs = DiscoverOrganizations(discoveryProxy);
                    // Obtains the Web address (Uri) of the target organization.
                    organizationUri = FindOrganization(OrganizationUniqueName,orgs.ToArray()).Endpoints[EndpointType.OrganizationService];

                }
            }


            IServiceManagement<IOrganizationService> orgServiceManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(organizationUri));

            // Set the credentials.
            AuthenticationCredentials credentials = GetCredentials(orgServiceManagement, endpointType);

            // Get the organization service proxy.
            return GetProxy<IOrganizationService, OrganizationServiceProxy>(orgServiceManagement, credentials);

        }

        /// <summary>
        /// Obtain the AuthenticationCredentials based on AuthenticationProviderType.
        /// </summary>
        /// <param name="service">A service management object.</param>
        /// <param name="endpointType">An AuthenticationProviderType of the CRM environment.</param>
        /// <returns>Get filled credentials.</returns>
        private AuthenticationCredentials GetCredentials<TService>(IServiceManagement<TService> service, AuthenticationProviderType endpointType)
        {
            AuthenticationCredentials authCredentials = new AuthenticationCredentials();

            switch (endpointType)
            {
                case AuthenticationProviderType.ActiveDirectory:
                    authCredentials.ClientCredentials.Windows.ClientCredential =
                        new System.Net.NetworkCredential(UserName,
                            Password,
                            Domain);
                    break;
                default: // For Federated and OnlineFederated environments.                    
                    authCredentials.ClientCredentials.UserName.UserName = UserName;
                    authCredentials.ClientCredentials.UserName.Password = Password;
                    

                    break;
            }

            return authCredentials;
        }

        /// <summary>
        /// Discovers the organizations that the calling user belongs to.
        /// </summary>
        /// <param name="service">A Discovery service proxy instance.</param>
        /// <returns>Array containing detailed information on each organization that 
        /// the user belongs to.</returns>
        public OrganizationDetailCollection DiscoverOrganizations(
            IDiscoveryService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            RetrieveOrganizationsRequest orgRequest = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse orgResponse =
                (RetrieveOrganizationsResponse)service.Execute(orgRequest);

            return orgResponse.Details;
        }

        /// <summary>
        /// Finds a specific organization detail in the array of organization details
        /// returned from the Discovery service.
        /// </summary>
        /// <param name="orgUniqueName">The unique name of the organization to find.</param>
        /// <param name="orgDetails">Array of organization detail object returned from the discovery service.</param>
        /// <returns>Organization details or null if the organization was not found.</returns>
        /// <seealso cref="DiscoveryOrganizations"/>
        public OrganizationDetail FindOrganization(string orgUniqueName,
            OrganizationDetail[] orgDetails)
        {
            if (String.IsNullOrWhiteSpace(orgUniqueName))
                throw new ArgumentNullException("orgUniqueName");
            if (orgDetails == null)
                throw new ArgumentNullException("orgDetails");
            OrganizationDetail orgDetail = null;

            foreach (OrganizationDetail detail in orgDetails)
            {
                if (String.Compare(detail.UniqueName, orgUniqueName,
                    StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    orgDetail = detail;
                    break;
                }
            }
            return orgDetail;
        }

        private TProxy GetProxy<TService, TProxy>(
            IServiceManagement<TService> serviceManagement,
            AuthenticationCredentials authCredentials)
            where TService : class
            where TProxy : ServiceProxy<TService>
        {
            Type classType = typeof(TProxy);

            if (serviceManagement.AuthenticationType !=
                AuthenticationProviderType.ActiveDirectory)
            {
                AuthenticationCredentials tokenCredentials =
                    serviceManagement.Authenticate(authCredentials);
                // Obtain discovery/organization service proxy for Federated, LiveId and OnlineFederated environments. 
                // Instantiate a new class of type using the 2 parameter constructor of type IServiceManagement and SecurityTokenResponse.
                return (TProxy)classType
                    .GetConstructor(new Type[] { typeof(IServiceManagement<TService>), typeof(SecurityTokenResponse) })
                    .Invoke(new object[] { serviceManagement, tokenCredentials.SecurityTokenResponse });
            }

            // Obtain discovery/organization service proxy for ActiveDirectory environment.
            // Instantiate a new class of type using the 2 parameter constructor of type IServiceManagement and ClientCredentials.
            return (TProxy)classType
                .GetConstructor(new Type[] { typeof(IServiceManagement<TService>), typeof(ClientCredentials) })
                .Invoke(new object[] { serviceManagement, authCredentials.ClientCredentials });
        }

        #endregion How To Sample Code
    }
}