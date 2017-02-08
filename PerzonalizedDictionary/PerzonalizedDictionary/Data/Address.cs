﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerzonalizedDictionary.Data
{
    class Address : DataClass
    {
        public Address(string street, int number, string extra = null)
        {
            Street = street;
            Number = number;
            Extra = extra;
        }

        private string _street;
        private int _number;
        private string _extra;

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

    }
}
