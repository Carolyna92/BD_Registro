using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace BD_Registro
{
    public interface ISQLAzure
    {
        Task<MobileServiceUser> Authenticate();

        Task<bool> LogoutAsync();
    }

    }

        
  
