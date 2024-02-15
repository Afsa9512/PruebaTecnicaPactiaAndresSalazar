using PruebaPactia.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPactia.DAL.Connection
{
    public class ConnectionDB
    {
        public string ConexionDao()
        {
            // Obtener la cadena de conección que se agrega en el archivo appsettings.json
            return ApiConnectionDB.ConnectionStringPrueba;
        }
    }
}
