using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationsOfCompanies.Startup))]
namespace RegistrationsOfCompanies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
