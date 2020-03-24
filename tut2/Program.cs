using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using tut2.models;

namespace tut2
{
    class Program
    {
        private static string m_csvPath;
        private static string m_destinationPath;
        private static string m_format;

        private static ErrorLogger m_logger = new ErrorLogger(@"logs\log.txt");
        private static HashSet<Student> m_students = new HashSet<Student>(new StudentComparer());
        private static List<Studies> m_activeStudies = new List<Studies>();

        static void Main(string[] args)
        {
            /* Get command line arguments */
            m_csvPath = args[0];
            m_destinationPath = args[1];
            m_format = args[2];

            if (!m_format.Equals("xml") && !m_format.Equals("json"))
            {
                string message = "FATAL ERROR: Argument Exception -> Invalid format argument.";
                m_logger.PrintMessage(message);
                Console.Error.WriteLine(message);
                Environment.Exit(-1);
            }

            /* Parse .csv file */
            var info = new FileInfo(m_csvPath);

            if (!info.Exists)
            {
                string message = "FATAL ERROR: Argument Exception -> .csv file provided does not exist.";
                m_logger.PrintMessage(message);
                Console.Error.WriteLine(message);
                Environment.Exit(-1);
            }

            using (var reader = new StreamReader(info.OpenRead()))
            {
                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    
                    /* Create instance of student */
                    Student student = new Student(
                        data[0],
                        data[1],
                        data[2],
                        data[3],
                        data[4],
                        data[5],
                        data[6],
                        data[7],
                        data[8]
                    );

                    /* Check if the line contains invalid data */
                    bool valid = true;
                    foreach (string str in data)
                    {
                        if (str.Equals(string.Empty))
                        {
                            m_logger.PrintMessage("Student with invalid data found -> " + student);
                            valid = false;
                            break;
                        }
                    }

                    /* Add student to the set */
                    if (valid)
                    {
                        if (!m_students.Add(student))
                        {
                            m_logger.PrintMessage("Duplicate found -> " + student);
                        }
                        else
                        {
                            /* Add data about studies */
                            Studies studies = m_activeStudies.Find(e => e.Name.Equals(student.StudiesData.Name));

                            if (studies != null)
                                studies++;
                            else
                                m_activeStudies.Add(new Studies(student.StudiesData.Name));
                        }
                    }
                }
            }

            /* Write to .xml file */
            if (m_format.Equals("xml"))
            {
                Document document = new Document(m_students, m_activeStudies);

                var writer = new FileStream(m_destinationPath, FileMode.Create);
                var serializer = new XmlSerializer(typeof(Document), new XmlRootAttribute("university"));
                serializer.Serialize(writer, document);
            }
        }
    }
}
