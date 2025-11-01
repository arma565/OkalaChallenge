using OkalaChallenge.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<WeatherApiClientService>((sp,client) => {
    var config = sp.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(config["OpenWeather:BaseUrl"] ?? throw new InvalidOperationException("OpenWeather:BaseUrl missing"));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
