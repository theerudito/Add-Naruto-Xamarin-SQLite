using Microsoft.EntityFrameworkCore;
using Naruto.Context;
using Naruto.Models;
using Naruto.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Naruto.ViewsModels
{
    public class VMPageHome : BaseViewModel
    {
        Application_Context _dbCcontext = new Application_Context();

        #region VARIABLES
        string _searchText;

        SearchBar SearchTex = new SearchBar();

        ObservableCollection<MNaruto> _Lista_character;
        #endregion


        #region CONSTRUCTOR
        public VMPageHome(INavigation navigation)
        {
            Navigation = navigation;
          
            GET_ALL_CHARACTERS();

            if (SearchText != "")
            {
                GET_ALL_CHARACTERS();
            } else
            {
                GET_ALL_CHARACTERS();
            }
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
            var result = await _dbCcontext.Naruto.ToListAsync();

            Lista_Characters = new ObservableCollection<MNaruto>(result);
        }
        public async Task goAddCharacter()
        {
            await Navigation.PushAsync(new Add_Character());
        }

        public async Task getOneCharacter()
        {
            if (SearchText == null)
            {
              await  GET_ALL_CHARACTERS();
            }

            var searchingOneCharacter = await _dbCcontext.Naruto.Where(n => n.Name == SearchText).FirstOrDefaultAsync();

            if (searchingOneCharacter == null)
            {
                await DisplayAlert("info", "No se encontraron resultados", "OK");
                
            } else
            {   
                Lista_Characters.Clear();
                Lista_Characters.Add(searchingOneCharacter);  
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
