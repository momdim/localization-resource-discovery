using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(culture: "no", uiCulture: "no");
    options.AddSupportedCultures("no", "en");
    options.AddSupportedUICultures("no", "en");
    options.RequestCultureProviders = new List<IRequestCultureProvider>()
    {
        new QueryStringRequestCultureProvider()
        {
            QueryStringKey = "culture",
            UIQueryStringKey = "culture"
        }
    };
});
builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllers();

app.Run();