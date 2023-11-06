using Microsoft.EntityFrameworkCore;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Services;
using YZCollege.Infrastructure.Context;
using YZCollege.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
//    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
//});

builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<ICourseService, CourseService>();

if (!builder.Environment.IsEnvironment("Testing"))
    builder.Services.AddDbContext<SqlContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseReDoc(options => { options.DocumentTitle = "College Docs"; options.SpecUrl = "/swagger/v1/swagger.json"; });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//app.UseMiddleware<AuthMiddleware>();

app.Run();

public partial class Program { }
