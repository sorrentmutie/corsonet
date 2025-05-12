namespace FirstDemo.BLazor.Server.Extensions;

public static class BusinessServiceCollection
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {

        services.AddScoped<ICategorie, ServizioCategorie>();

        services.AddScoped
            <IDataServices<ProdottoListitem, ProdottoDetails, int>,
             ProdottoDataService<ProdottoListitem, ProdottoDetails>>();

        services.AddScoped
            <IDataServices<CustomerListItem, CustomerDetail, string>,
             CustomersDataService<CustomerListItem, CustomerDetail>>();

        services.AddScoped<IDatiMappa, GestioneMappe>();

        services.AddScoped<IConferenze, GestoreConferenze>();
        services.AddScoped<ITrasformazioneTesto, UppercaseTransformation>();

        services.AddScoped<IServizioDettagliOrdini, ServizioDettagliOrdini>();

        services.AddScoped<IDashboardData, DashboardDataService>();

        services.AddScoped<IServizioAPIFornitori, ServizioAPIFornitori>();
        services.AddScoped<IServizioAPIImpiegati, ServizioAPIIMpiegati>();

        return services;
    }
}
