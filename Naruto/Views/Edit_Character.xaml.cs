using Naruto.Models;
using Naruto.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Naruto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit_Character : ContentPage
    {
        public Edit_Character(MNaruto naruto)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new VM_Edit_Character(Navigation, naruto);
        }
    }
}