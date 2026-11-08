using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    List<Quarto> lista_quartos = new List<Quarto>
    {
        new Quarto { Descricao = "Suíte Executiva", ValorDiariaAdulto = 150, ValorDiariaCrianca = 75 },
        new Quarto { Descricao = "Suíte Master",    ValorDiariaAdulto = 250, ValorDiariaCrianca = 120 },
        new Quarto { Descricao = "Quarto Standard", ValorDiariaAdulto = 100, ValorDiariaCrianca = 50 }
    };

    public MainPage()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        DateTime hoje = DateTime.Now.Date;
        dtp_checkin.MinimumDate = hoje;
        dtp_checkin.MaximumDate = hoje.AddMonths(6);
        dtp_checkout.MinimumDate = hoje.AddDays(1);
        dtp_checkout.MaximumDate = hoje.AddMonths(6).AddDays(30);
        dtp_checkout.Date = hoje.AddDays(1);
    }

    private void OnCheckInSelected(object sender, DateChangedEventArgs e)
    {
        DateTime checkin = e.NewDate ?? DateTime.Now.Date;
        DateTime minimo = checkin.AddDays(1);
        dtp_checkout.MinimumDate = minimo;

        DateTime checkout = dtp_checkout.Date ?? minimo;
        if (checkout < minimo)
            dtp_checkout.Date = minimo;
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert("Atenção", "Selecione o tipo de quarto.", "OK");
                return;
            }

            DateTime checkin = dtp_checkin.Date ?? DateTime.Now.Date;
            DateTime checkout = dtp_checkout.Date ?? DateTime.Now.Date.AddDays(1);

            // Validação do DatePicker
            if (checkout <= checkin)
            {
                await DisplayAlert("Datas inválidas",
                    "O check-out deve ser depois do check-in.", "OK");
                return;
            }

            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QtdAdultos = (int)stp_adultos.Value,
                QtdCriancas = (int)stp_criancas.Value,
                DataCheckIn = checkin,
                DataCheckOut = checkout
            };

            await Navigation.PushAsync(new ContratoHospedagem
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}