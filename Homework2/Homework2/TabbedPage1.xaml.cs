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
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public List<Teacher> Teachers { get => TeacherData(); }

        private List<Teacher> TeacherData()
        {
            var teachList = new List<Teacher>();
            teachList.Add(new Teacher { Image = "aarslan.jpg", Name = "Dr. Öğr. Üyesi Ahmet ARSLAN", Mail = "aarslan2@anadolu.edu.tr", Phone = "GSM:555-5555" });
            teachList.Add(new Teacher { Image = "serkangunal.jpg", Name = "Doç. Dr. Serkan GÜNAL", Mail = "serkangunal@anadolu.edu.tr", Phone = "GSM:555-555-5555" });
            teachList.Add(new Teacher { Image = "yhoscan.jpg", Name = "Prof. Dr. Yaşar HOŞCAN", Mail = "hoscan@anadolu.edu.tr", Phone = "GSM:555-555-5555" });
            teachList.Add(new Teacher { Image = "ckaleli.jpg", Name = "Doç. Dr. Cihan KALELİ", Mail = "ckaleli@anadolu.edu.tr", Phone = "GSM:555-555-5555" });
            teachList.Add(new Teacher { Image = "akuysal.jpg", Name = "Dr. Öğr. Üyesi Alper K. UYSAL", Mail = "akuysal@anadolu.edu.tr", Phone = "GSM:555-555-5555" });
            teachList.Add(new Teacher { Image = "abilge.jpg", Name = "Dr. Öğr. Üyesi Alper BİLGE", Mail = "abilge@anadolu.edu.tr", Phone = "GSM:555-555-5555" });

            return teachList;
        }

        public class Teacher
        {
            public string Image { get; set; }
            public string Name { get; set; }
            public string Mail { get; set; }
            public string Phone { get; set; }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {

            var result = await DisplayAlert("Dial a Number", "Would you like to call GSM:555-555-5555",
                                   "NO", "YES");
            if (result == true) // if it's equal to no
            {
                return; // just return to the page and do nothing.
            }
            else // if it's equal to yes
            {
                await Call("555-555-5555");
            }
        }

        public async Task Call(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private async void Derslik_Clicked(object sender, EventArgs e)
        {
            //TapGestureRecognizer.NumberOfTapsRequiredProperty.Equals(2);
            await Navigation.PushAsync(new ImgPage());
        }
    }
}