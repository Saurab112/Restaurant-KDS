using Kds.Application.Di;
using Kds.Infrastructure;
using Kds.WebApi.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.RepositoryInterfaceDiConfig();
builder.Services.ServiceInterfaceDiConfig();

builder.Services.AddAuthentication();
builder.Services.AddControllersWithViews()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
	});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapControllers();
app.MapHub<SignalRHub>("/signalRHub");

app.Run();
