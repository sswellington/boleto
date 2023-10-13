using Api.Extensions;
using Infrastructure.ObjectRelationalMapping.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Api;

public static class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		DependencyInjectionConfig.Init(builder.Services);

		builder.Services.AddDbContext<BoletoContext>(options =>
		{
			options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
		}, ServiceLifetime.Scoped);

		builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			Log.Information("building the application in Development");
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseSerilogRequestLogging();
		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.MapControllers();
		app.Run();

		Log.Information("finished");
	}
}