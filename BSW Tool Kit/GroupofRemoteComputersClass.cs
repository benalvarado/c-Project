using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSW_Tool_Kit
{
    // This class is to hold the list of computers in a string concatinated by a , 
    // I will convert this to a list for using throughout the program
    class GroupofRemoteComputersClass
    {
        static string goc;

        public static string computerNames
        {
            get
            {
                return goc;
            }
            set
            {
                goc = value;
            }
        }
    }
}
