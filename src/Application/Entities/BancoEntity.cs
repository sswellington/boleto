namespace Application.Entities;

public partial class BancoEntity
{
	public int Id { get; set; }
	public string Nome { get; set; } = "Não encontrado ou inicializado";
	public string Codigo { get; set; } = "000";
	public double PercentrualJuros { get; set; }
}
