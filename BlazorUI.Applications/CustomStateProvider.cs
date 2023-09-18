using System.Security.Claims;
using BlazorAppUI.Contracts.Identity;
using Casino.Applications;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorUI.Applications
{
    public class CustomStateProvider : AuthenticationStateProvider
    {
        private readonly SecurityService _authenticationService;
        private CurrentUser _currentUser;

        public CustomStateProvider(SecurityService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                _currentUser =await GetCurrentUser();
                if (_currentUser.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }
                        .Concat(_currentUser.Claims.Select(c => new Claim(c.Type, c.Value)));

                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser =await _authenticationService.GetCurrentUser();
            return _currentUser;
        }
    }
}