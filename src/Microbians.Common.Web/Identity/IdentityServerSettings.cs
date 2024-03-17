using System.Collections.Generic;
using Duende.IdentityServer.EntityFramework.Entities;


namespace Microbians.Common.Web.Identity
{
    public record IdentityServerSettings
    {
        public HashSet<ApiScope> ApiScopes { get; set; } = new();
        public HashSet<IdentityResource> IdentityResources { get; set; } = new();
        public HashSet<ApiResource> ApiResources { get; set; } = new();
        public HashSet<Client> Clients { get; set; } = new();
    }
}