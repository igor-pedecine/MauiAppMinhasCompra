using SQLite;
namespace MauiAppMinhasCompra.Models
{
    public class Produto /*Esse codigo define a estrutura da tabela Produto no banco de dados */
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }
    }
}
