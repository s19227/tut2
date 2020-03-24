using System;
using System.Collections.Generic;
using System.Text;
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
            NumberOfStudies = 1;
        }

        [XmlAttribute(attributeName: "name")]
        public string Name { get; set; }
        [XmlAttribute(attributeName: "numberOfStudies")]
        public int NumberOfStudies { get; set; }

        public static Studies operator++(Studies s)
        {
            s.NumberOfStudies++;
            return s;
        }
    }
}
