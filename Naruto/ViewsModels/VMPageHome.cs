using Microsoft.EntityFrameworkCore;
using Naruto.Context;
using Naruto.Models;
using Naruto.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Naruto.ViewsModels
{
    public class VMPageHome : BaseViewModel
    {
        Application_Context _dbCcontext = new Application_Context();

        public Command LoadData { get; }

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

            if (SearchText == "")
            {
                GET_ALL_CHARACTERS();
            }

            LoadData = new Command(async () => await GET_ALL_CHARACTERS());
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
            IsBusy = true;
            try
            {
                var result = await _dbCcontext.Naruto.ToListAsync();

                List<MNaruto> list_character = new List<MNaruto>();

                foreach (var item in result)
                {
                    var list = new MNaruto 
                    { 
                        Id = item.Id,
                        Name = item.Name, 
                        Age = item.Age, 
                        Clan = item.Clan,
                        Image = item.Image,
                        ImageProfile = ConvertImage.ToPNG(item.Image),
                        Jutsu = item.Jutsu,
                        Color1 = item.Color1,
                        Color2 = item.Color2,
                        Color3 = item.Color3,
                    };

                    list_character.Add(list);
                }

                Lista_Characters = new ObservableCollection<MNaruto>(list_character);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task goAddCharacter()
        {
            await Navigation.PushAsync(new Add_Character());
        }

        public async Task getOneCharacter()
        {
            
            //var searchingOneCharacter = await _dbCcontext.Naruto.Where(n => n.Name == SearchText).FirstOrDefaultAsync();

            var searchingOneCharacter = await _dbCcontext.Naruto
                                .Where(u => u.Name.StartsWith(SearchText))
                                .ToListAsync();


            if (searchingOneCharacter == null)
            {
                await DisplayAlert("info", "Doen's  Result Trying Later", "OK");
                
            } else
            {
                List<MNaruto> list_character = new List<MNaruto>();

                foreach (var item in searchingOneCharacter)
                {
                    var list = new MNaruto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Age = item.Age,
                        Clan = item.Clan,
                        Image = item.Image,
                        ImageProfile = ConvertImage.ToPNG(item.Image),
                        Jutsu = item.Jutsu,
                        Color1 = item.Color1,
                        Color2 = item.Color2,
                        Color3 = item.Color3,
                    };

                    list_character.Add(list);
                }

                Lista_Characters = new ObservableCollection<MNaruto>(list_character);
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
