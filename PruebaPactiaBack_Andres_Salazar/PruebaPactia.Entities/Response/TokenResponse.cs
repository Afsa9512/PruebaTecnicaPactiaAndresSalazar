using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPactia.Entities.Response
{
    public class TokenResponse
    {
        public string token { get; set; }
        public DateTime expires { get; set; }
        public string login { get; set; }
        public string FullName { get; set; }
        public string idUser { get; set; }
    }
}
