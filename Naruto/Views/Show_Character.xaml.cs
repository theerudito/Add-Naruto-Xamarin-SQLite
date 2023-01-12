using Naruto.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Naruto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Show_Character : ContentPage
    {
        public Show_Character()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new VM_See_Character(Navigation);
        }
    }
}