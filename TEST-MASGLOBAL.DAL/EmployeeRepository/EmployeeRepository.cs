namespace TEST_MASGLOBAL.DAL.EmployeeRepository
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using TEST_MASGLOBAL.DAL.Models;

    public class EmployeeRepository : IEmployeeRepository
    {
        #region Attributes

        private readonly IConfiguration configuration;

        #endregion Attributes

        #region Builder

        public EmployeeRepository(IConfiguration iconfiguration)
        {
            this.configuration = iconfiguration;
        }

        #endregion Builder 

        #region Public Methods

        /// <summary>
        /// Get all employees from service
        /// </summary>
        /// <returns></returns>
        public Task<List<EmployeeModel>> GetAll()
        {
            return GetAllEmployeesFromService();
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeModel> GetById(int id)
        {
            IEnumerable<EmployeeModel> employees = await GetAllEmployeesFromService();
            return employees.FirstOrDefault(x => x.Id == id);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<List<EmployeeModel>> GetAllEmployeesFromService()
        {
            IConfiguration conf = configuration.GetSection("EmployeesService");
            string url = conf.GetSection("Url").Value;

            var employees = new List<EmployeeModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Employees/");
                if (response.IsSuccessStatusCode)
                {
                    var EmployeeResponse = response.Content.ReadAsStringAsync().Result;
                    employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(EmployeeResponse);
                }
            }
            return employees;
        }

        #endregion Private Methods
    }
}
