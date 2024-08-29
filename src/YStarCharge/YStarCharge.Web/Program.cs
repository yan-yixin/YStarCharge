using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YStarCharge.Web.Data;
using YStarCharge.Web.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SqlDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'SqlDBContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IIncomeRepository, MockIncomeRepository>();
builder.Services.AddSingleton<IExpensesRepository, MockExpensesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    //app.UseSwagger();

    //app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    //{
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //    options.RoutePrefix = string.Empty;
    //});
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
