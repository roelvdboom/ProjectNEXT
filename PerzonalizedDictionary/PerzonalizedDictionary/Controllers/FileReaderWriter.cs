using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerzonalizedDictionary.Controllers
{
    public class FileReaderWriter
    {
        public static void WriteFile(List<string> output)
        {
            output.AddRange(readFile());
            string fileName = DateTime.Now.Day.ToString("D2") + "-" +
                DateTime.Now.Month.ToString("D2") + "-" +
                DateTime.Now.Year.ToString() + " " +
                DateTime.Now.Hour.ToString("D2") + "" +
                DateTime.Now.Minute.ToString("D2") + "" +
                DateTime.Now.Millisecond.ToString("D2") +
                ";dictionary.txt";
            File.WriteAllLines(fileName, output);
        }

        public static List<string> readFile()
        {
            //Read file
            try
            {
               return File.ReadAllLines("test1M.txt").ToList();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            //Return list
            return new List<string>();
        }
    }
}
