// Blazor Server is the new framework used in this project (new to this class).
// It enables interactive web UI components with server-side C# event handling via SignalR.

using ToDoList.App.Components;
using ToDoList.App;
using ToDoList.Core;
using ToDoList.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Register application services
builder.Services.AddSingleton<TodoManager>();
builder.Services.AddSingleton<FileService>(sp =>
    new FileService(Path.Combine(AppContext.BaseDirectory, "tasks.json")));

// Add Blazor Server with interactive server components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();