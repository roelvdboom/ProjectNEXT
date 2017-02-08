using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerzonalizedDictionary.Data
{
    class Person : DataClass
    {
        public Person(string firstname, string surname, string preposistion = null, Address address = null)
        {
            FirstName = firstname;
            SurName = surname;
            Preposition = preposistion;
            Address = address;
        }

        private string _firstname;
        private string _surname;
        private string _preposition;
        private Address _address;

        public string FirstName
        {
            get { return _firstname; }

            set { this.SetProperty(ref this._firstname, value); }
        }

        public string SurName
        {
            get { return _surname; }

            set { this.SetProperty(ref this._surname, value); }
        }

        public string Preposition
        {
            get { return _preposition; }
            set { this.SetProperty(ref this._preposition, value); }
        }

        public Address Address
        {
            get { return _address; }
            set { this.SetProperty(ref this._address, value); }
        }
    }
}
