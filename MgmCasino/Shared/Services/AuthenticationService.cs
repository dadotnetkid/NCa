using RestSharp;

namespace MgmCasino.Shared.Services;

public class AuthenticationService
{
    public AuthenticationService()
    {

    }

    public async Task Login()
    {

        var client = new RestClient("https://newus.nasa79.com/");
        var request = new RestRequest("login", Method.Post);
        request.AddBody(new
        {
            name = "untt1",
            password = "aa1234"
        });
        var result = await client.ExecuteAsync(request);
        request = new RestRequest("/", Method.Get);
        foreach (var item in result.Cookies.ToList())
        {
            request.AddCookie(item.Name, item.Value, item.Path, item.Domain);
        }
        result=await client.ExecuteAsync(request);

        /*
        var request = new RestRequest();
        request.AddCookie("dragon_session", "eyJpdiI6InZwVVlxeHBudlRsREhUQWNVckRoeEE9PSIsInZhbHVlIjoicDVhT00veUlnZjhUd0xyK3VGM3VRdVloZDd3QUVjYkNvbytWUGZpclhzLzVLM1JYZUEreld4c0hFMkpYaWRqNDFKQ0JQTjR6ekkrUFN5WFdUYlE4VFlEcCtxR1N1TkpkM0NMUGZManUrZEd0cXVFUGJ0cVJRVW03cWN0NDVrTm8iLCJtYWMiOiJmY2Y2OGY1NWQ2MmVlOWYxYjQ1MDBhZjZiOGE1YTFiMDlmODg5ZjUyOWVjYjI1ZWVkYTg4MGRmNjVjYTNmNDFlIn0%3D", "/", "newus.nasa79.com");

        var response = client.Execute(request, Method.Get);
        Console.WriteLine(response.Content);
        */ /*        var client = new RestClient("http://mgm.sav779.com/Page_inc/getsltMoney.asp");
        
        var request = new RestRequest();
        request.AddHeader("Host", "mgm.sav779.com");
        request.AddHeader("Origin", "http://mgm.sav779.com");
        request.AddHeader("Referer", "http://mgm.sav779.com/main.asp");
        request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
        request.AddCookie("ASPSESSIONIDQADBQCDD", "PJHHNEFDKDIFICHEFAICJIJI", "/", "mgm.sav779.com");
        request.AddCookie("jpui", "mgm%2Esav779%2Ecommgmtestmgm%2Esav779%2Ecom", "/", "mgm.sav779.com");

        var response = client.Execute(request, Method.Get);
        Console.WriteLine(response.Content);*/
    }
}