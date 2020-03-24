using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tut2
{
    class ErrorLogger
    {
        private readonly string m_destinationPath;

        public ErrorLogger(string destinationPath)
        {
            m_destinationPath = destinationPath;

            if (File.Exists(m_destinationPath)) 
                File.Delete(m_destinationPath);
        }

        public void PrintMessage(string message)
        {
            using (var writer = new StreamWriter(m_destinationPath, true))
                writer.WriteLine(message);
        }
    }
}
