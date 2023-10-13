using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities;

public partial class BoletoEntity
{
	[Key]
	public int Id { get; set; }
	public string CpfCnpjPagador { get; set; } = "00000000000";
	public string NomePagador { get; set; } = "Não encontrado ou inicializado";
	public string CpfCnpjBeneficiario { get; set; } = "00000000000";
	public string NomeBeneficiario { get; set; } = "Não encontrado ou inicializado";
	public double ValorBrl { get; set; }	
	public DateOnly DataVencimento {get; set; }
	public string Observacao { get; set; } = "Não encontrado ou inicializado";

	public int BancoId { get; set; }

	[ForeignKey("BancoId")]
	public BancoEntity? Banco { get; set; }
}
