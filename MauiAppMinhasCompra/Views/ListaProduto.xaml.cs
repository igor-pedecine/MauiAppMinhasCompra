using System.Linq.Expressions;

namespace MauiAppMinhasCompra.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {/*Esse é o codigo por tras do botão adicinar, trocando para outra pagina */
        try
		{
			Navigation.PushAsync(new Views.NovoProduto());

		} catch (Exception ex)
		{
			DisplayAlert("Ops!!", ex.Message, "OK");
		}
    }
}