using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogdOferta.Startup))]
namespace BlogdOferta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
