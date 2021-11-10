using FluentValidation;
using FluentValidation.AspNetCore;
using GamesLibraryAPI;
using GamesLibraryAPI.Entities;
using GamesLibraryAPI.Middleware;
using GamesLibraryAPI.Services.Account;
using GamesLibraryAPI.Validators;
using GamesLibraryShared;
using GamesLibraryShared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>();

// Add custom validation errors response

builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = string.Join(" | ", c.ModelState.Values.Where(v => v.Errors.Count > 0)
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage));

        return new BadRequestObjectResult(new BaseResponse
        {
            Error = true,
            Message = errors
        });
    };
});

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<JwtMiddleware>();
builder.Services.AddScoped<IValidator<UserRegisterRequest>, RegisterUserValidator>();
builder.Services.AddScoped<IValidator<UserLoginRequest>, LoginUserValidator>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();