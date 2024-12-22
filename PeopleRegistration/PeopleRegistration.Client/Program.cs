using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PeopleRegistration.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var config = builder.Configuration.GetSection("Config").Get<PeopleRegistrationConfiguration>() ?? new();
builder.Services.AddSingleton(config);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(config.PeopleRegistrationApi) });
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
