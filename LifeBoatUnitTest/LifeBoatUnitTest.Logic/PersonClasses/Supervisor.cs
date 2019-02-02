using System.Collections.Generic;

namespace LifeBoatUnitTest.Logic.PersonClasses
{
    public class Supervisor : Person
    {
        public IList<Employee> Employees { get; set; }
    }
}
