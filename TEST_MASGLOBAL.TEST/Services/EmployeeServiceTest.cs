namespace TEST_MASGLOBAL.TEST.Services
{
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.BLL.EmployeeBLL;
    using TEST_MASGLOBAL.DAL.EmployeeRepository;
    using TEST_MASGLOBAL.DAL.Models;

    public class EmployeeServiceTest
    {
        #region Attributes

        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        #endregion Attributes

        #region Builder

        public EmployeeServiceTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
        }

        #endregion Builder

        #region Methods

        [Test]
        public async Task GetEmployees()
        {
            //Arrange

            List<EmployeeModel> employees = new List<EmployeeModel>()
                {
                    new EmployeeModel()
                    {

                        Id = 10,
                        Name = "Employee one",
                        RoleId = 1,
                        ContractTypeName = "HourlySalaryEmployee",
                        HourlySalary = 16000
                    },
                    new EmployeeModel()
                    {
                        Id = 20,
                        Name = "Employee two",
                        RoleId = 1,
                        ContractTypeName = "MonthlySalaryEmployee",
                        MonthlySalary = 400000
                    }
                };

            decimal expectedAnualSalary1 = 23040000;
            decimal expectedAnualSalary2 = 4800000;

            //Act
            _mockEmployeeRepository.Setup(c => c.GetAll()).ReturnsAsync(() => employees);

            EmployeeBll service = new EmployeeBll(_mockEmployeeRepository.Object);

            IEnumerable<EmployeeModel> result = await service.GetEmployees();

            //Assert
            
            Assert.AreEqual(result.ToList()[0].YearSalary, expectedAnualSalary1);
            Assert.AreEqual(result.ToList()[1].YearSalary, expectedAnualSalary2);
        }

        [Test]
        public async Task GetEmployeeById()
        {
            //Arrange

            EmployeeModel employee = new EmployeeModel()
            {

                Id = 10,
                Name = "Employee one",
                RoleId = 1,
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 16000
            };

            decimal expectedAnualSalary = 23040000;

            //Act
            _mockEmployeeRepository.Setup(c => c.GetById(10)).ReturnsAsync(() => employee);

            EmployeeBll service = new EmployeeBll(_mockEmployeeRepository.Object);

            EmployeeModel result = await service.GetEmployeeById(10);

            //Assert
            
            Assert.AreEqual(result.YearSalary, expectedAnualSalary);
        }

        #endregion Methods
    }
}
