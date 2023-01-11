using Naruto.Views;
using Xamarin.Forms;

namespace Naruto
{
    public partial class App : Application
    {
        DataBase.DB myDB = new DataBase.DB();
        public App()
        {
            InitializeComponent();
            var db = myDB.openConnection();
            var queryProduct = "CREATE TABLE IF NOT EXISTS Naruto" +
                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Name TEXT, " +
                "Clan TEXT, " +
                "Age INTEGER, " +
                "Image TEXT, " +
                "Jutsu TEXT, " +
                "Color1 TEXT, " +
                "Color2 TEXT, " +
                "Color3 TEXT)";

            db.Execute(queryProduct);
            MainPage = new NavigationPage(new PageHome());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
