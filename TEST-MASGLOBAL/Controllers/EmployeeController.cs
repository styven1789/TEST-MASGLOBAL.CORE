namespace TEST_MASGLOBAL.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.BLL.EmployeeBLL;
    using TEST_MASGLOBAL.DAL.Models;
    using TEST_MASGLOBAL.Models;

    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Attributes

        private readonly IEmployeeBll _emloyeeBll;

        #endregion Attributes

        #region Constructor

        /// <inheritdoc />
        public EmployeeController(IEmployeeBll employeeBll)
        {
            this._emloyeeBll = employeeBll;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Get stamp request names
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseModel<IEnumerable<EmployeeModel>> oResponse;

            IEnumerable<EmployeeModel> oResult = await _emloyeeBll.GetEmployees();

            bool oData = oResult.Any();

            oResponse = new ResponseModel<IEnumerable<EmployeeModel>>()
            {
                IsSuccess = oData,
                Messages = string.Empty,
                Result = oData ? oResult : null
            };

            return Ok(oResponse);
        }

        /// <summary>
        /// Get stamp request names
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseModel<EmployeeModel> oResponse;

            EmployeeModel oResult = await _emloyeeBll.GetEmployeeById(id);

            oResponse = new ResponseModel<EmployeeModel>()
            {
                IsSuccess = true,
                Messages = string.Empty,
                Result = oResult
            };

            return Ok(oResponse);
        }

        #endregion Methods
    }
}
