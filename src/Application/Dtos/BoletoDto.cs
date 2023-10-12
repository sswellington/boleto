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
);
