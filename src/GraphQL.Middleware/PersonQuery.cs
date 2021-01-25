using GraphQL.Interfaces;
using GraphQL.Models;
using GraphQL.Types;
using System;

namespace GraphQL.Middleware
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = nameof(Person.Id) }, new QueryArgument<GuidGraphType> { Name = nameof(Person.Email) }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid?>("id");
                    var email = context.GetArgument<string>("email");
                    return id != null ? personRepository.GetById(id.Value) : personRepository.GetByEmail(email);
                });

            Field<ListGraphType<PersonType>>("persons",
                resolve: context =>
                {
                    return personRepository.GetAll();
                });
        }

    }
}