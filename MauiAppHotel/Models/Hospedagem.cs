namespace MauiAppHotel.Models;

public class Hospedagem
{
    public Quarto QuartoSelecionado { get; set; } = new();
    public int QtdAdultos { get; set; }
    public int QtdCriancas { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }

    public int Estadia => (DataCheckOut - DataCheckIn).Days;

    public double ValorTotal =>
        Estadia * ((QtdAdultos * QuartoSelecionado.ValorDiariaAdulto) +
                   (QtdCriancas * QuartoSelecionado.ValorDiariaCrianca));
}