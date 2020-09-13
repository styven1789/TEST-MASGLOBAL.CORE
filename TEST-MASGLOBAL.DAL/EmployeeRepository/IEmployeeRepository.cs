namespace TEST_MASGLOBAL.DAL.EmployeeRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.DAL.Models;

    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get all employees from service
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeModel>> GetAll();

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeModel> GetById(int id);
    }
}
