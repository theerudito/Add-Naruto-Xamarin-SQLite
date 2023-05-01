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
    public class VM_Add_Character : BaseViewModel
    {
        #region VARIABLES
        public MNaruto receivedCharacter { get; set; }
        public string _Textname;
        public string _Textclan;
        public int _Textage;
        public string _Textimage;
        public string _Textjutsu;
        public string _Textcolor1;
        public string _Textcolor2;
        public string _Textcolor3;

        public ImageSource _image;
        private string _byteImagen;

        #endregion VARIABLES

        private Application_Context _dbContext = new Application_Context();

        #region CONSTRUCTOR

        public VM_Add_Character(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion CONSTRUCTOR

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

        public ImageSource Image
        {
            get { return _image; }
            set
            {
                SetValue(ref _image, value);
            }
        }

        public string ByteImage
        {
            get { return _byteImagen; }
            set
            {
                SetValue(ref _byteImagen, value);
            }
        }

        #endregion OBJETS

        #region METHODS

        public async Task goBack()
        {
            await Navigation.PushAsync(new PageHome());
        }

        public async Task OpenGalery()
        {
            var result = await FilePicker.PickAsync();

            if (result.ContentType == "image/png" || result.ContentType == "image/jpeg" || result.ContentType == "image/webp")
            {
                if (result != null)
                {
                    Image = result.FullPath;
                    TextImage = result.FileName;

                    var stream = await result.OpenReadAsync();

                    var bytes = new byte[stream.Length];

                    await stream.ReadAsync(bytes, 0, (int)stream.Length);

                    string base64 = Convert.ToBase64String(bytes);

                    ByteImage = base64;
                }
            }
            else
            {
                await DisplayAlert("info", "The File doens't compatible only files allowed .jpg, .png or .webp ", "ok");

                Image = ImageSource.FromFile("hoja_dark.png");
            }
        }

        public async Task AddCaracter()
        {
            var addNewCharacter = new MNaruto
            {
                Name = TextName,
                Clan = TextClan,
                Age = TextAge,
                Image = ByteImage,
                Jutsu = TextJutsu,
                Color1 = Color1,
                Color2 = Color2,
                Color3 = Color3,
            };

            _dbContext.Add(addNewCharacter);
            await _dbContext.SaveChangesAsync();

            await DisplayAlert("info", "Saved With Successfully", "ok");

            await Navigation.PushAsync(new PageHome());
        }

        public async Task goAddCharacter()
        {
            await Navigation.PushAsync(new Add_Character());
        }

        public async Task goShowCharacter(MNaruto naruto)
        {
            await Navigation.PushAsync(new Show_Character(naruto));
        }

        #endregion METHODS

        #region
        public ICommand btnLoadImageCommnad => new Command(async () => await OpenGalery());
        public ICommand btnBackHome => new Command(async () => await goBack());
        public ICommand btnGoUpDateCharacter => new Command(async () => await goAddCharacter());
        public ICommand btnShowCharacter => new Command<MNaruto>(async (n) => await goShowCharacter(n));
        public ICommand btnAddNewCharacter => new Command(async () => await AddCaracter());
        #endregion
    }
}