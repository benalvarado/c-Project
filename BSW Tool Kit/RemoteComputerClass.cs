using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSW_Tool_Kit
{
    // This class is to hold the variable of the remote computer named by the user
    class RemoteComputerClass
    {
        static string rc;

        public static string computerName
        {
            get
            {
                return rc;
            }
            set
            {
                rc = value;
            }
        }
        }
    }

