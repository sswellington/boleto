namespace Application.Dtos;
public sealed record BancoDto
(
	int Id,
	string Nome,
	string Codigo,
	double PercentrualJuros
);
