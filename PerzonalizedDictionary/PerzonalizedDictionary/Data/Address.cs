using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerzonalizedDictionary.Data
{
    public class Address : DataClass
    {
        public Address()
        {
            
        }
        public Address(string city, string street, int number, string extra = null)
        {
            Street = street;
            Number = number;
            Extra = extra;
        }

        private string _city;
        private string _street;
        private int _number;
        private string _extra;

        public string City
        {
            get { return _city; }
            set { this.SetProperty(ref this._city, value); }
        }

        public string Street
        {
            get { return _street; }
            set { this.SetProperty(ref this._street, value); }
        }

        public int Number
        {
            get { return _number; }
            set { this.SetProperty(ref this._number, value); }
        }


        public string Extra
        {
            get { return _extra; }
            set { this.SetProperty(ref this._extra, value); }
        }

        public override string ToString()
        {
            return City + " " + Street + " " + Number;
        }
    }
}
