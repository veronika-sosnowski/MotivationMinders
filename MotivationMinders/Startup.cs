using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotivationMinders.Startup))]
namespace MotivationMinders
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
