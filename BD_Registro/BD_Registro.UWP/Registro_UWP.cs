using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;
using BD_Registro.UWP;

[assembly: Dependency(typeof(Registro_UWP))]

namespace BD_Registro.UWP
{
   public  class Registro_UWP : Registro_BD
    {
           public string GetLocalFilePath(string filename)
            {
                return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            }
    }
}

