using Application.Entities;

namespace Application.Dtos;
public sealed record BancoDto
(
	int Id,
	string Nome,
	string Codigo,
	double PercentualJuros
)
{
	public static BancoDto Entity2Dto(BancoEntity entity) => new
	(
		Id: entity.Id,
		Nome: entity.Nome,
		Codigo: entity.Codigo,
		PercentualJuros: entity.PercentualJuros
	);
}