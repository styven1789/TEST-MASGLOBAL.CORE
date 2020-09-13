using Microsoft.Extensions.DependencyInjection;
using TEST_MASGLOBAL.BLL.EmployeeBLL;
using TEST_MASGLOBAL.DAL.EmployeeRepository;

namespace TEST_MASGLOBAL.Handlers
{
    public class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            #region Register (dependency injection)            

            //// Domain
            services.AddScoped<IEmployeeBll, EmployeeBll>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();





            #endregion
        }
    }
}
