using System;
using System.Collections.Generic;
using System.Text;
using tut2.models;

namespace tut2
{
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student s1, Student s2)
        {
            bool indexCollision = StringComparer.InvariantCultureIgnoreCase.Equals(s1.IndexNumber, s2.IndexNumber);
            bool emailCollision = StringComparer.InvariantCultureIgnoreCase.Equals(s1.Email, s2.Email);

            return indexCollision || emailCollision;
        }

        public int GetHashCode(Student s)
        {
            return StringComparer
                    .CurrentCultureIgnoreCase
                    .GetHashCode($"{s.IndexNumber} {s.Email}");
        }
    }
}
