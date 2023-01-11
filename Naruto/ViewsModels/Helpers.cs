using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class Helpers : BaseViewModel
    {


        #region VARIABLES
        string _Text;
        #endregion

        #region CONSTRUCTOR
        public Helpers()
        {

        }
        #endregion

        #region OBJETOS
        public string Text
        {
            get { return _Text; }
            set { SetValue(ref _Text, value); }
        }
        #endregion

        #region METODOS ASYNC
        public async Task MetodoAsincrono()
        {
            await Task.Delay(1000);
            Text = "Hola Mundo";
        }
        #endregion

        #region METODOS SIMPLE
        public void MetodoSimple()
        {
            Text = "Hola Mundo";
        }
        #endregion


        #region COMANDOS
        public ICommand AlertaAsincrona => new Command(async () => await MetodoAsincrono());
        public ICommand AlertaSimple => new Command(() => MetodoSimple());
        #endregion
    }
}
