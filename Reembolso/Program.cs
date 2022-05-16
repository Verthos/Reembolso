

using Microsoft.EntityFrameworkCore;
using MtgDataAPI.Data;
using Reembolso.Repository;
using Reembolso.Repository.IRepository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "https://localhost:3000";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // entender erro de 
builder.Services.AddDbContext<ReembolsoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IRefundRepository, RefundRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


//foi necessário adicionar este campo para requisições do mesmo terminal, junto da variavel MyAllowSpecificOrigins e o middleware UseCors (DOC: https://docs.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-6.0)
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy => { policy.WithOrigins("https://localhost:3000");});
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
