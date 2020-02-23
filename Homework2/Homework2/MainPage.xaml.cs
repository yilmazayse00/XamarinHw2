using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Homework2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void SignInButton_OnClicked(object sender, EventArgs e)
        {

            string value = Preferences.Get(mailaddress.Text, "");

            if (password.Text == value)
            {
                var result2 = await DisplayAlert("Login Process", "Username and Password Match!", "CANCEL", "CONTINUE");

                if (result2 == true) //cancel
                {
                    return;//stay the page
                }
                else //continue
                    await Navigation.PushAsync(new TabbedPage1());
            }
            else
            {
                var result = await DisplayAlert("Login Process", "Username and Password Dismatch!", "", "CANCEL");
                if (result != true) // if it's equal to cancel
                {
                    return; // just return to the page and do nothing.
                }
            }
        }

        private void OnMainPageSizeChanged(object sender, EventArgs e)
        {
            if (Width * Height < 0) return;

            if (Width < Height)
            {
                MainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                MainGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                MainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                MainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);
                Grid.SetRow(ContentStackLayout, 1);
                Grid.SetColumn(ContentStackLayout, 0);
            }
            else
            {
                MainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                MainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Star);
                MainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                MainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                Grid.SetRow(ContentStackLayout, 0);
                Grid.SetColumn(ContentStackLayout, 1);
            }
        }

        void OnTapSignUpLabel(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        void OnTapForgotPasswordLabel(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RenewPasswordPage());
        }

    }
}
