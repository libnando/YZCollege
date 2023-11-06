using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using YZCollege.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace YZCollege.Test.Integration.Common
{
    public class WebAppFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<SqlContext>(options =>
                {
                    options.UseInMemoryDatabase($"InMemoryDbTest");
                });
            });

            builder.UseEnvironment("Testing");
        }
    }
}
