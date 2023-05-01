using Microsoft.EntityFrameworkCore;
using Naruto.Context;
using Naruto.Models;
using Naruto.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class VM_See_Character : BaseViewModel
    {
        private Application_Context _dbContext = new Application_Context();

        #region VARIABLE

        private string GitHub = "https://github.com/theerudito";
        private string Web = "https://byerudito.web.app/";
        public MNaruto receivedCharacter { get; set; }

        public ImageSource ImageProfile { get; set; }

        #endregion VARIABLE

        #region CONSTRUCTOR

        public VM_See_Character(INavigation navigation, MNaruto naruto)
        {
            Navigation = navigation;

            receivedCharacter = naruto;

            ImageProfile = ConvertImage.ToPNG(naruto.Image);
        }

        #endregion CONSTRUCTOR

        #region METHODS

        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }

        public async Task DeleteCharacter()
        {
            var deleteCharacter = await _dbContext.Naruto.FirstOrDefaultAsync(cha => cha.Id == receivedCharacter.Id);

            if (deleteCharacter != null)
            {
                if (await DisplayAlert("Info", "Are You Surely To Delete", "yes", "no"))
                {
                    _dbContext.Naruto.Remove(deleteCharacter);
                    await _dbContext.SaveChangesAsync();
                    await DisplayAlert("Info", "Deleted With Sussessfully", "ok");
                    await Navigation.PushAsync(new PageHome());
                }
                else
                {
                    return;
                }
            }
            else
            {
                await DisplayAlert("Error", "Error to Delete", "ok");
            }
        }

        public async Task goUpdateProduct()
        {
            await Navigation.PushAsync(new Edit_Character(receivedCharacter));
        }

        public async Task openWeb()
        {
            await Launcher.OpenAsync(Web);
        }

        public async Task openGitHub()
        {
            await Launcher.OpenAsync(GitHub);
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnBack => new Command(async () => await goBack());
        public ICommand btnGoUpDateCharacter => new Command(async () => await goUpdateProduct());
        public ICommand btnGoDeleteCharacter => new Command(async () => await DeleteCharacter());
        public ICommand btnOpenWeb => new Command(async () => await openWeb());
        public ICommand btnOpenGithub => new Command(async () => await openGitHub());

        #endregion COMMANDS
    }
}