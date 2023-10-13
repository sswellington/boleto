using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
	public async Task<BancoDto> Get(string codigoBanco) => await _bancoService.GetByCodeOfBank(codigoBanco);

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BancoDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IEnumerable<BancoDto>> Get()
	{
		var model = await _bancoService.GetAll();
		return model;
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BancoDto))]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Post([FromBody] BancoDto bancoDto)
	{
		try
		{
			await _bancoService.Register(bancoDto);
			return CreatedAtAction(nameof(Get), new { codigoBanco = bancoDto.Codigo }, bancoDto);
		}
		catch (ArgumentException ex)
		{
			return BadRequest("Ocorreu um erro ao cadastrar o banco: " + ex.Message);
		}
	}
}
