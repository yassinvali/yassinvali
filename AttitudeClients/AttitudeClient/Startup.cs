﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttitudeClient.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace AttitudeClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
