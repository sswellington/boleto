using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BancoController : ControllerBase
{
	private readonly IBancoService _bancoService;

	public BancoController(IBancoService bancoService)
	{
		_bancoService = bancoService;
	}

	[HttpGet("{codigoBanco}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BancoDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<BancoDto> Get(string codigoBanco) => await _bancoService.GetById(codigoBanco);

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BancoDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IEnumerable<BancoDto>> Get()
	{
		var model = await _bancoService.GetById("000");
		var models = new List<BancoDto>(){ model, model };
		return models;
	}
}
