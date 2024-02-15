using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPactia.Utility
{
    public class Encript
    {
        public static class Seguridad
        {
            public static String EncryptPassword(string pass)
            {
                byte[] encryted = Encoding.Unicode.GetBytes(pass);
                return Convert.ToBase64String(encryted);
            }

            public static string DecryptPassword(string pass)
            {
                byte[] decryted = Convert.FromBase64String(pass);
                return Encoding.Unicode.GetString(decryted);
            }
        }
    }
}
