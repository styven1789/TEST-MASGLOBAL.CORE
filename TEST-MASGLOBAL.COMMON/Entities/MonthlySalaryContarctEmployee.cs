namespace TEST_MASGLOBAL.COMMON.Entities
{
    public class MonthlySalaryContarctEmployee : Employee
    {
        public MonthlySalaryContarctEmployee(decimal salary) : base(salary)
        {
        }

        public override void GetSalary(decimal salary)
        {
            Salary = salary * 12;
        }
    }
}
