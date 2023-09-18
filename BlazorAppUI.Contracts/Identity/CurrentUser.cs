namespace BlazorAppUI.Contracts.Identity;

public class CurrentUser
{
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; }
    public List<UserClaims> Claims { get; set; } = new();
}
public class UserClaims
{
    public UserClaims(string type, string value)
    {
        Type = type;
        Value = value;
    }
    public string Type { get; set; }
    public string Value { get; set; }
}