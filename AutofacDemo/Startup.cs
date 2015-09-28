using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutofacDemo.Startup))]
namespace AutofacDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
