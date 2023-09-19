using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace Casino.Pages.Game
{
    public class OpenModel : PageModel
    {
        public string SlotId { get; set; }
        public string Html { get; set; }
        public async Task OnGetAsync(string slotId)
        {
            var client = new RestClient($"https://newus.nasa79.com/game/casino/open/{slotId}?api_token=lwMrMHBQcxU0kqTEmsquU6HcXtS0E5jw65LDjvSDimk7iDG4EsHixH0ApJFQ");
            RestRequest request = new RestRequest();
            var cookieValue = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "dragon_session").Value.ToString();
            request.AddHeader("Cookie", $"dragon_session={cookieValue}");
            var result = await client.ExecuteAsync(request);
            Html = result.Content;
            //https://newus.nasa79.com/game/casino/open/' + slotId + '?api_token=lwMrMHBQcxU0kqTEmsquU6HcXtS0E5jw65LDjvSDimk7iDG4EsHixH0ApJFQ', "game", 'width=1366,height=768,scrollbars=yes
        }
    }
}
