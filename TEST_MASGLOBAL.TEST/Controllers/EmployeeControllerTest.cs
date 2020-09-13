namespace TEST_MASGLOBAL.TEST.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.BLL.EmployeeBLL;
    using TEST_MASGLOBAL.Controllers;
    using TEST_MASGLOBAL.DAL.Models;

    public class EmployeeControllerTest
    {
        #region Attributes

        private Mock<IEmployeeBll> _IEmployeeBllMock;

        private EmployeeController _EmployeeController;

        #endregion Attributes

        #region Builder

        public EmployeeControllerTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEmployeeBll, EmployeeBll>();

            Init();
        }

        #endregion Builder

        #region Init

        public void Init()
        {
            _IEmployeeBllMock = new Mock<IEmployeeBll>();            

            _EmployeeController = new EmployeeController(_IEmployeeBllMock.Object);
        }

        #endregion Init

        #region Methods

        [Test]
        public void GetTest()
        {
            _IEmployeeBllMock.Setup(x => x.GetEmployees())
                .ReturnsAsync(new List<EmployeeModel>());
            Task<IActionResult> result = _EmployeeController.Get();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetByIdTest()
        {
            _IEmployeeBllMock.Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .ReturnsAsync(new EmployeeModel());
            Task<IActionResult> result = _EmployeeController.Get(It.IsAny<int>());
            Assert.IsNotNull(result);
        }

        #endregion Methods
    }
}
