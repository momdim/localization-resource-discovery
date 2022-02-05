using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(culture: "nb", uiCulture: "nb");
    options.AddSupportedCultures("nb", "en");
    options.AddSupportedUICultures("nb", "en");
    options.AddInitialRequestCultureProvider(new QueryStringRequestCultureProvider()
    {
        UIQueryStringKey = "culture",
        QueryStringKey = "culture"
    });
});
builder.Services.AddLocalization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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