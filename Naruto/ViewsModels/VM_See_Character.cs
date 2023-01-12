using Naruto.Models;
using Naruto.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class VM_See_Character : BaseViewModel
    {
        DataBase.DB myDB = new DataBase.DB();
        #region VARIABLE
        public MNaruto receivedCharacter { get; set; }
        #endregion
        public VM_See_Character(INavigation navigation, MNaruto naruto)
        {
            Navigation = navigation;
            receivedCharacter = naruto;
        }

        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }
        //public async Task goShowDetails()
        //{
        //    await Navigation.PushAsync(new Show_Character());
        //}
        public async Task DeleteCharacter()
        {
            var db = myDB.openConnection();
            var query = "DELETE FROM Naruto WHERE Id = " + receivedCharacter.Id;
            db.Execute(query);
            await Navigation.PushAsync(new PageHome());
        }
        public async Task goUpdateProduct()
        {
            await Navigation.PushAsync(new Add_Character());
        }

        public ICommand btnBack => new Command(async () => await goBack());
        //public ICommand btnShowCharacter => new Command(async () => await goShowDetails());
        public ICommand btnGoUpDateCharacter => new Command(async () => await goUpdateProduct());
        public ICommand btnGoDeleteCharacter => new Command(async () => await DeleteCharacter());

    }
}
