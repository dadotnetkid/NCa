using BlazorAppUI;
using Blazored.LocalStorage;
using BlazorUI.Applications;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomStateProvider>()); ;
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
