using Naruto.Models;
using Naruto.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    class VM_Edit_Character : BaseViewModel
    {
        DataBase.DB myDB = new DataBase.DB();

        public VM_Edit_Character(INavigation navigation, MNaruto naruto)
        {
            Navigation = navigation;
            _receivedCharacter = naruto;
            TextName = _receivedCharacter.Name;
            TextClan = _receivedCharacter.Clan;
            TextAge = Convert.ToString(_receivedCharacter.Age);
            TextImage = _receivedCharacter.Image;
            TextJutsu = _receivedCharacter.Jutsu;
            TextColor1 = _receivedCharacter.Color1;
            TextColor2 = _receivedCharacter.Color2;
            TextColor3 = _receivedCharacter.Color3;
        }


        #region VARIABLES
        private string GitHub = "https://github.com/theerudito";
        private string Web = "https://byerudito.web.app/";
        public MNaruto _receivedCharacter { get; set; }
        public string _Textname;
        public string _Textclan;
        public string _Textage;
        public string _Textimage;
        public string _Textjutsu;
        public string _Textcolor1;
        public string _Textcolor2;
        public string _Textcolor3;
        #endregion


        #region OBJETS
        public string TextName
        {
            get { return _Textname; }
            set { SetValue(ref _Textname, value); }

        }
        public string TextClan
        {
            get { return _Textclan; }
            set { SetValue(ref _Textclan, value); }
        }
        public string TextAge
        {
            get { return _Textage; }
            set { SetValue(ref _Textage, value); }
        }
        public string TextImage
        {
            get { return _Textimage; }
            set { SetValue(ref _Textimage, value); }
        }
        public string TextJutsu
        {
            get { return _Textjutsu; }
            set { SetValue(ref _Textjutsu, value); }
        }
        public string TextColor1
        {
            get { return _Textcolor1; }
            set { SetValue(ref _Textcolor1, value); }
        }
        public string TextColor2
        {
            get { return _Textcolor2; }
            set { SetValue(ref _Textcolor2, value); }
        }
        public string TextColor3
        {
            get { return _Textcolor3; }
            set { SetValue(ref _Textcolor3, value); }
        }

        public string Color1
        {
            get { return _Textcolor1; }
            set { SetValue(ref _Textcolor1, value); }
        }
        public string SelectColor1
        {
            get { return _Textcolor1; }
            set
            {
                SetProperty(ref _Textcolor1, value);
                Color1 = _Textcolor1;

            }
        }

        public string Color2
        {
            get { return _Textcolor2; }
            set { SetValue(ref _Textcolor2, value); }
        }
        public string SelectColor2
        {
            get { return _Textcolor2; }
            set
            {
                SetProperty(ref _Textcolor2, value);
                Color2 = _Textcolor2;

            }
        }

        public string Color3
        {
            get { return _Textcolor3; }
            set { SetValue(ref _Textcolor3, value); }
        }
        public string SelectColor3
        {
            get { return _Textcolor3; }
            set
            {
                SetProperty(ref _Textcolor3, value);
                Color3 = _Textcolor3;

            }
        }
        #endregion


        #region METHODS
        public async Task Edit_Caracter()
        {
            var db = myDB.openConnection();
            var editCharacter = "UPDATE Naruto SET " +
                "Name = '" + TextName + "', " +
                "Clan = '" + TextClan + "', " +
                "Age = '" + Convert.ToInt16(TextAge) + "', " +
                "Image = '" + TextImage + "', " +
                "Jutsu = '" + TextJutsu + "', " +
                "Color1 = '" + TextColor1 + "', " +
                "Color2 = '" + TextColor2 + "', " +
                "Color3 = '" + TextColor3 + "' " +
                "WHERE Id = " + _receivedCharacter.Id;
            db.Execute(editCharacter);
            await Navigation.PushAsync(new PageHome());
        }
        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }
        public async Task openWeb()
        {
            await Launcher.OpenAsync(Web);
        }
        public async Task openGitHub()
        {
            await Launcher.OpenAsync(GitHub);
        }
        #endregion


        #region COMMANDS
        public ICommand btnEditCharacter => new Command(async () => await Edit_Caracter());
        public ICommand btnBackHome => new Command(async () => await goBack());
        public ICommand btnOpenWeb => new Command(async () => await openWeb());
        public ICommand btnOpenGithub => new Command(async () => await openGitHub());
        #endregion

    }
}
