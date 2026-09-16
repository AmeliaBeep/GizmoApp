using GizmoApp;
using GizmoApp.Components;

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
app.MapGet("/api/opinions/random", () =>
{
    var opinions = new[]
    {
        new Opinion { Category = OpinionCategory.Happy, Text = "Head scracthes approved" },
        new Opinion { Category = OpinionCategory.Grumpy, Text = "Do not pet the tail" },
        new Opinion { Category = OpinionCategory.Curious, Text = "He thinks you smell funny" }
    };

    return Results.Ok(opinions[Random.Shared.Next(opinions.Length)]);
});
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
