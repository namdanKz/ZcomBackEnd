using backend_api.Data;
using backend_api.Interfaces;
using backend_api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserGroupRepository,UserGroupRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IQuestionRepository,QuestionRepository>();
builder.Services.AddScoped<ISelectedChoicesRepository,SelectedChoicesRepository>();
builder.Services.AddScoped<ISaveAnswerRepository,SaveAnswerRepository>();

        // Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
                builder => builder
                    .WithOrigins("http://localhost:4200") // Replace with your Angular app's URL
                    .AllowAnyMethod()
                    .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

