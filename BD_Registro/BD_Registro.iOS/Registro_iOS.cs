using System;
using System.Collections.Generic;
using System.Text;
using BD_Registro.iOS;
using SQLite;
using Xamarin.Forms;
using System.IO;


[assembly: Dependency(typeof(Registro_iOS))]

namespace BD_Registro.iOS
{
    public class Registro_iOS : Registro_BD

    {

        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}
