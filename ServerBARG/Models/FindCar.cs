using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerBARG.Models
{
    public class FindCar
    {
        long lat;
        long lng;
        int typeCar;
        int radius;

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

        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }
        }
    }
}