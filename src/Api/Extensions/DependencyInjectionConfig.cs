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
		services.AddSingleton<IBancoRepository, BancoRepository>();
		services.AddSingleton<IBoletoRepository, BoletoRepository>();
	}

	private static void Services(IServiceCollection services)
	{
		services.AddSingleton<IBancoService, BancoService>();
		services.AddSingleton<IBoletoService, BoletoService>();
	}
}