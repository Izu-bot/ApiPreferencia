using ApiPreferencia;
using ApiPreferencia.Data.Context;
using ApiPreferencia.Data.Repository;
using ApiPreferencia.Model;
using ApiPreferencia.Services;
using ApiPreferencia.VIewModel.LabelVM;
using ApiPreferencia.VIewModel.PreferenceVM;
using ApiPreferencia.VIewModel.UserVM;
using Asp.Versioning;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Serialização Json

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

#endregion

#region Configuração para porta de acesso

//builder.WebHost.UseKestrel(opt =>
//{
//    opt.ListenAnyIP(32769); // porta 32769
//});

#endregion

#region Connection database

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

#endregion

#region IoC

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPreferenceRepository, PreferenceRepository>();
builder.Services.AddScoped<IPreferenceService, PreferenceService>();

builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<ILabelService, LabelService>();

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

    a.CreateMap<PreferenceModel, AddPreferenceViewModel>();
    a.CreateMap<AddPreferenceViewModel, PreferenceModel>();
    a.CreateMap<PreferenceModel, GetPreferenceViewModel>();
    a.CreateMap<GetPreferenceViewModel, PreferenceModel>();

    a.CreateMap<LabelModel, GetLabelViewModel>();
    a.CreateMap<GetLabelViewModel, LabelModel>();
    a.CreateMap<LabelModel, AddLabelViewModel>();
    a.CreateMap<AddLabelViewModel, LabelModel>();

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
