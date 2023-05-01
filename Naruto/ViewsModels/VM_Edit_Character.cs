using Naruto.Context;
using Naruto.Models;
using Naruto.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    internal class VM_Edit_Character : BaseViewModel
    {
        private Application_Context _dbContext = new Application_Context();
        public MNaruto _receivedCharacter { get; set; }

        public VM_Edit_Character(INavigation navigation, MNaruto naruto)
        {
            Navigation = navigation;
            _receivedCharacter = naruto;

            getData();
        }

        #region VARIABLES

        public string _Textname;
        public string _Textclan;
        public string _Textage;
        public string _Textimage;
        public string _Textjutsu;
        public string _Textcolor1;
        public string _Textcolor2;
        public string _Textcolor3;
        public ImageSource _imageSource;
        public string _Base64Image;

        #endregion VARIABLES

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

        public ImageSource ImageProfile
        {
            get { return _imageSource; }
            set { SetValue(ref _imageSource, value); }
        }

        public string Base64Image
        {
            get { return _Base64Image; }
            set { SetValue(ref _Base64Image, value); }
        }

        #endregion OBJETS

        #region METHODS

        public void getData()
        {
            TextName = _receivedCharacter.Name;
            TextClan = _receivedCharacter.Clan;
            TextAge = Convert.ToString(_receivedCharacter.Age);
            ImageProfile = ConvertImage.ToPNG(_receivedCharacter.Image);
            TextJutsu = _receivedCharacter.Jutsu;
            TextColor1 = _receivedCharacter.Color1;
            TextColor2 = _receivedCharacter.Color2;
            TextColor3 = _receivedCharacter.Color3;
        }

        public async Task OpenGaleryEdit()
        {
            var result = await FilePicker.PickAsync();

            if (result.ContentType == "image/png" || result.ContentType == "image/jpeg" || result.ContentType == "image/webp")
            {
                if (result != null)
                {
                    ImageProfile = result.FullPath;

                    TextImage = result.FileName;

                    var stream = await result.OpenReadAsync();

                    var bytes = new byte[stream.Length];

                    await stream.ReadAsync(bytes, 0, (int)stream.Length);

                    string base64 = Convert.ToBase64String(bytes);

                    Base64Image = base64;
                }
            }
            else
            {
                await DisplayAlert("info", "The File doens't compatible only files allowed .jpg, .png or .webp ", "ok");

                ImageProfile = ImageSource.FromFile("hoja_dark.png");
            }
        }

        public async Task Edit_Caracter()
        {
            _receivedCharacter.Name = TextName;
            _receivedCharacter.Clan = TextClan;
            _receivedCharacter.Age = Convert.ToInt32(TextAge);
            _receivedCharacter.Image = Base64Image == null ? _receivedCharacter.Image : Base64Image;
            _receivedCharacter.Jutsu = TextJutsu;
            _receivedCharacter.Color1 = TextColor1;
            _receivedCharacter.Color2 = TextColor2;
            _receivedCharacter.Color3 = TextColor3;

            _dbContext.Update(_receivedCharacter);
            await _dbContext.SaveChangesAsync();

            await DisplayAlert("Info", "Saved With Succesfully", "ok");

            await Navigation.PushAsync(new PageHome());
        }

        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnLoadImageEditCommnad => new Command(async () => await OpenGaleryEdit());
        public ICommand btnEditCharacter => new Command(async () => await Edit_Caracter());
        public ICommand btnBackHome => new Command(async () => await goBack());

        #endregion COMMANDS
    }
}