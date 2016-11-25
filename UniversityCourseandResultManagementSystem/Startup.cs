using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityCourseandResultManagementSystem.Startup))]
namespace UniversityCourseandResultManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
