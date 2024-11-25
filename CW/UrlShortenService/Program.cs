using Microsoft.EntityFrameworkCore;
using UserLinkService.Data;
using UserLinkService.Models;
using UserLinkService.Repositories;
using UserLinkService.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repository to the container
builder.Services.AddScoped<IUserLinkRepository, UserLinkRepository>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll"); // Use the CORS policy
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//name of the website for shorten url
app.MapPost("api/shorten", (ApplicationDbContext dbContext,
    UserLinkRepository ULRep) =>
{
    var userlink = new UserLink
    {
        //insert request here getting from fe
        Link = "https://www.reddit.com/"
    };
      ULRep.GenerateNewLink(userlink);
});
app.MapGet("/api/{newuserlink}", async (String newuserlink, ApplicationDbContext dbContext) =>
{
    String n = $"http://localhost:5249/api/{newuserlink}";
    var shortenUrl = await dbContext.UserLinks.FirstOrDefaultAsync(s => s.ShortenLink == n);

    if(shortenUrl is null)
    {
        return Results.NotFound();
    }
    //return Results.Redirect(shortenUrl.ShortenLink);
    return Results.Redirect(shortenUrl.Link);
});

app.Run();
