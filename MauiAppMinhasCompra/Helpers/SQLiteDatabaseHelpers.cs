using MauiAppMinhasCompra.Models;
using SQLite;

namespace MauiAppMinhasCompra.Helpers
{
    public class SQLiteDatabaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelpers(string caminho) 
        {
            _conn = new SQLiteAsyncConnection(caminho);
            _conn.CreateTableAsync<Produto>().Wait();/*cria uma tabela nova chamada Produto, no banco de dados*/
        }
        public Task<int> Insert(Produto p)/*este método INSERE um registro do tipo Produto no banco de dados SQLite*/
        { 
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p) /*O método UPDATE tenta atualizar um registro existente na tabela Produto no banco de dados, com base no ID fornecido no objeto Produto (p)*/
        {
            string sql = "UPDADTE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }
        public Task<int> Delete(int id) /*O método DELETE remove um registro da tabela Produto com base no Id fornecido como argumento. Ele utilizaa funcionalidade assíncrona do SQLite para realizar a exclusão sem bloquear a thread principal.*/
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll() /*O método GetAll (READ) é utilizado para consulta a tabela Produto no banco de dados e retorna todos os registros naforma de uma lista de objetos Produto*/
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT *  FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
