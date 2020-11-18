using Hcm.Skill.Api;
using Hcm.Skill.Domain.Interfaces.Communicators;
using Hcm.Skill.Domain.Models;
using Hcm.Skill.Domain.Services;
using Hcm.Skill.Infra.Communication.Communicators;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Hcm.Skill.Api
{
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot Configuration { get; set; }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            Configuration = builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "local.credentials.json"))
                .AddEnvironmentVariables()
                .Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IAuthenticationCommunicator, AuthenticationCommunicator>();
            builder.Services.AddScoped<IPontoMobileCommunicator, PontoMobileCommunicator>();
            builder.Services.AddScoped<IService, Service>();
            builder.Services.AddSingleton(BindCredentialsSettings());
        }

        private CredentialsModel BindCredentialsSettings()
        {
            var credentialsModel = new CredentialsModel();

            var credentials = Configuration?.GetSection("credentials");
            credentials?.Bind(credentialsModel);

            return credentialsModel;
        }
    }
}
