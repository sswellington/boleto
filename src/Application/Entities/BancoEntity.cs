using System.ComponentModel.DataAnnotations;

namespace Application.Entities;

public partial class BancoEntity
{
	[Key]
	public int Id { get; set; }
	public string Nome { get; set; } = "Não encontrado ou inicializado";
	public string Codigo { get; set; } = "000";
	public double PercentualJuros { get; set; }

	public virtual ICollection<BoletoEntity> Boleto { get; set; }

	public BancoEntity() => Boleto = new HashSet<BoletoEntity>();
}
