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
        public string A;
       
        public MainPage()
        {
            InitializeComponent();
            ButNext.Clicked+= OnButtonClicked;
        }
       
        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            await  Navigation.PushAsync(new MyPage());
        }
        private  void pickerSmena_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            A = pickerSmena.SelectedItem.ToString();
        }

    }
    public class ProgClass {
        public string OPA() {
            MainPage a = new MainPage();
            return a.A;
        }
    }
  
   
}
