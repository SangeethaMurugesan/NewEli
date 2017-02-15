using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorAppo.Startup))]
namespace DoctorAppo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
