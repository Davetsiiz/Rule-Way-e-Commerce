using CaseRW.Core.Repositories;
using CaseRW.Core.Services;
using CaseRW.Core.UnitOfWork;
using CaseRW.Repository.Context;
using CaseRW.Repository.Repositories;
using CaseRW.Repository.UnitOfWorks;
using CaseRW.Service.Mapping;
using CaseRW.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;




var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers().AddFluentValidationAutoValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
//builder.Services.AddControllers().AddFluentValidationAutoValidation();
//builder.Services.AddControllers().AddFluentValidationClientsideAdapters();
//builder.Services.AddControllers().AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
//Fluent validationu inaktif hale getiririz
//builder.Services.Configure<ApiBehaviorOptions>(opt =>
//{
//    opt.SuppressModelStateInvalidFilter = true;
//});



#region Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion

#region Service
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
#endregion


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
        //opt.MigrationsAssembly("CaseRW.Repository");
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
