using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LizardmanCinemas.Startup))]
namespace LizardmanCinemas
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
