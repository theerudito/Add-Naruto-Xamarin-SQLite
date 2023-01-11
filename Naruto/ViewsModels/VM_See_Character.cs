using Naruto.Views;
using System;
using System.Collections.Generic;
using System.Text;
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


        public ICommand btnBack => new Command(async () => await goBack());

    }
}
