using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services;
public sealed class BancoService : IBancoService
{
	private readonly IBancoRepository _bancoRepository;

	public BancoService(IBancoRepository bancoRepository)
	{
		_bancoRepository = bancoRepository;
	}

	public async Task<bool> Register(BancoDto dto)
	{
		//TODO: Validar os dado que são obrigatórias estão preenchidas.

		BancoEntity entity = BancoDto.Dto2Entity(dto);
		return await _bancoRepository.Register(entity);
	}

	public async Task<BancoDto> GetByCodeOfBank(string code)
	{
		BancoEntity model = await _bancoRepository.GetByCodeOfBank(code);
		return BancoDto.Entity2Dto(model);
	}

	public async Task<BancoDto> GetById(int id)
	{
		BancoEntity model = await _bancoRepository.GetById(id);
		return BancoDto.Entity2Dto(model);
	}

	public async Task<ICollection<BancoDto>> GetAll()
	{
		var entities = await _bancoRepository.GetAll();
		List<BancoDto> dtos = new List<BancoDto>();

		foreach (var item in entities)
			dtos.Add(BancoDto.Entity2Dto(item));

		return dtos;
	}
}
