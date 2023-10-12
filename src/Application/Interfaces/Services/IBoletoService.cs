using Application.Dtos;

namespace Application.Interfaces.Services;
public interface IBoletoService
{
	Task<BoletoDto> GetById(string id);
}
