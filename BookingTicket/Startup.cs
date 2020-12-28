using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingTicket.Startup))]
namespace BookingTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
