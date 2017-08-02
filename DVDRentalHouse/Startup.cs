using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDRentalHouse.Startup))]
namespace DVDRentalHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
