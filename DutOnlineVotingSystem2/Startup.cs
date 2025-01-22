using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DutOnlineVotingSystem2.Startup))]
namespace DutOnlineVotingSystem2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
