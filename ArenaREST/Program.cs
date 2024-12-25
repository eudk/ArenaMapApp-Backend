using ArenaREST.Context;
using ArenaREST.Repositories;
using ArenaREST.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});


builder.Services.AddDbContext<ArenaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AdminRepository>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<MenuRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<QRRepository>();
builder.Services.AddScoped<StallRepository>();

builder.Services.AddScoped<StallService>();
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<QRService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<AdminService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);

app.UseCors("allowall"); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
