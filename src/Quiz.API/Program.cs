using Microsoft.EntityFrameworkCore;
using Quiz.Business;
using Quiz.Business.MappingProfiles;
using Quiz.Business.Services.Implementations;
using Quiz.Business.Services.Interfaces;
using Quiz.Business.Validations;
using Quiz.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterRepos();
builder.Services.AddAutoMapper(typeof(BlogProfile));
builder.Services.AddScoped<IBlogService, BlogService>();
//builder.Services.AddValidatorsFromAssemblyContaining<BlogGetDtoValidator>();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.UseStaticFiles();
app.Run();
