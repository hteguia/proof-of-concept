using SonarDemoMcp.Data;
using SonarDemoMcp.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration simple
builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<DataAccess>();

var app = builder.Build();

app.MapControllers();

// méthode longue et compliquée dans Program (code smell: grosse méthode)
void DoEverythingStartup()
{
    var repeated = "repeat";
    // duplicated logic intentionally
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine(repeated + i);
    }
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine(repeated + i);
    }
}
DoEverythingStartup();

app.Run();