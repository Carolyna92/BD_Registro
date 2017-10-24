using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BD_Registro.Droid;
using SQLite;


[assembly: Dependency(typeof(Registro_Droid))]


namespace BD_Registro.Droid
{
    public class Registro_Droid : Registro_BD
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);

        }
    }
}