using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerBARG.Models
{
    public class Call
    {
        string phone;
        string address;
        string addressFormated;
        string status;
        int time;
        string typeCar;

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

        public string Status
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

        public string TypeCar
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

        public int Time
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
    }
}