
using Invoice_Project_MVCCore.BL;
using Invoice_Project_MVCCore.Services.Implementation;
using InvoiceProjectMVCCore.BL;
using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Implementation;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, TblCategoryRepository>();
builder.Services.AddScoped<IinvoicePaymentRepository, InvoicePaymentRepository>();
builder.Services.AddScoped<IinvoiceProductRepository, InvoiceProductRepository>();
builder.Services.AddScoped<ItblcityRepository, TblcityRepositorycs>();
builder.Services.AddScoped<ITblCustomerInvoiceRepository, TblCustomerInvoiceRepository>();
builder.Services.AddScoped<ITblCustomerRepository, TblCustomerRepository>();
builder.Services.AddScoped<ITblLocationRepository, TblLocationRepository>();
builder.Services.AddScoped<ITblOrderstockRepository, TblOrderStockRepository>();
builder.Services.AddScoped<ITblProductRepository, TblProductRepository>();
builder.Services.AddScoped<ITblRecivedStockProductRepository, TblRecivedStockProductRepository>();
builder.Services.AddScoped<ITblRecivedStockRepository, TblRecivedStockRepository>();
builder.Services.AddScoped<ITblstateRepository, TblstateRepository>();
builder.Services.AddScoped<ITblSubCategoryRepository, TblSubcategoryRepository>();
builder.Services.AddScoped<ItblUnitsRepository, TblUnitRepository>();
builder.Services.AddScoped<ITblUserRepository, TblUserRepository>();
builder.Services.AddScoped<ITblVenderRepository, TblVenderRepository>();
builder.Services.AddScoped<ITblOrderstockProductRepository, OrderStockProductRepository>();


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<InvoiceProjectContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(12);

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=login}/{action=Index}/{id?}");

app.Run();
