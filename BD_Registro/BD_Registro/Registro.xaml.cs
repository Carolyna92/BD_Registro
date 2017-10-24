using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BD_Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        SQLiteConnection database;
        public Registro()
        {
            InitializeComponent();
            
            string db;
            db = DependencyService.Get<Registro_BD>().GetLocalFilePath("Datos_Registro.db");
            database = new SQLiteConnection(db);
        }

        async void Enviar_Clicked(object sender, EventArgs e)
        {
            if (N.Text == null)
            {
                await DisplayAlert("", "Ingresa tu Nombre Completo", "OK");
            }
            else
            {
                if (AP.Text == null)
                {
                    await DisplayAlert("", "Ingresa tus Apeliidos", "OK");
                }
                else
                {
                    if (D.Text == null)
                    {
                        await DisplayAlert("", "Ingresa tu Direccion Completa", "OK");
                    }
                    else
                    {
                        if (T.Text == null)
                        {
                            await DisplayAlert("", "Ingresa tu Numero Telefonico", "OK");
                        }
                        else
                        {
                            if (C.SelectedItem == null)
                            {
                                await DisplayAlert("", "Selecciona una carrera", "OK");
                            }
                            else
                            {
                                if (S.SelectedItem == null)
                                {
                                    await DisplayAlert("", "Selecciona un Semestre", "OK");
                                }
                                else
                                {
                                    if (M.Text == null)
                                    {
                                        await DisplayAlert("", "Ingresa tú Matricula", "OK");
                                    }
                                    else
                                    {
                                        if (CE.Text == null)
                                        {
                                            await DisplayAlert("", "Ingresa tú Correo", "OK");
                                        }
                                        else
                                        {
                                            var email = CE.Text;
                                            var eP = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +//es para validar el correo si no contiene el @ o q no contenga el . depues del arroba  o si empieza con mayusculas
                                                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

                                            if (Regex.IsMatch(email, eP))
                                            {
                                                var data = new Datos_BD
                                                {

                                                    Matricula = Convert.ToInt32(M.Text),
                                                    Nombre = N.Text,
                                                    Apellidos = AP.Text,
                                                    Direccion = D.Text,
                                                    Telefono = T.Text,
                                                    Carrera = Convert.ToInt16(C.SelectedIndex),
                                                    Semestre = Convert.ToInt16(S.SelectedIndex),
                                                    Email = CE.Text,
                                                    Git_Hub = GH.Text,
                                                };
                                                
                                                try
                                                {
                                                    database.Insert(data);
                                                }
                                                catch(SQLiteException ex)
                                                {
                                                    await DisplayAlert("Error", "Fallo al intentar ingresar el registro", "OK");
                                     
                                                }
                                                //database.Insert(data);
                                                Navigation.PushAsync(new MainPage()).Wait();
                                            }
                                            else
                                            {
                                                CEV.Text = "Correo NO valido";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void N_TextChanged(object sender, TextChangedEventArgs e)
        {
            N.Text = N.Text.ToUpper();//cambia las minusculas a mayusculas
        }

        private void AP_TextChanged(object sender, TextChangedEventArgs e)
        {
            AP.Text = AP.Text.ToUpper();
        }

        private void D_TextChanged(object sender, TextChangedEventArgs e)
        {
            D.Text = D.Text.ToUpper();
        }

        private void T_TextChanged(object sender, TextChangedEventArgs e)
        {          
            long result;
            bool isValid = long.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            if (isValid)
            {
                
            }
            else
            {
                DisplayAlert("", "Solo Numeros a 10 digitos", "Aceptar");
            }
        }

        private void M_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            bool isValid = int.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            if (isValid)
            {

            }
            else
            {
                DisplayAlert("", "Matricula a 8 digitos", "Aceptar");
            }
        }
    }
}