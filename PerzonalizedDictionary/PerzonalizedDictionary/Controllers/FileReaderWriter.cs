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
            File.WriteAllLines("dictionary.txt", output);
        }

        public static List<string> readFile()
        {
            //Read file
            try
            {
               return File.ReadAllLines("test.txt").ToList();
            }
            catch(Exception ex)
            {

            }
            
            //Return list
            return new List<string>();
        }
    }
}
