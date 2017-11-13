using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;


namespace BD_Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logeo : ContentPage
    {
        public static MobileServiceClient cliente;
        private MobileServiceUser usuario;
        public Logeo()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
        }

        private  async void Login_Clicked(object sender, EventArgs e)
        {
            usuario = await App.Authenticator.Authenticate();
            if (App.Authenticator !=null)
                {
                if (usuario !=null)
                {
                    await DisplayAlert("Usuario Autenticado", usuario.UserId, "Ok");
                    await Navigation.PushAsync(new MainPage());
                }
                if (usuario == null)
                {
                    
                }
            }
        }
    }
}