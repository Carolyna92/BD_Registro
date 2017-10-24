using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;


namespace BD_Registro
{
    public partial class MainPage : ContentPage
    {

        SQLiteConnection database;
        public ObservableCollection<Datos_BD> Items { get; set; }

        public MainPage()
        {
            
            string db;
            db = DependencyService.Get<Registro_BD>().GetLocalFilePath("Datos_Registro.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Datos_BD>();
            InitializeComponent();
            Items = new ObservableCollection<Datos_BD>(database.Table<Datos_BD>());
            BindingContext = this;
        }

        private void registros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
        }

        private void add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
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
                await Navigation.PushAsync(new Registro2(registros.SelectedItem as Datos_BD));
            }
            
        }

        public void eliminar_Clicked(object sender, EventArgs e)
        {
            if (registros.SelectedItem == null)
            {
                DisplayAlert("", "Selecciona el registro", "OK");
            }
            else
            {
                var datos = new Datos_BD
                {

                };
                database.Delete(registros.SelectedItem);
                Navigation.PushAsync(new MainPage()).Wait();
            }            
        }

        private void registros_Refreshing(object sender, EventArgs e)
        {

            
        }

    }
}
