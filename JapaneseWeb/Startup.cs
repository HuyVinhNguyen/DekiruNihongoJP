using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JapaneseWeb.Startup))]
namespace JapaneseWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
