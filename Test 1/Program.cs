using Microsoft.AspNetCore.Cors.Infrastructure;
using Test_1.DataEF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(crosOptions =>
{
    crosOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
    {
        CorsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<MissingPersonEntity>(options =>
{
    options.UseSqlServer("Data Source =ESLAM\\SQLEXPRESS ; Initial Catalog = missingperson ; Integrated Security =True ; Trusted_Connection=True ; Encrypt = False");
});
builder.Services.AddIdentity<ApplicationUser , IdentityRole>().
    AddEntityFrameworkStores<MissingPersonEntity>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
app.UseStaticFiles();
app.UseCors("MyPolicy");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
