using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ItiGrades.Startup))]
namespace ItiGrades
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
