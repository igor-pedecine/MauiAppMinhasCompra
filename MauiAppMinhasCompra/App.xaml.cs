using __XamlGeneratedCode__;
using MauiAppMinhasCompra.Helpers;

namespace MauiAppMinhasCompra
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelpers _db;
        
        public static SQLiteDatabaseHelpers Db 
        {
            get 
            {
                if (_db == null)
                {
                    /*Esse codigo gerencia a conexão com o banco e... */
                    string caminho = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelpers(caminho);
                }
                return _db;
            }
        
        
        
        }
        public App()
        {
            InitializeComponent();  /*define a tela inicial do aplicativo*/

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
