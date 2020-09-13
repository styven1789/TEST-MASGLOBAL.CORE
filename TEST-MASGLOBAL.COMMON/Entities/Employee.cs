namespace TEST_MASGLOBAL.COMMON.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        protected Employee(decimal salary)
        {
            GetSalary(salary);
        }

        //Factory method
        public abstract void GetSalary(decimal salary);

        public decimal Salary { get; }
    }
}
