using Application.Dtos;

namespace Application.Interfaces.Services;
public interface IBancoService
{
	Task<BancoDto> GetByCodeOfBank(string code);
	Task<BancoDto> GetById(int id);
	Task<ICollection<BancoDto>> GetAll();
	Task<bool> Register(BancoDto dto);
}
