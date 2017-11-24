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
        //status
        //    0 : chưa xac định tọa độ 
        //    1 : đang tìm xe
        //    2 : đã định vị
        //    3 : không có xe
        int status;
        long time;
        int typeCar;
        long lat;
        long lng;

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

        public long Time
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

        public long Lat
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

        public long Lng
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
    }
}