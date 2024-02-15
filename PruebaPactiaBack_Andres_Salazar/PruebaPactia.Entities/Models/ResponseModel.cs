namespace PruebaPactia.Entities.Models
{
    public class ResponseModel
    {
        public bool response { get; set; }
        public string message { get; set; }
        public dynamic result { get; set; }
        public string href { get; set; }

        public ResponseModel()
        {
            response = false;
            message = "Ocurrio un error inesperado";
        }
    }
}
