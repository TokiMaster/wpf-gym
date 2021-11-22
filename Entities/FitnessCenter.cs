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
        private Adress _adress;
        
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
        public Adress adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        public FitnessCenter(int id, String name, Adress adress)
        {
            this._id = id;
            this._name = name;
            this._adress = adress;
        }
    }
}
