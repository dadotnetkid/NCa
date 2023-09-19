using System.Security.Claims;
using BlazorAppUI.Contracts.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using RestSharp;

namespace Casino.Applications;

public class SecurityService
{
    private readonly HttpContext _httpContext;

    public SecurityService(IHttpContextAccessor contextAccessor)
    {
        _httpContext=contextAccessor.HttpContext;
    }

    public async Task Login(string userName, string password)
    {
        var client = new RestClient("https://newus.nasa79.com");

        var request = new RestRequest("/login", Method.Post);

        request.AddBody(new
        {
            name = userName,
            password = password
        });

        var result = await client.ExecuteAsync(request);

        if (result.IsSuccessStatusCode)
        {
            var res = JsonConvert.DeserializeAnonymousType(result.Content, new { error = 0, message = string.Empty });
            if (res.error == 0)
            {

                var claims = new ClaimsPrincipal();
                var identity = new List<Claim>()
                {
                    new(ClaimTypes.Name, userName),
                };

                foreach (var c in result.Cookies.ToList())
                {
                    identity.Add(new Claim(c.Name, c.Value));
                    _httpContext.Response.Cookies.Append(c.Name,c.Value);
                }

                claims.AddIdentity(new ClaimsIdentity(identity, CookieAuthenticationDefaults.AuthenticationScheme));

                await _httpContext.SignInAsync(claims);
            }
        }



    }

    public async Task<CurrentUser> GetCurrentUser()
    {
        var user = _httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
        return new CurrentUser()
        {
            UserName = user
        };
    }
}