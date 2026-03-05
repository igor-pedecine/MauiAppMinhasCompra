using MauiAppMinhasCompra.Models;
namespace MauiAppMinhasCompra.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto()
            {/*Esse codigo pega as informações colocadas nos labels e coloca na tabela do banco de dados*/
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };
            App.Db.Insert(p);
            DisplayAlert("Sucesso!!", "Registro cadastrado com sucesso!!", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!!", ex.Message, "OK");
        }
    }
}