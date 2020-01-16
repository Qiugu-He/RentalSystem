using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IssueTrackerV1.Startup))]
namespace IssueTrackerV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
