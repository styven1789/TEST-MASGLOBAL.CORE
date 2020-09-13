namespace TEST_MASGLOBAL.BLL.EmployeeBLL
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.COMMON.Entities;
    using TEST_MASGLOBAL.DAL.EmployeeRepository;
    using TEST_MASGLOBAL.DAL.Models;

    public class EmployeeBll : IEmployeeBll
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBll(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            try
            {
                var emp = await _employeeRepository.GetById(id);
                if (emp != null)
                {
                    return GetEmployee(emp);
                }
                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetAll();
                List<EmployeeModel> lstEmployee = new List<EmployeeModel>();

                //Loop every employee to instantiate with factory and calculate anual salary
                foreach (var emp in employees)
                    lstEmployee.Add(GetEmployee(emp));

                return lstEmployee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static EmployeeModel GetEmployee(EmployeeModel objEmployee)
        {
            switch (objEmployee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    var hourlySalaryEmployee = new HourlySalaryContractEmployee(objEmployee.HourlySalary);
                    objEmployee.YearSalary = hourlySalaryEmployee.Salary;
                    break;
                case "MonthlySalaryEmployee":
                    var monthlySalaryEmployee = new MonthlySalaryContarctEmployee(objEmployee.MonthlySalary);
                    objEmployee.YearSalary = monthlySalaryEmployee.Salary;
                    break;
            }

            return objEmployee;
        }
    }
}
