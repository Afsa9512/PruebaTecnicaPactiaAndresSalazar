namespace PruebaPactia.Utility
{
    public class Utilidades
    {
        public static List<string> GetNotFoundListError() => new() { Constantes.NotFound };
    }

    public class Constantes
    {
        public const string NotFound = "No se encontraron registros.";
    }
}
