using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using tut2.models;

namespace tut2
{
    public class Document
    {
        public Document() { }

        public Document(HashSet<Student> students, List<Studies> activeStudies)
        {
            Students = students;
            ActiveStudies = activeStudies;

            DateTime dateTime = DateTime.UtcNow.Date;
            CreatedAt = dateTime.ToString("dd.MM.yyyy");

            Author = "Max Malashev";
        }

        [XmlAttribute(attributeName: "createdAt")][JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [XmlAttribute(attributeName: "author")][JsonPropertyName("author")]
        public string Author { get; set; }

        [XmlArray(elementName: "students")][JsonPropertyName("students")]
        public HashSet<Student> Students { get; set; }

        [XmlArray(elementName: "activeStudies")][JsonPropertyName("activeStudies")]
        public List<Studies> ActiveStudies { get; set; }
    }
}
