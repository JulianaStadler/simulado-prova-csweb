using Microsoft.EntityFrameworkCore;
using WebSiteFanfic.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebSiteFanficDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});


var app = builder.Build();
app.Run();