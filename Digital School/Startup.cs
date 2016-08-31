using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Digital_School.Startup))]
namespace Digital_School
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
