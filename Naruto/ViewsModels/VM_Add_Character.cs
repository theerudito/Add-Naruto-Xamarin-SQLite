﻿using Naruto.Models;
using Naruto.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    public class VM_Add_Character : BaseViewModel
    {
        //Name 
        //Clan 
        //Age
        //Jutsu
        //Image 
        //Color1 
        //Color2 

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

        #region
        public VM_Add_Character(INavigation navigation)
        {
            Navigation = navigation;
        }
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

        public async Task Add_Caracter()
        {
            var db = myDB.openConnection();

            var insertCharacter = "INSERT INTO Naruto (Name, Clan, Age, Jutsu, Image, Color1, Color2, Color3) " +
                "VALUES ('" + TextName + "', '" + TextClan + "', '" + TextAge + "', '" + TextJutsu + "', '" + TextImage + "', '" + TextColor1 + "', '" + TextColor2 + "', '" + TextColor3 + "')";

            db.Execute(insertCharacter);

            await Navigation.PushAsync(new PageHome());

        }
        #endregion COMMANDS



        #region
        public ICommand btnBackHome => new Command(async () => await goBack());
        public ICommand btnAddNewCharacter => new Command(async () => await Add_Caracter());
        #endregion
    }
}