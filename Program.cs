using GitHubRepoSearchApi.BL;
using GitHubRepoSearchApi.BL.Interfaces;
using GitHubRepoSearchApi.BL.Services;
using GitHubRepoSearchApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001")
              .AllowAnyHeader()
              .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddHttpClient();
builder.Services.AddDistributedMemoryCache(); //
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddControllers();
builder.Services.AddHttpClient<IGitHubService, GitHubService>();

var app = builder.Build();

app.UseSession();
app.UseCors("AllowFrontend");
app.UseAuthorization();

app.MapControllers();

app.Run();
