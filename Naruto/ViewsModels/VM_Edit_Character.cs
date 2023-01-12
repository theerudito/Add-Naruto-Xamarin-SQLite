using Naruto.Models;
using Naruto.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class VM_Edit_Character : BaseViewModel
    {
        public MNaruto receivedCharacter { get; set; }

        #region VARIABLES
        public string _Textname;
        public string _Textclan;
        public int _Textage;
        public string _Textimage;
        public string _Textjutsu;
        public string _Textcolor1;
        public string _Textcolor2;
        public string _Textcolor3;
        #endregion

        DataBase.DB myDB = new DataBase.DB();

        #region CONSTRUCTOR
        public VM_Edit_Character(INavigation navigation, MNaruto naruto)
        {
            Navigation = navigation;
            receivedCharacter = naruto;
            TextName = receivedCharacter.Name;
            TextClan = receivedCharacter.Clan;
            TextAge = receivedCharacter.Age;
            TextImage = receivedCharacter.Image;
            TextJutsu = receivedCharacter.Jutsu;
            TextColor1 = receivedCharacter.Color1;
            TextColor2 = receivedCharacter.Color2;
            TextColor3 = receivedCharacter.Color3;
        }
        #endregion


        #region OBJETS
        public string TextName
        {
            get { return _Textclan; }
            set { SetValue(ref _Textclan, value); }

        }
        public string TextClan
        {
            get { return _Textclan; }
            set { SetValue(ref _Textclan, value); }
        }
        public int TextAge
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
        #endregion



        #region METHODS
        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }

        public async Task Edit_Caracter()
        {
            var db = myDB.openConnection();

            var editCharacter = "UPDATE Naruto SET " +
                "Name = '" + TextName + "', " +
                "Clan = '" + TextClan + "', " +
                "Age = '" + TextAge + "', " +
                "Image = '" + TextImage + "', " +
                "Jutsu = '" + TextJutsu + "', " +
                "Color1 = '" + TextColor1 + "', " +
                "Color2 = '" + TextColor2 + "', " +
                "Color3 = '" + TextColor3 + "' " +
                "WHERE Id = " + receivedCharacter.Id;

            db.Execute(editCharacter);

            await Navigation.PushAsync(new PageHome());

        }
        #endregion 

        #region COMMANDS
        public ICommand btnBackHome => new Command(async () => await goBack());
        public ICommand btnEditCharacter => new Command(async () => await Edit_Caracter());
        #endregion
    }
}
