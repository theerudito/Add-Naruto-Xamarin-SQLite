using Naruto.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Naruto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new VMPageHome(Navigation);
        }
    }
}