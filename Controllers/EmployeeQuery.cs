using GraphApplication.Models;
using GraphApplication.Services.Interface;
using GraphQL;
using GraphQL.Types;
using System.Xml.Linq;

namespace GraphApplication.Controllers
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService employeeService)
        {
            Field<ListGraphType<EmployeeDetailsType>>(
                Name = "Employees",
                "Gets all employees",
                resolve: x => employeeService.GetEmployees());

            //Field<ListGraphType>(
            //    Name = "Department",
            //    "Gets all departments",
            //    resolve: x => new string [] { "dep1", "dep2"});

            Field<ListGraphType<EmployeeDetailsType>>(
                Name = "Employee",
                "Gets a single employee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "empId" }),
                resolve: x => employeeService.GetEmployee(x.GetArgument<int>("empId", int.MinValue)));


        }
    }

    public class EmployeeDetailsSchema : Schema
    {
        public EmployeeDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<EmployeeQuery>();
        }
    }
}
