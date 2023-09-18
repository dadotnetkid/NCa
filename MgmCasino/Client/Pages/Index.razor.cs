using MgmCasino.Shared.Services;

namespace MgmCasino.Client.Pages
{
    public partial class Index
    {
        public async Task Login()
        {
            var service = new AuthenticationService();
            await service.Login();
        }
    }
}
