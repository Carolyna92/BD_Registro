using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BD_Registro
{
    public interface Registro_BD
    {
        string GetLocalFilePath(string filename);
    }
}
