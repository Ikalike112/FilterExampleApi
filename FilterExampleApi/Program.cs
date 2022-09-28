using FilterExampleApi;
using FilterExampleApi.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add custom Resourse Filter to all of controllers
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(DebugResourseFilter));
    options.Filters.Add(typeof(VersionDiscontinueResourseFilter));
});
builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer(opt => opt.GroupNameFormat = "'v'VVV");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
