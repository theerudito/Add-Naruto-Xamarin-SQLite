using Naruto.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Naruto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Character : ContentPage
    {
        public Add_Character()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new VM_Add_Character(Navigation);
        }
    }
}