namespace TEST_MASGLOBAL.COMMON.Entities
{
    public class HourlySalaryContractEmployee : Employee
    {
        public HourlySalaryContractEmployee(decimal salary) : base(salary)
        {
        }

        public override void GetSalary(decimal salary)
        {
            Salary = salary * 120 * 12;
        }
    }
}
