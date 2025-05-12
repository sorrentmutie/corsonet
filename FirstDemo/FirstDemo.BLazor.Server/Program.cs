using FirstLibrary.Core.Configurations;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<EsempioOpzioni>(
    builder.Configuration.GetSection("EsempioOpzioni"));

builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddBusinessServices();

builder.Services.AddMemoryCache();

//builder.Services.AddScoped<HttpClient>();

builder.Services.AddHttpClient("NorthWindApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7199");
})
.AddTransientHttpErrorPolicy(b =>
    b.WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(30)
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
