using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaxCalculator.Data;
using TaxCalculator.Domain.Interfaces.Repositories;
using TaxCalculator.Infrastructure.Interfaces;
using TaxCalculator.Infrastructure.Persistence.Repositories;
using TaxCalculator.Infrastructure.Services;
using TaxCalculator.Infrastructure.Services.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<TaxCalculatorDBContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(builder =>
{
    builder.SwaggerDoc("v1", new() { Title = "TaxCalculator", Version = "v1" });
});

//DI
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<ITaxPostalCodeRepository, TaxPostalCodeRepository>();
builder.Services.AddScoped<ITaxTypeRepository, TaxTypeRepository>();
builder.Services.AddScoped<ITaxCalculationService, FlatValueTaxService>();
builder.Services.AddScoped<ITaxCalculationService, ProgressiveTaxService>();
builder.Services.AddScoped<ITaxCalculationService, FlatRateTaxService>();
builder.Services.AddScoped<ITaxServiceFactory, TaxServiceFactory>();
builder.Services.AddScoped<ITaxCalculationResultRepository,  TaxCalculationResultRepository>();



var assembly = typeof(Program).Assembly;
builder.Services.AddAutoMapper(assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
     defaults: new { controller = "Home", action = "Index" }
    );
app.MapRazorPages();

app.Run();
