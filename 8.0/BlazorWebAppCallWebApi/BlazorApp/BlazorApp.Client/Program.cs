using BlazorApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Create a preconfigured HttpClient with base address for the Movie (web) API
builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002") });

// Create a preconfigured named HttpClient with base address for named client component example
builder.Services.AddHttpClient("WebAPI",
    client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002"));

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
