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
            File.WriteAllLines("dictionary.txt", output);
        }

        private static List<string> readFile()
        {
            List<string> values = new List<string>();
            //Open file picker

            //Read file

            //Text to list string

            //Return list
            return values;
        }
    }
}
