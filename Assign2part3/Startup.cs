using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assign2part3.Startup))]
namespace Assign2part3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
