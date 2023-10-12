namespace Application.Entities;

public partial class BoletoEntity
{
	public int Id { get; set; }
	public string CpfCnpjPagador { get; set; } = "00000000000";
	public string NomePagador { get; set; } = "Não encontrado ou inicializado";
	public string CpfCnpjBeneficiario { get; set; } = "00000000000";
	public string NomeBeneficiario { get; set; } = "Não encontrado ou inicializado";
	public double ValorBrl { get; set; }	
	public DateOnly DataVencimento {get; set; }
	public string Observacao { get; set; } = "Não encontrado ou inicializado";

	public int BancoId { get; set; }
}
