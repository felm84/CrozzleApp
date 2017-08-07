using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrozzleApp.Classes
{
    class Log
    {
        List<string> logs = new List<string>();

        DateTime now = DateTime.Now;

        public Log()
        {         
            using (StreamWriter writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine("\n********************************");
                writer.WriteLine("Log Data : {0}", now);
            }
        }

    }
}
