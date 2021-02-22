using Microsoft.Owin;
using Owin;
using University_Manager_v2.Helpers;

[assembly: OwinStartupAttribute(typeof(University_Manager_v2.Startup))]
namespace University_Manager_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeederDatabase.SeedDate();
        }
    }
}
