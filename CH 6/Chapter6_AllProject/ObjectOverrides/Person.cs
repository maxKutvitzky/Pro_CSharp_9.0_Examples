using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    // Remember! Person extends Object.
    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; } = "";
        public Person(string fName, string lName, int personAge, string ssn)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
            SSN = ssn;
        }
        public Person() { }
        public override string ToString() => $"[First Name: {FirstName}; Last Name: {LastName}; Age:{Age}]";
        public override bool Equals(object obj)
        {
            if (!(obj is Person temp))
            {
                return false;
            }
            if (temp.FirstName == this.FirstName
            && temp.LastName == this.LastName
            && temp.Age == this.Age)
            {
                return true;
            }
            return false;
        }
        // Если правильно написан ToString, то Equals можно переопределить так:
        // public override bool Equals(object obj) => obj?.ToString() == ToString();

        // Return a hash code based on unique string data.
        public override int GetHashCode() => SSN.GetHashCode();

        // Если нет уникального поля для хэш-кода, то можно исплользовать это:
        // Return a hash code based on the person's ToString() value.
        // public override int GetHashCode() => ToString().GetHashCode();
    }
}
