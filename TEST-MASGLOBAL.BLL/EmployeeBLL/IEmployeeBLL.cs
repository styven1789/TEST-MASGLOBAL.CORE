namespace TEST_MASGLOBAL.BLL.EmployeeBLL
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.DAL.Models;

    public interface IEmployeeBll
    {
        Task<List<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
    }
}
