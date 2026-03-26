using MauiAppMinhasCompra.Models;
namespace MauiAppMinhasCompra.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (picker_categoria.SelectedItem == null)/*feito com ajuda da IA*/ 
            {
                await DisplayAlert("Erro", "Todo os campos precisam ser preenchidos!!!", "OK");
                return;
            }

            Produto p = new Produto()
            {/*Esse codigo pega as informações colocadas nos labels e coloca na tabela do banco de dados*/
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),
                Categoria = picker_categoria.SelectedItem.ToString()
            };
            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!!", "Registro cadastrado com sucesso!!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!!", ex.Message, "OK");
        }
    }
}