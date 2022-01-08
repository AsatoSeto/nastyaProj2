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
        public MainPage()
        {
            InitializeComponent();
            ButNext.Clicked+= OnButtonClicked;
            
        }
       
        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            await  Navigation.PushAsync(new MyPage(Smena));
        }
        private  void pickerSmena_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Smena = pickerSmena.SelectedItem.ToString();
        }

    }
  
  
   
}
