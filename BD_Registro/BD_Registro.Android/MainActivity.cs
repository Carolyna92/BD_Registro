using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Net;
using Android.Webkit;
//using Android.Webkit;

namespace BD_Registro.Droid
{
    [Activity(Label = "BD_Registro", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                usuario = await BD_Registro.Logeo.cliente.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook, "bdregistroazure.azurewebsites.net");
                if (usuario != null)
                {
                    message = string.Format("iniciando sesion{0].",usuario.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("");
            builder.Create().Show();
            return usuario;
        }
        public async Task<bool> LogoutAsync()
        {
            CookieManager.Instance.RemoveAllCookie();
            await BD_Registro.Logeo.cliente.LogoutAsync();
            return true;
        }


        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((ISQLAzure)this);
            LoadApplication(new App());
        }
    }
}

