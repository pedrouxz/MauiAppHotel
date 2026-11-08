namespace MauiAppHotel.Models;

public class Hospedagem
{
    private int _qtdAdultos;

    public Quarto QuartoSelecionado { get; set; } = new();

    public int QtdAdultos
    {
        get { return _qtdAdultos; }
        set
        {
            if (value >= 1)
                _qtdAdultos = value;
            else
                throw new ArgumentException("Deve haver pelo menos 1 adulto.");
        }
    }

    public int QtdCriancas { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }

    public int Estadia => (DataCheckOut - DataCheckIn).Days;

    public double ValorTotal =>
        Estadia * ((QtdAdultos * QuartoSelecionado.ValorDiariaAdulto) +
                   (QtdCriancas * QuartoSelecionado.ValorDiariaCrianca));
}