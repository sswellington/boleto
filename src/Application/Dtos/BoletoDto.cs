using Application.Entities;
using System.Reflection;

namespace Application.Dtos;
public sealed record BoletoDto
(
	int Id,
	PessoaDto Pagador,
	PessoaDto Beneficiario,
	double Valor,
	DateOnly DataVencimento,
	string Observacao,
	int BancoId
)
{
	private static string IsCpf(string cpf) => cpf.Length == 11 ? cpf : "-";
	private static string IsCnpj(string cnpj) => cnpj.Length == 14 ? cnpj : "-";

	public static BoletoDto Entity2Dto(BoletoEntity entity)
	{
		var pagador = new PessoaDto
		(
			Cpf: IsCpf(entity.CpfCnpjPagador),
			Cnpj: IsCnpj(entity.CpfCnpjPagador),
			Nome: entity.NomePagador
		);

		var beneficiario = new PessoaDto
		(
			Cpf: IsCpf(entity.CpfCnpjBeneficiario),
			Cnpj: IsCnpj(entity.CpfCnpjBeneficiario),
			Nome: entity.NomeBeneficiario
		);

		return new BoletoDto
		(
			Id: entity.Id,
			Pagador: pagador,
			Beneficiario: beneficiario,
			Valor: entity.ValorBrl,
			DataVencimento: entity.DataVencimento,
			Observacao: entity.Observacao,
			BancoId: entity.BancoId
		);
	}
}