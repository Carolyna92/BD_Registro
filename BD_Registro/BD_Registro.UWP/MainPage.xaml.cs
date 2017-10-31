using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace BD_Registro.UWP
{
    public sealed partial class MainPage /*: ISQLAzure */    
    {
        private MobileServiceUser usuario;
        //public async Task<MobileServiceUser> Authenticate()
        //{
        //    try
        //    {
        //        usuario = await BD_Registro.MainPage.client.LoginAsync(MobileServiceAuthenticationProvider.Facebook, true);
        //            if (usuario != null)  /* La variable usuario no esta vacia, si no esta vacia ejecuta lo que esta dentro del if*/
        //            {
        //            await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
        //                                      //PRIMERO MENSAJE Y DESPUES EL TITULO
        //        }
        //    }
        //}
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new BD_Registro.App());
        }
    }
}
