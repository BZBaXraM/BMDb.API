var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddCore(builder.Configuration);

builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials());

app.UseHsts();

app.UseRouting();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseMiddleware<BlackListMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

await app.RunAsync();