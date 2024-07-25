using GraphApplication.Models;

namespace GraphApplication.Services.Interface
{
    public interface IEmployeeService
    {
        public List<EmployeeDetails> GetEmployees();

        public List<EmployeeDetails> GetEmployee(int empId);

        public List<EmployeeDetails> GetEmployeesByDepartment(int deptId);
    }
}
