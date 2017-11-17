using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephonnist
{
    class User
    {
        private string phone;
        private string address;
        private string addressFormated;
        private string fullname;
        private int status;
        private string time;
        private int typeCar;

        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string AddressFormated { get => addressFormated; set => addressFormated = value; }
        public int Status { get => status; set => status = value; }
        public string Time { get => time; set => time = value; }
        public int TypeCar { get => typeCar; set => typeCar = value; }
        public string Fullname { get => fullname; set => fullname = value; }
    }

    class History
    {
    }

    class Driver
    {

    }
}
