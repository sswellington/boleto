using Application.Entities;

namespace Application.Interfaces.Repositories;
public interface IBancoRepository
{
	Task<BancoEntity> GetByCodeOfBank(string code);
	Task<BancoEntity> GetById(int id);
	Task<ICollection<BancoEntity>> GetAll();
}
