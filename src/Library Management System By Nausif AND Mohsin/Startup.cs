using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library_Management_System_By_Nausif_AND_Mohsin.Startup))]
namespace Library_Management_System_By_Nausif_AND_Mohsin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
