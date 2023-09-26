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

        }

        public string innerHtml { get; set; }
    }
}