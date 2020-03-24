using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace tut2.models
{
    [XmlType("student")]
    public class Student
    {
        public Student() { }

        public Student(
            string firstName,
            string lastName,
            string studiesName,
            string studiesMode,
            string indexNumber,
            string birthdate,
            string email,
            string mothersName,
            string fathersName
        )
        {
            IndexNumber = indexNumber;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Email = email;
            MothersName = mothersName;
            FathersName = fathersName;

            StudiesData = new StudiesInfo(studiesName, studiesMode);
        }


        [XmlAttribute(attributeName: "index")]
        public string IndexNumber { get; set; }
        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }
        [XmlElement(elementName: "lname")]
        public string LastName { get; set; }

        private string m_birthdate;
        [XmlElement(elementName: "birthdate")]
        public string Birthdate 
        {
            get
            {
                return m_birthdate;
            }

            set
            {
                var date = DateTime.Parse(value);
                m_birthdate = date.ToString("dd.MM.yyyy");
            }
        }

        [XmlElement(elementName: "email")]
        public string Email { get; set; }
        [XmlElement(elementName: "mothersName")]
        public string MothersName { get; set; }
        [XmlElement(elementName: "fathersName")]
        public string FathersName { get; set; }
        [XmlElement(elementName: "studies")]
        public StudiesInfo StudiesData { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {StudiesData.Name} {StudiesData.Mode} {IndexNumber} {Birthdate} {Email} {MothersName} {FathersName}";
        }

        public struct StudiesInfo
        {
            public StudiesInfo(string name, string mode)
            {
                Name = name;
                Mode = mode;
            }

            [XmlElement(elementName: "name")]
            public string Name { get; set; }
            [XmlElement(elementName: "mode")]
            public string Mode { get; set; }
        }
    }
}
