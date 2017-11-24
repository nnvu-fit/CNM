using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerBARG.Models
{
    public class Car
    {
        int id;
        double lat;
        double lng;
        string name;
        //status
        //    0 : xe trống 
        //    1 : xe đang có khách
        int status;
        int typeCar;

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
    }
}