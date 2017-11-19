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
        private string name;
        private string lat;
        private string lng;
        private int status;
        private int typeCard;

        public string Name { get => name; set => name = value; }
        public int Status { get => status; set => status = value; }
        public int TypeCard { get => typeCard; set => typeCard = value; }
        public string Lat { get => lat; set => lat = value; }
        public string Lng { get => lng; set => lng = value; }
    }
}
