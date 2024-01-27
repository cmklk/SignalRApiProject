using SignalR.BusinessLayer.Manager;
using SignalR.BusinessLayer.Services;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutServices, AboutManager>();

builder.Services.AddScoped<IBookingDal, EFBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<ICategoryServices, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();

builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactServices, ContactManager>();

builder.Services.AddScoped<ITestimonialDal, EFTestimonialDal>();
builder.Services.AddScoped<ITestimonialServices, TestimonialManager>();

builder.Services.AddScoped<IDiscountDal, EFDiscountDal>();
builder.Services.AddScoped<IDiscountServices, DiscountManage>();

builder.Services.AddScoped<IFeatureDal, EFFeatureDal>();
builder.Services.AddScoped<IFeaturesServices, FeatureManager>();

builder.Services.AddScoped<IProductDal, EFPRoductDal>();
builder.Services.AddScoped<IProductServices, ProductManager>();

builder.Services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaServices, SocialMediaManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
