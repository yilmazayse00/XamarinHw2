using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homework2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void Register_OnClicked(object sender, EventArgs e)
        {
            //Preferences.Set("mailaddress", "password");

            if (string.IsNullOrEmpty(mailaddress.Text) || string.IsNullOrEmpty(password.Text))
                DisplayAlert("Empty Values", "Please enter E-mail address and Password", "OK");
            else
            {
                Preferences.Set(mailaddress.Text, password.Text);
                DisplayAlert("Sign Up Success", "", "Ok");
                Navigation.PushAsync(new MainPage());
            }


        }
        private void OnMainPageSizeChanged2(object sender, EventArgs e)
        {
            if (Width * Height < 0) return;

            if (Width < Height)
            {
                SignUpGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                SignUpGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                SignUpGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                Grid.SetRow(SignUpStackLayout, 1);
                Grid.SetColumn(SignUpStackLayout, 0);
            }
            else
            {
                SignUpGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                SignUpGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Star);
                SignUpGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                Grid.SetRow(SignUpStackLayout, 0);
                Grid.SetColumn(SignUpStackLayout, 1);
            }
        }
    }
}