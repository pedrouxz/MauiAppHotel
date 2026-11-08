namespace MauiAppHotel;

public partial class ContratoHospedagem : ContentPage
{
    public ContratoHospedagem()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}