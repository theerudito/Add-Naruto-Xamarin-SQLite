using Naruto.Models;
using Naruto.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Naruto.ViewsModels
{
    public class VMPageHome : BaseViewModel
    {

        #region VARIABLES
        string _searchText;
        DataBase.DB myDB = new DataBase.DB();
        ObservableCollection<MNaruto> _Lista_character;
        #endregion


        #region CONSTRUCTOR
        public VMPageHome(INavigation navigation)
        {
            Navigation = navigation;
            GET_ALL_CHARACTERS();
        }
        #endregion


        #region OBJETOS
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MNaruto> Lista_Characters
        {
            get { return _Lista_character; }
            set
            {
                SetValue(ref _Lista_character, value);
                OnpropertyChanged();
            }
        }
        #endregion


        #region METODOS ASYNC
        public async Task GET_ALL_CHARACTERS()
        {
            var db = myDB.openConnection();
            var query = "SELECT * FROM Naruto";
            var result = db.Query<MNaruto>(query);
            Lista_Characters = new ObservableCollection<MNaruto>(result);
        }
        public async Task goAddCharacter()
        {
            await Navigation.PushAsync(new Add_Character());
        }
        public async Task getOneCharacter()
        {
            var db = myDB.openConnection();
            var query = "SELECT * FROM Naruto WHERE Name LIKE '%" + SearchText + "%'";

            var result = db.Query<MNaruto>(query);

            if (result.Count > 0)
            {
                Lista_Characters = new ObservableCollection<MNaruto>(result);
            }
            else
            {
                await DisplayAlert("Alerta", "No se encontraron resultados", "OK");
            }

        }
        public async Task goShowCharacter(MNaruto naruto)
        {
            await Navigation.PushAsync(new Show_Character(naruto));
        }
        #endregion


        #region COMANDOS
        public ICommand btnAddCharacter => new Command(async () => await goAddCharacter());
        public ICommand btnShowCharacter => new Command<MNaruto>(async (n) => await goShowCharacter(n));
        public ICommand SearchCharacter => new Command(async () => await getOneCharacter());
        #endregion
    }
}
