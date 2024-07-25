using GraphApplication.Controllers;
using GraphQL.Types;

namespace GraphApplication
{
    public class AppSchema: Schema
    {
        public AppSchema(EmployeeQuery query) {
        this.Query = query;
        }
    }
}
