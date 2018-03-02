using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSW_Tool_Kit
{
    class LocalHostClass
    {
        static string lh = "localhost";

        public static string localComputer
        {
            get
            {
                return lh;
            }
            set
            {
                lh = value;
            }
        }
    }
}
