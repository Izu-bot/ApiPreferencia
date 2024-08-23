using ApiPreferencia;
using ApiPreferencia.Data.Context;
using ApiPreferencia.Data.Repository;
using ApiPreferencia.Model;
using ApiPreferencia.Services;
using ApiPreferencia.VIewModel.UserVM;
using Asp.Versioning;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

#region Connection database

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

#endregion

#region IoC

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

#endregion


#region Configurando o AutoMapper

var mapperConfig = new AutoMapper.MapperConfiguration(a =>
{
    // Maper coleção nula
    a.AllowNullCollections = true;

    // Permite mapear valores nulos
    a.AllowNullDestinationValues = true;

    // Mapeando as ViewsModels
    a.CreateMap<UserModel, AddUserViewModel>();
    a.CreateMap<AddUserViewModel, UserModel>();
    a.CreateMap<UserModel, GetUserViewModel>();
    a.CreateMap<GetUserViewModel, UserModel>();

});

// Criando o maper com base nas config
IMapper mapper = mapperConfig.CreateMapper();

// Registra o mapper como serviço
builder.Services.AddSingleton(mapper);

#endregion

#region versionamento
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);

    options.ReportApiVersions = true;

    options.AssumeDefaultVersionWhenUnspecified = true;

    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";

    options.SubstituteApiVersionInUrl = true;
});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
