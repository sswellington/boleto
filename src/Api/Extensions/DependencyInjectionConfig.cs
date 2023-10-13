using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Repositories;

namespace Api.Extensions;

public static class DependencyInjectionConfig
{
	public static void Init(IServiceCollection services)
	{
		Repositories(services);
		Services(services);
	}

	private static void Repositories(IServiceCollection services)
	{
		services.AddScoped<IBancoRepository, BancoRepository>();
		services.AddScoped<IBoletoRepository, BoletoRepository>();
	}

	private static void Services(IServiceCollection services)
	{
		services.AddScoped<IBancoService, BancoService>();
		services.AddScoped<IBoletoService, BoletoService>();
	}
}