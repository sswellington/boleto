using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BoletoController : ControllerBase
{
	private readonly IBoletoService _boletoService;

	public BoletoController(IBoletoService boletoService)
	{
		_boletoService = boletoService;
	}

	[HttpGet("{codigoBoleto}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BoletoDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<BoletoDto> Get(int codigoBoleto) => await _boletoService.GetById(codigoBoleto);
}
