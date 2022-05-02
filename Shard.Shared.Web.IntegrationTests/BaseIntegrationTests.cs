using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shard.Shared.Web.IntegrationTests
{
    public abstract partial class BaseIntegrationTests<TEntryPoint, TWebApplicationFactory>
        : IClassFixture<TWebApplicationFactory>
        where TEntryPoint : class
        where TWebApplicationFactory: WebApplicationFactory<TEntryPoint>
    {
        private readonly TWebApplicationFactory factory;

        public BaseIntegrationTests(TWebApplicationFactory factory)
        {
            this.factory = factory;
        }
    }
}
