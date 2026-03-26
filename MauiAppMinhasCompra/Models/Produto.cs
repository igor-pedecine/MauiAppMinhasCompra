using SQLite;
namespace MauiAppMinhasCompra.Models
{
    public class Produto /*Esse codigo define a estrutura da tabela Produto no banco de dados */
    {
        String _descricao;/*validação da Descrição*/
        Double _quantidade;/*validação da Quantidade*/
        Double _preco;/*validação do Preço*/
        String _categoria;/*validação da Categoria*/


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Descricao {
            get => _descricao;
            set
            {
                if(value == null)
                {
                    throw new Exception("Todo os campos precisam ser preenchidos!!!");
                }

                _descricao = value;
            } 
        }
        
        public double Quantidade
        {
            get => _quantidade;
            set
            {
                if (value == 0 )
                {
                    throw new Exception("Todo os campos precisam ser preenchidos!!!");
                }

                _quantidade = value;
            }
        }

        public double Preco
        {
            get => _preco;
            set
            {
                if (value == 0)
                {
                    throw new Exception("Todo os campos precisam ser preenchidos!!!");
                }

                _preco = value;
            }
        }

        public string Categoria
        {
            get => _categoria;
            set
            {
                if (value == null)
                {
                    throw new Exception("Todo os campos precisam ser preenchidos!!!");
                }

                _categoria = value;
            }
        }

        public double Total { get => Quantidade * Preco; }
    }
}
