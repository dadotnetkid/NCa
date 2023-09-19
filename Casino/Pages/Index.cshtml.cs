using System.Net;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace Casino.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpContext _httpContext;
        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _httpContext=accessor.HttpContext;
        }

        public async Task OnGetAsync()
        {

            var client = new RestClient("https://newus.nasa79.com");
            var request = new RestRequest("/", Method.Get);
            var cookieValue = _httpContext.User.Claims.FirstOrDefault(c => c.Type == "dragon_session").Value.ToString();
            request.AddHeader("Cookie", $"dragon_session={cookieValue}");

            var result = await client.ExecuteAsync(request);

            var doc = new HtmlDocument();
            doc.LoadHtml(result.Content);
            //cs-casino-slot casino action
            innerHtml     = doc.DocumentNode
                     .Descendants(0).FirstOrDefault(n => n.HasClass("cs-casino-slot")).InnerHtml;

        }

        public string innerHtml { get; set; }
    }
}