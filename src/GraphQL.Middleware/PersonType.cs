using GraphQL.Models;
using GraphQL.Types;

namespace GraphQL.Middleware
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field<ListGraphType<PersonType>>(nameof(Person.Parents));
        }
    }
}