using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace tut2.models
{
    [XmlType("studies")]
    public class Studies
    {
        public Studies() { }

        public Studies(string name)
        {
            Name = name;
            NumberOfStudents = 1;
        }

        [XmlAttribute(attributeName: "name")][JsonPropertyName("name")]
        public string Name { get; set; }
        [XmlAttribute(attributeName: "numberOfStudents")][JsonPropertyName("numberOfStudents")]
        public int NumberOfStudents { get; set; }

        public static Studies operator++(Studies s)
        {
            s.NumberOfStudents++;
            return s;
        }
    }
}
