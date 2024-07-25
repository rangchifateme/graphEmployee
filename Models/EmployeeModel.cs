using GraphQL.Types;

namespace GraphApplication.Models
{
    public record Employee(int Id, string Name, int Age, int DeptId);

    public record Department(int Id, string Name);

    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DeptName { get; set; }
    }

    public class EmployeeDetailsType : ObjectGraphType<EmployeeDetails>
    {
        public EmployeeDetailsType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Age, type: typeof(IntGraphType));
            Field(x => x.DeptName,type: typeof(StringGraphType));
        }
    }
    public class EmployeeModel
    {
    }
}
