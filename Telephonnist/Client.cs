using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Telephonnist
{
    class Client
    {
        private static readonly HttpClient client = new HttpClient();

        public static ArrayList GetHistory()
        {
            return new ArrayList();
        }
        
        public static ArrayList GetUsers()
        {
            return new ArrayList();
        }

        public static ArrayList GetDrivers()
        {
            return new ArrayList();
        }
    }
}
