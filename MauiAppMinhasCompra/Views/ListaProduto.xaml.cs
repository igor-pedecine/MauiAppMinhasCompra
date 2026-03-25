using System.Collections.ObjectModel;
using System.Linq.Expressions;
using MauiAppMinhasCompra.Models;
using System.Linq;



namespace MauiAppMinhasCompra.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

	public ListaProduto()
	{
		InitializeComponent();

		lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();

            List<Produto> tmp = await App.Db.GetAll();
            
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
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

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {/*barra de busca do produto pelo nome */
        try
        {
            string q = e.NewTextValue;

            lst_produtos.IsRefreshing = true;

            lista.Clear();

            List<Produto> tmp = await App.Db.Search(q); 

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");

        } finally 
        {
            lst_produtos.IsRefreshing = false;
        }
        
	}

	private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {/*Botão de soma dos produtos*/
		double soma = lista.Sum(i => i.Total);
		string msg = $"O valor total da compra é: {soma:C}";

		DisplayAlert("Total da Compra", msg, "OK");
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {/*Botão de exclusão de um produto*/
        try
        {
            MenuItem selecionado = sender as MenuItem;
            Produto prod = selecionado.CommandParameter as Produto;

            bool confirmar = await DisplayAlert(
                "Confirmar", $"Deseja realmente excluir {prod.Descricao}?", "Sim", "Não");

            if (confirmar)
            {
                await App.Db.Delete(prod.Id);

                lista.Remove(prod);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {/*Botão de edição de um Produto*/
        try
        {
            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
             DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void lst_produtos_Refreshing(object sender, EventArgs e)
    {/*recarega o feed*/
        try
        {
            lista.Clear();

            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        } finally
        {
            lst_produtos.IsRefreshing = false;
        }
    }
}