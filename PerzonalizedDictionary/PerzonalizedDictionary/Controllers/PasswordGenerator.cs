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
                    string firstWord = input[i];
                    string secondWord = input[x];

                    output.AddRange(CombineWords(firstWord, secondWord));
                    output.AddRange(CombineWithUnderscore(firstWord, secondWord));
                    output.AddRange(CombineWithLine(firstWord, secondWord));

                    //string s = firstWord + secondWord;
                    //output.Add(s);
                    //string exp =   s + "!";
                    //output.Add(exp);
                    //string lower = s.ToLower();
                    //output.Add(lower);
                    //string titlecase = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lower);
                    //output.Add(titlecase);
                    //string titlewithexp = titlecase + "!";
                    //output.Add(titlewithexp);
                    
                }
            }
            List<string> ltn = ReplaceLettersWithNumbers(output);
            List<string> ntl = ReplaceNumbersWithLetters(output);
            output.AddRange(ltn);
            output.AddRange(ntl);

            output.AddRange(AddSymbols(output));

            output = output.Distinct().ToList();
            output.Sort();
            return output;
        }

        private void GetDataFromPerson(Person person)
        {
            input = new List<string>();

            AddToList(person.FirstName);
            if (!string.IsNullOrWhiteSpace(person.Preposition))
            {
                AddToList(person.Preposition.Split(' ').ToList());
            }
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
            if (!string.IsNullOrWhiteSpace(person.Address?.Extra))
            {
                AddToList(person.Address?.Extra.Split(' ').ToList());
            }
        }

        private void AddToList(string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                input.Add(s);
            }
        }

        private void AddToList(List<string> strings)
        {
            foreach(string s in strings)
            {
                AddToList(s);
            }
        }

        private List<string> CombineWords(string first, string second)
        {
            List<string> values = new List<string>();
            values.Add(first + second);
            values.Add(first.ToLower() + second.ToLower());
            values.Add(first.ToUpper() + second.ToUpper());
            return values;
        }

        private List<string> CombineWithUnderscore(string first, string second)
        {
            List<string> values = new List<string>();
            values.Add(first.ToLower() + "_" + second.ToLower());
            values.Add(first + "_" + second);
            values.Add(first.ToUpper() + "_" + second.ToUpper());
            values.Add(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(first.ToLower() + "_" + second.ToLower()));
            return values;
        }
        
        private List<string> CombineWithLine(string first, string second)
        {
            List<string> values = new List<string>();
            values.Add(first.ToLower() + "-" + second.ToLower());
            values.Add(first + "-" + second);
            values.Add(first.ToUpper() + "-" + second.ToUpper());
            values.Add(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(first.ToLower() + "-" + second.ToLower()));
            return values;
        }   

        private List<string> ReplaceLettersWithNumbers(List<string> values)
        {
            List<string> newValues = new List<string>();
            foreach(string s in values)
            {
                string newString = s;
                if (newString.Contains("e") || newString.Contains("E"))
                {
                    newValues.Add(newString.Replace("e", "3"));
                    newValues.Add(newString.Replace("E", "3"));
                }

                if (newString.Contains("a") || newString.Contains("A"))
                {
                    newValues.Add(newString.Replace("a", "4"));
                    newValues.Add(newString.Replace("A", "4"));
                    newValues.Add(newString.Replace("a", "@"));
                    newValues.Add(newString.Replace("A", "@"));
                }

                if (newString.Contains("b") || newString.Contains("B"))
                {
                    newValues.Add(newString.Replace("b", "8"));
                    newValues.Add(newString.Replace("B", "8"));
                }


                if (newString.Contains("o") || newString.Contains("O"))
                {
                    newValues.Add(newString.Replace("o", "0"));
                    newValues.Add(newString.Replace("O", "0"));
                }

                if (newString.Contains("i") || newString.Contains("I"))
                {
                    newValues.Add(newString.Replace("i", "1"));
                    newValues.Add(newString.Replace("I", "1"));
                }

                if (newString.Contains("t") || newString.Contains("T"))
                {
                    newValues.Add(newString.Replace("t", "7"));
                    newValues.Add(newString.Replace("T", "7"));
                }

                if (newString.Contains("s") || newString.Contains("S"))
                {
                    newValues.Add(newString.Replace("s", "5"));
                    newValues.Add(newString.Replace("S", "5"));
                }

                if (newString.Contains("z") || newString.Contains("Z"))
                {
                    newValues.Add(newString.Replace("z", "2"));
                    newValues.Add(newString.Replace("Z", "2"));
                }

                if (newString.Contains("g") || newString.Contains("G"))
                {
                    newValues.Add(newString.Replace("g", "9"));
                    newValues.Add(newString.Replace("G", "9"));
                }

            }
            return newValues;
        }

        private List<string> ReplaceNumbersWithLetters(List<string> values)
        {
            List<string> newValues = new List<string>();
            foreach (string s in values)
            {
                string newString = s;
                if (newString.Contains("3"))
                {
                    newValues.Add(newString.Replace("3", "e"));
                    newValues.Add(newString.Replace("3", "E"));
                }

                if (newString.Contains("4"))
                {
                    newValues.Add(newString.Replace("4", "a"));
                    newValues.Add(newString.Replace("4", "A"));

                }

                if (newString.Contains("8"))
                {
                    newValues.Add(newString.Replace("8", "b"));
                    newValues.Add(newString.Replace("8", "B"));
                }


                if (newString.Contains("0"))
                {
                    newValues.Add(newString.Replace("0", "o"));
                    newValues.Add(newString.Replace("0", "O"));
                }

                if (newString.Contains("1"))
                {
                    newValues.Add(newString.Replace("1", "i"));
                    newValues.Add(newString.Replace("1", "I"));
                }

                if (newString.Contains("7"))
                {
                    newValues.Add(newString.Replace("7", "t"));
                    newValues.Add(newString.Replace("7", "T"));
                }

                if (newString.Contains("5"))
                {
                    newValues.Add(newString.Replace("5", "s"));
                    newValues.Add(newString.Replace("5", "S"));
                }

                if (newString.Contains("2"))
                {
                    newValues.Add(newString.Replace("2", "z"));
                    newValues.Add(newString.Replace("2", "Z"));
                }

                if (newString.Contains("9"))
                {
                    newValues.Add(newString.Replace("9", "g"));
                    newValues.Add(newString.Replace("9", "G"));
                }
            }
            return newValues;
        }

        private List<string> AddSymbols(List<string> values)
        {
            List<string> newValues = new List<string>();

            foreach(string s in values)
            {
                foreach(string symbol in CreateSynbolList())
                {
                    newValues.Add(s + symbol);
                }
            }
            
            return newValues;
        }

        private List<string> CreateSynbolList()
        {
            List<string> values = new List<string>();
            values.Add("!");
            values.Add("@");
            values.Add("#");
            values.Add("$");
            values.Add("%");
            values.Add("^");
            values.Add("&");
            values.Add("*");
            values.Add("(");
            values.Add(")");
            values.Add("-");
            values.Add("+");
            values.Add("1");
            return values;
        }
    }
}
