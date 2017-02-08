using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerzonalizedDictionary.Controllers
{
    public class PasswordGenerator
    {
        public static List<string> GeneratePasswords(List<string> input)
        {
            List<string> output = new List<string>();

            int y = input.Count - 1;
            for (int i = 0; i < input.Count; i++)
            {
                for (int x = 0; x < input.Count; x++)
                {
                    string s = input[i] + input[x];
                    output.Add(s);
                }
            }


            output.AddRange(FileReaderWriter.readFile());
            output.Sort();
            return output;
        }
    }
}
