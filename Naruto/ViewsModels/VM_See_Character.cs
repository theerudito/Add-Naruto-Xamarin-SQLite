using Naruto.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class VM_See_Character : BaseViewModel
    {
        public VM_See_Character(INavigation navigation)
        {
            Navigation = navigation;
        }

        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }
        public async Task goShowDetails()
        {
            await Navigation.PushAsync(new Show_Character());
        }
        public async Task DeleteCharacter()
        {
            await DisplayAlert("Delete", "Are you sure you want to delete this character?", "Yes", "No");
        }
        public async Task goUpdateProduct()
        {
            await Navigation.PushAsync(new Add_Character());
        }

        public ICommand btnBack => new Command(async () => await goBack());
        public ICommand btnShowCharacter => new Command(async () => await goShowDetails());
        public ICommand btnGoUpDateCharacter => new Command(async () => await goUpdateProduct());
        public ICommand btnGoDeleteCharacter => new Command(async () => await DeleteCharacter());

    }
}
