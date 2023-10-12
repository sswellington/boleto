using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services;
public sealed class BoletoService : IBoletoService
{
	private readonly IBoletoRepository _boletoRepository;

	public BoletoService(IBoletoRepository boletoRepository)
	{
		_boletoRepository = boletoRepository;
	}

	public async Task<BoletoDto> GetById(string id)
	{
		var model = await _boletoRepository.GetById(id);
		var pagador = new PessoaDto
		(
			Cpf: model.CpfCnpjPagador.Length == 11 ? model.CpfCnpjPagador : "-",
			Cnpj: model.CpfCnpjPagador.Length == 14 ? model.CpfCnpjPagador : "-",
			Nome: model.NomePagador
		);

		var beneficiario = new PessoaDto
		(
			Cpf: model.CpfCnpjBeneficiario.Length == 11 ? model.CpfCnpjBeneficiario : "-",
			Cnpj: model.CpfCnpjBeneficiario.Length == 14 ? model.CpfCnpjBeneficiario : "-",
			Nome: model.NomeBeneficiario
		);

		return new BoletoDto
		(
			Id: model.Id,
			Pagador: pagador,
			Beneficiario: beneficiario,
			Valor: model.ValorBrl,
			DataVencimento: model.DataVencimento,
			Observacao: model.Observacao,
			BancoId: model.BancoId
		);
	}
};
