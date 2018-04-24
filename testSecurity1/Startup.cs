using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testSecurity1.Startup))]
namespace testSecurity1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
