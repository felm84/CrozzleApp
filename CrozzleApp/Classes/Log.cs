using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrozzleApp.Classes
{
    static class Log
    {
        // In case file has no address from LOGFILE_NAME
        public static string file = "log.txt";

        public static List<string> logs = new List<string>();

        public static DateTime now;

        //public static string currentFile;

        public static void WriteLogs()
        {
            now = DateTime.Now;
            using (StreamWriter writer = File.AppendText(file))
            {
                writer.WriteLine("\n********************************");
                writer.WriteLine("Log Data : {0}", now);
                writer.WriteLine("********************************");
                foreach (string log in logs)
                {
                    writer.WriteLine(log);
                }
            }
        }

    }
}
