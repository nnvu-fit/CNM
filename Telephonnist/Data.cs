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

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string AddressFormated
        {
            get
            {
                return addressFormated;
            }

            set
            {
                addressFormated = value;
            }
        }

        public string Fullname
        {
            get
            {
                return fullname;
            }

            set
            {
                fullname = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public int TypeCar
        {
            get
            {
                return typeCar;
            }

            set
            {
                typeCar = value;
            }
        }
    }

    class History
    {
    }

    class Driver
    {
        private string name;
        private double lat;
        private double lng;
        private int status;
        private int typeCard;
        private int id;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double Lat
        {
            get
            {
                return lat;
            }

            set
            {
                lat = value;
            }
        }

        public double Lng
        {
            get
            {
                return lng;
            }

            set
            {
                lng = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int TypeCard
        {
            get
            {
                return typeCard;
            }

            set
            {
                typeCard = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
