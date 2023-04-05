using Microsoft.EntityFrameworkCore;
using Naruto.Context;
using Naruto.Models;
using Naruto.Views;
using Xamarin.Forms;

namespace Naruto
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var _dbCcontext = new Application_Context();

            int id = 1;

            _dbCcontext.Database.Migrate();


            var newCharacter = new MNaruto
            {
                Id = 1,
                Name = "Naruto",
                Clan = "Uzumaki",
                Age = 12,
                Image = "naruto.png",
                Jutsu = "Rasengan",
                Color1 = "Orange",
                Color2 = "Blue",
                Color3 = "Black",
            };

            var searchCharacter = _dbCcontext.Naruto.Find(id);

            if (searchCharacter == null)
            {
                _dbCcontext.Add(newCharacter);
                _dbCcontext.SaveChanges();
            }

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
