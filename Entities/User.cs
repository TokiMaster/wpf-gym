using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Entities
{
    public class User
    {
        private String _username; 
        private String _name;
        private String _surname;
        private Address _address;
        private Gender _gender;
        private String _email;
        private String _password;
        private Role _userRole;
        private Boolean _isDeleted;


        public String username
        {
            get { return _username; }
            set { _username = value; }
        }
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


        public Address address
        {
            get { return _address; }
            set { _address = value; }
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

        public Boolean isDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }


        public User()
        {

        }

        public User(String username, String name, String surname, Address address, Gender gender,
            String email, String password, Role role, Boolean isDeleted)
        {
            this._username = username;
            this._name = name;
            this._surname = surname;
            this._address = address;
            this._gender = gender;
            this._email = email;
            this._password = password;
            this._userRole = role;
            this._isDeleted = isDeleted;
        }

        public override string ToString()
        {
            return name + " " + surname;
        }

    }
}
