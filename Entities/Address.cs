﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Entities
{
    public class Address
    {
        private int _id;
        private String _streetName;
        private int _streetNumber;
        private String _city;
        private String _country;
        private Boolean _isDeleted;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String streetName
        {
            get { return _streetName; }
            set { _streetName = value; }
        }

        public int streetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = value; }
        }

        public String city
        {
            get { return _city; }
            set { _city = value; }
        }

        public String country
        {
            get { return _country; }
            set { _country = value; }
        }
        public Boolean isDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        public Address()
        {

        }

        public Address (int id, String streetName, int streetNumber, String city, String country, Boolean isDeleted)
        {
            this._id = id;
            this._streetName = streetName;
            this._streetNumber = streetNumber;
            this._city = city;
            this._country = country;
            this._isDeleted = isDeleted;
        }

        public override string ToString()
        {
            return streetName + ", " + streetNumber + ", " + city + ", " + country;
        }
    }
}
