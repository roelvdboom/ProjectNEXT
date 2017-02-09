using PerzonalizedDictionary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerzonalizedDictionary.Controllers
{
    public class PasswordGenerator
    {
        #region Singleton
        public static PasswordGenerator Instance = null;

        public static PasswordGenerator GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PasswordGenerator();
            }
            return Instance;
        }

        private PasswordGenerator()
        {
            input = new List<string>();
        }
        #endregion

        private List<string> input;

        public List<string> GeneratePasswords(Person person)
        {
            GetDataFromPerson(person);
            List<string> output = new List<string>();

            int y = input.Count - 1;
            for (int i = 0; i < input.Count; i++)
            {
                for (int x = 0; x < input.Count; x++)
                {
                    string s = input[i] + input[x];
                    output.Add(s);
                    string exp =   s + "!";
                    output.Add(exp);
                    string lower = s.ToLower();
                    output.Add(lower);
                    string titlecase = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lower);
                    output.Add(titlecase);
                    string titlewithexp = titlecase + "!";
                    output.Add(titlewithexp);
                    
                }
            }

            output = output.Distinct().ToList();
            output.Sort();
            return output;
        }

        private void GetDataFromPerson(Person person)
        {
            input = new List<string>();

            AddToList(person.FirstName);
            AddToList(person.Preposition);
            AddToList(person.SurName);

            if (person.BirthDate != null)
            {
                AddToList(person.BirthDate.Value.Day.ToString("D2") + person.BirthDate.Value.Month.ToString("D2") + person.BirthDate.Value.Year);
                AddToList(person.BirthDate.Value.Day.ToString("D2"));
                AddToList(person.BirthDate.Value.Month.ToString("D2"));
                AddToList(person.BirthDate.Value.Year.ToString());
            }

            AddToList(person.Address?.City);
            AddToList(person.Address?.Street);
            AddToList(person.Address?.Number.ToString());
            AddToList(person.Address?.Extra);
        }

        private void AddToList(string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                input.Add(s);
            }
        }
    }
}
