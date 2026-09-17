using GizmoApp;
using GizmoApp.Components;
using static GizmoApp.OpinionCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

// Create opinions
    var opinions = new[]
    {
        new Opinion(Happy, "Head scratches approved"),
        new Opinion(Grumpy, "Do not pet the tail"),
        new Opinion(Curious, "He thinks you smell funny"),
        new Opinion(Happy, "Treats are welcome"),
        new Opinion(Grumpy, "Stinky girl cats need to go away")
    };

app.MapGet("/api/opinions/random", () =>
{
    return Results.Ok(opinions[Random.Shared.Next(opinions.Length)]);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
