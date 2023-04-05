using Microsoft.EntityFrameworkCore;
using Naruto.Context;
using Naruto.Models;
using Naruto.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class VM_See_Character : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context();

        #region VARIABLE
        public MNaruto receivedCharacter { get; set; }
        #endregion


        #region CONSTRUCTOR
        public VM_See_Character(INavigation navigation, MNaruto naruto)
        {
            Navigation = navigation;
            receivedCharacter = naruto;
        }
        #endregion


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
                _dbContext.Naruto.Remove(deleteCharacter);
               await _dbContext.SaveChangesAsync();

            }
            await Navigation.PushAsync(new PageHome());
        }
        public async Task goUpdateProduct()
        {
            await Navigation.PushAsync(new Edit_Character(receivedCharacter));
        }
        #endregion


        #region COMMANDS
        public ICommand btnBack => new Command(async () => await goBack());
        public ICommand btnGoUpDateCharacter => new Command(async () => await goUpdateProduct());
        public ICommand btnGoDeleteCharacter => new Command(async () => await DeleteCharacter());
        #endregion
    }
}
