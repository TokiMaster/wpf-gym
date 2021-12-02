using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR23_2020_POP2021.Entities
{
    class FitnessCenter
    {
        private int _id;
        private String _name;
        private Address _address;
        
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Address address
        {
            get { return _address; }
            set { _address = value; }
        }

        public FitnessCenter() { }

        public FitnessCenter(int id, String name, Address address)
        {
            this._id = id;
            this._name = name;
            this._address = address;
        }

        public override string ToString()
        {
            return "Dobrodosli u fitnes centar \"" + name + "\". Nalazimo se na adresi: " + address;
        }
    }
}
