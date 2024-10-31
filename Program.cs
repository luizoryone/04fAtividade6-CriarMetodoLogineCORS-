using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Adicionar os serviços necessários
builder.Services.AddScoped<ExoContext, ExoContext>();
builder.Services.AddControllers();

// Configuração da autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
// Parâmetros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem está solicitando
        ValidateIssuer = true,
        // Valida quem está recebendo
        ValidateAudience = true,
        // Define se o tempo de expiração será validado
        ValidateLifetime = true,
        // Criptografia e validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes("exoapi-chaveautenticacao")),
        // Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(30),
        // Nome do issuer, da origem
        ValidIssuer = "exoapi.webapi",
        // Nome do audience, para o destino
        ValidAudience = "exoapi.webapi"
    };
});

// Registrar repositórios
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();

var app = builder.Build();

app.UseRouting();

// Habilita a autenticação.
app.UseAuthentication();
// Habilita a autorização.
app.UseAuthorization();

// Adicionar autenticação e autorização ao pipeline
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();












// using Exo.WebApi.Contexts;
// using Exo.WebApi.Repositories;
// using Microsoft.IdentityModel.Tokens;


// var builder = WebApplication.CreateBuilder(args);

// // Adicionar os servi�os necess�rios
// builder.Services.AddScoped<ExoContext, ExoContext>();
// builder.Services.AddControllers();

// // Forma de autenticacão.
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = "JwtBearer";
//     options.DefaultChallengeScheme = "JwtBearer";
// })
// // Parâmetros de validacão do token.
// .AddJwtBearer("JwtBearer", options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         // Valida quem está solicitando.
//         ValidateIssuer = true,
//         // Valida quem está recebendo.
//         ValidateAudience = true,
//         // Define se o tempo de expiração será validado.
//         ValidateLifetime = true,
//         // Criptografia e validação da chave de autenticacão.
//         IssuerSigningKey = new
//     SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chaveautenticacao")),
//         // Valida o tempo de expiração do token.
//         ClockSkew = TimeSpan.FromMinutes(30),
//         // Nome do issuer, da origem.
//         ValidIssuer = "exoapi.webapi",
//         // Nome do audience, para o destino.
//         ValidAudience = "exoapi.webapi"
//     };
// })

// builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();
// builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();

// var app = builder.Build();

// app.UseRouting();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });

// app.Run();




//using Exo.WebApi.Contexts;
//using Exo.WebApi.Repositories;
//using.Exo.WebApi.Controllers;


//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<ExoContext, ExoContext>();
//builder.Services.AddControllers();
//builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();

////adicionar UsuarioRepository
//builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();

//var app = builder.Build();

//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.Run();
