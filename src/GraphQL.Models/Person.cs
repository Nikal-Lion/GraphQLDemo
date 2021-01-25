using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Models
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name, string email)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
        }
        public Person AddParent(Person parents)
        {
            var persons = this.Parents.ToList();
            persons.Add(parents);
            this.Parents = persons;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Person> Parents { get; set; } = new List<Person>();
    }
}
