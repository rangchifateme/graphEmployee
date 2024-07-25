using GraphApplication.Models;
using GraphApplication.Services.Interface;
using GraphApplication.Services;
using GraphQL.Types;
using GraphQL;
using GraphApplication.Controllers;
using GraphApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<EmployeeDetailsType>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddSingleton<ISchema, EmployeeDetailsSchema>();
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<EmployeeQuery>()  // schema
    .AddSystemTextJson());   // serializer

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseGraphQL<AppSchema>();            // url to host GraphQL endpoint
    app.UseGraphQLGraphiQL("/ui/graphql");
    app.UseGraphQLPlayground(
        "/",                               // url to host Playground at
        new GraphQL.Server.Ui.Playground.PlaygroundOptions
        {
            GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
            SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
        });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
