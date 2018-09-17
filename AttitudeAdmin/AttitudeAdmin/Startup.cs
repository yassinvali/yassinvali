using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttitudeAdmin.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace AttitudeAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
