using GraphQL.Interfaces;
using GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository()
        {

        }
        /*
         * rick, jerry, bess, summer, morty 
         */
        private static readonly Person rick = new Person(name: "Rick", email: "Rick@rick.morty");
        private static readonly Person bess = new Person(name: "Bess", email: "Bess@rick.morty").AddParent(rick);
        private static readonly Person jerry = new Person(name: "Jerry", email: "Jerry@rick.morty");
        private static readonly Person summer = new Person(name: "Summer", email: "Summer@rick.morty").AddParent(rick).AddParent(jerry).AddParent(bess);
        private static readonly Person morty = new Person(name: "Morty", email: "Morty@rick.morty").AddParent(rick).AddParent(jerry).AddParent(bess);

        private readonly IEnumerable<Person> persons = new List<Person>
        {
            rick,jerry, bess, summer, morty
        };
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAll()
        {
            return this.persons;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetById(Guid id)
        {
            return this.persons.SingleOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetByEmail(string email)
        {
            return this.persons.SingleOrDefault(x => x.Email == email);
        }
    }
}
