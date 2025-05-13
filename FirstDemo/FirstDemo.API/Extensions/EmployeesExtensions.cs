using FirstDemo.UI.Kit.DataTypes;
using System.Linq;

namespace FirstDemo.API.Extensions
{
    public static class EmployeesExtensions
    {
        public static Expression<Func<Employee, bool>>? FilterEmployee(string filterText)
        {
            return x => x.FirstName.Contains(filterText) || x.LastName.Contains(filterText);
        }


        public static void RegistrazioneEmployees(this WebApplication app)
        {
            var employeesGroup = app.MapGroup("/employees");
            employeesGroup.MapGet("/", EmployeesEndpoints.Estrai);
            employeesGroup.MapGet("/{id}", EmployeesEndpoints.EstraiById);
        }

    }

    public static class EmployeesEndpoints
    {
        public static async Task<IResult> EstraiById(int id, NorthwindContext db)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return Results.NotFound();
            }
            else
            {
                var i = new Impiegato()
                {
                    Id = employee.EmployeeId,
                    Nome = employee.FirstName,
                    Cognome = employee.LastName
                };
                return Results.Ok(i);

            }
        }
        public static async Task<IResult> Estrai([AsParameters] PageParameters pageParameters, NorthwindContext db, IConfiguration configuration)
        {
            int pageSize = 1;
            int pageCount = 1;
            var results = db.Employees.AsQueryable();
            int itemsCount = 0;
            if (configuration != null)
            {
                pageSize = configuration.GetValue<int>("ApiParameters:PageSize");
            }

            if (!string.IsNullOrEmpty(pageParameters.FilterText))
            {
                var predicate = EmployeesExtensions.FilterEmployee(pageParameters.FilterText);
                if (predicate != null)
                {
                    results = results.Where(predicate);
                }
                itemsCount = results.Count();
                pageCount = (itemsCount + pageSize - 1) / pageSize;
                if (pageParameters.PageNumber > pageCount)
                {
                    pageParameters.PageNumber = pageCount;
                }
                if (!string.IsNullOrEmpty(pageParameters.SortBy))
                {
                    if (pageParameters.SortDirection == SortDirection.Ascending)
                    {
                        results = results.OrderBy(x => EF.Property<object>(x, pageParameters.SortBy));
                    }
                    else
                    {
                        results = results.OrderByDescending(x => EF.Property<object>(x, pageParameters.SortBy));
                    }
                }

            }
            var page = new Page<Impiegato>
            {
                CurrentPage = pageParameters.PageNumber,
                PageCount = pageCount,
                ItemCount = itemsCount,
                SortDirection = pageParameters.SortDirection ?? SortDirection.Ascending,
                SortBy = pageParameters.SortBy,
                Items = await results
              .Skip((pageParameters.PageNumber - 1) * pageSize)
              .Take(pageSize)
              .Select(p => new Impiegato
              {
                  Id = p.EmployeeId,
                  Nome = p.FirstName,
                  Cognome = p.LastName
              }).ToListAsync()
            };
            return Results.Ok(page);
        }
    }
}
