using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Entities
{
    class User
    {
        private String _name;
        private String _surname;
        private int _id; 
        private Adress _adress;
        private Gender _gender;
        private String _email;
        private String _password;
        private Role _userRole;


        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Adress MyProperty
        {
            get { return _adress; }
            set { _adress = value; }
        }


        public Gender gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        public String email
        {
            get { return _email; }
            set { _email = value; }
        }


        public String password
        {
            get { return _password; }
            set { _password = value; }
        }


        public Role userRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }


        public User(String name, String surname, int id, Adress adress, Gender gender,
            String email, String password, Role role)
        {
            this._name = name;
            this._surname = surname;
            this._id = id;
            this._adress = adress;
            this._gender = gender;
            this._email = email;
            this._password = password;
            this._userRole = role;
        }

    }
}
