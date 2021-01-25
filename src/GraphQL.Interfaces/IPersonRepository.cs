using GraphQL.Models;
using System;
using System.Collections.Generic;

namespace GraphQL.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetByEmail(string email);
        Person GetById(Guid id);
    }
}
