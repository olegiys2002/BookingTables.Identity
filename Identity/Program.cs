using Identity.ServicesConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlServer(builder.Configuration);
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureIdentityServer(builder.Configuration);
builder.Services.ConfigureCORS();   
builder.Services.ConfigureCaching(builder.Configuration);
builder.Services.ConfigureElasticsearch(builder.Configuration);
builder.Services.ConfigureAppOptions(builder.Configuration);
builder.Services.ConfigureMassTransit(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseIdentityServer();


app.MapControllers();

app.Run();
