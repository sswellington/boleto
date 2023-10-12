using Application.Dtos;

namespace Application.Interfaces.Services;
public interface IBancoService
{
	Task<BancoDto> GetById(string id);
}
