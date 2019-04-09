using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternetApplicationProject.Startup))]
namespace InternetApplicationProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
