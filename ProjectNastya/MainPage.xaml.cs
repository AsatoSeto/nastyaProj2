using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;




namespace ProjectNastya
{
    public partial class MainPage : ContentPage
    {
        public string Smena;
        public string Master;
        public string OTKController;
        public string Brig;
        public string Uchastok;
        public string Date;


        public MainPage()
        {
            InitializeComponent();
            ButNext.Clicked+= OnButtonClicked;
            pickerBrigada.SelectedIndex = 0;
            pickerSmena.SelectedIndex = 0;
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {

            //Brigada = pickerBrigada.SelectedItem.ToString();
            Brig = pickerBrigada.SelectedItem.ToString();
            Date = DatePick.Date.ToString();
            Master = master.Text;
            OTKController = otkController.Text;
            Uchastok = uchastok.Text;
            if (string.IsNullOrEmpty(Smena) ||
                string.IsNullOrEmpty(Master) ||
                string.IsNullOrEmpty(OTKController) ||
                string.IsNullOrEmpty(Uchastok))
            {
               await DisplayAlert("Ошибка", "Заполните все поля", "OK");
            } else { 
               await Navigation.PushAsync(new MyPage(Smena, Brig, Uchastok, OTKController, Master, Date));
            }
        }

        private  void pickerSmena_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Smena = pickerSmena.SelectedItem.ToString();

        }

    }
  
  
   
}
