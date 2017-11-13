using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BD_Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminados : ContentPage
    {
        public static IMobileServiceTable<Datos_BD> Tabla;

        public ObservableCollection<Datos_BD> Items { get; set; }
        public Eliminados()
        {
            InitializeComponent();
            Tabla = Logeo.cliente.GetTable<Datos_BD>();
            LeerTablaU();
        }

        private void registros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
        }

        async void add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        private void Filtro_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyboard = Filtro.Text;
            var opciones = Items.Where(c => c.Apellidos.Contains(Filtro.Text.ToUpper()));
            registros.ItemsSource = opciones;

        }

        async void editar_Clicked(object sender, EventArgs e)
        {
            if (registros.SelectedItem == null)
            {
                await DisplayAlert("", "Selecciona el registro", "OK");
            }
            else
            {
                await Navigation.PushAsync(new RegistrosEM(registros.SelectedItem as Datos_BD));
            }

        }

        private async void LeerTablaU()
        {

            IEnumerable<Datos_BD> elementos = await Tabla.IncludeDeleted().Where(DatosBD=>DatosBD.Deleted==true).ToCollectionAsync(); //Convierte en una lista enumerable
            Items = new ObservableCollection<Datos_BD>(elementos);
            BindingContext = this;
            await RefreshItems(true, syncItems: true);
        }

        private async void del_Toggled(object sender, ToggledEventArgs e)
        {
            if (elim.IsToggled == false)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshItems(true, syncItems: true);
        }
        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems(false, true);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }
        private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
        {
            using (var scope = new ActivityIndicatorScope(act_list, showActivityIndicator))
            {
                IEnumerable<Datos_BD> elementos = await Tabla.IncludeDeleted().Where(DatosBD => DatosBD.Deleted == true).ToEnumerableAsync(); //Convierte en una lista enumerable
                Items = new ObservableCollection<Datos_BD>(elementos);
                BindingContext = this;
            }
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
        {
            this.indicator = indicator;
            this.showIndicator = showIndicator;

            if (showIndicator)
            {
                indicatorDelay = Task.Delay(2000);
                SetIndicatorActivity(true);
            }
            else
            {
                indicatorDelay = Task.FromResult(0);
            }
        }

        private void SetIndicatorActivity(bool isActive)
        {
            this.indicator.IsVisible = isActive;
            this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
    }
}