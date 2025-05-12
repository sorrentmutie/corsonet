namespace FirstDemo.API.Extensions
{
    public static class AppExtensions
    {

        public static void RegistrazioneEndpoints(this WebApplication app)
        {
            app.RegistrazioneCategorie();

            app.RegistrazioneProdotti();

            app.RegistrazioneSuppliers();

            app.RegistrazioneEmployees();
        }

    }
}
