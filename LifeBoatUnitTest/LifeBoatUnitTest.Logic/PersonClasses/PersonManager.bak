using System.Collections;
using System.Collections.Generic;

namespace LifeBoatUnitTest.Logic.PersonClasses
{
    public class PersonManager : Person
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person person = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    person = new Supervisor();
                }
                else
                {
                    person = new Employee();
                }

                person.FirstName = first;
                person.LastName = last;
            }

            return person;
        }

        public List<Person> GetPeople()
        {
            var persons = new List<Person>();

            persons.Add(new Person { FirstName = "Igor1", LastName = "Gomes" });
            persons.Add(new Person { FirstName = "Igor2", LastName = "Gomes" });
            persons.Add(new Person { FirstName = "Igor3", LastName = "Gomes" });

            return persons;
        }

        public List<Person> GetSupervisors()
        {
            var persons = new List<Person>();

            persons.Add(CreatePerson("Igor1", "Gomes", true));
            persons.Add(CreatePerson("Igor2", "Gomes", true));

            return persons;
        }
    }
}
