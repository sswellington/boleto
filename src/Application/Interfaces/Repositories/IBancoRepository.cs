using Application.Entities;

namespace Application.Interfaces.Repositories;
public interface IBancoRepository
{
	Task<BancoEntity> GetById(string id);
}
