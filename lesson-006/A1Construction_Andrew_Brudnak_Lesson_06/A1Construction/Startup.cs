using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A1Construction.Startup))]
namespace A1Construction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
