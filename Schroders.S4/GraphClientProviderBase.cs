using Azure.Identity;
using Microsoft.Graph;

namespace Schroders
{
    public class GraphClientProviderBase
    {

        internal GraphServiceClient? CreateServiceContext()
        {
            var clientId = "e7f3b77e-59ac-48fc-82d2-1be8a0851ea0";
            var tenantId = "cc83b6ac-505f-4efc-a552-a2c7bfa6d7e3";
            var clientSecret = "NjG8Q~SlD1toHn7Q~BANakEQ9rYA.kVGJa2sAb41";

            var options = new ClientSecretCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };

            var clientSecretCredential = new ClientSecretCredential(
                tenantId, clientId, clientSecret, options);

            var client = new GraphServiceClient(clientSecretCredential);

            return client;
        }
    }
}