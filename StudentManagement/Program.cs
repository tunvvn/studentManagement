using AspNetCoreRateLimit;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentManagement;
using StudentManagement.Configruations;
using StudentManagement.Datas;
using StudentManagement.IRepository;
using StudentManagement.Repository;
using StudentManagement.Services;
using StudentManagement.Services.ClassService;
using StudentManagement.Services.StudentSerivce;
using StudentManagement.Services.SubjectService;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(builder =>
builder.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAutoMapper(typeof(MapperInitializi));


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.CongigureVersioning();

builder.Services.AddDbContext<DataBaseContext>(dbContextOptions =>
dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
);

builder.Services.AddMemoryCache();

builder.Services.ConfigureRateLimiting();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddResponseCaching();

builder.Services.ConfigureHttpCacheHeaders();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

builder.Services.AddControllers()
                 .AddFluentValidation(options =>
                 {
                     options.ImplicitlyValidateChildProperties = true;
                     options.ImplicitlyValidateRootCollectionElements = true;
                     options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                 });


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                      });
});

builder.Services.AddControllers(configure =>
{
    configure.CacheProfiles.Add("120SecondsDuration", new CacheProfile
    {
        Duration = 120
    });

});

builder.Host.UseSerilog((context, logconfig) =>
{
    logconfig.WriteTo.Console();
    logconfig.WriteTo.File(path: "C:\\log\\log.txt");
});

var app = builder.Build();



app.UseCors(MyAllowSpecificOrigins);

app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseIpRateLimiting();

app.UseRouting();






if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    string path = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";

    options.SwaggerEndpoint($"{path}/swagger/v1/swagger.json", "Hotel Listening V1");
    // options.RoutePrefix = string.Empty;
});
app.ConfigureExeptionHandle();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller= Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();


