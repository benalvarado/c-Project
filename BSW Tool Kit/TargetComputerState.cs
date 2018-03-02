using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSW_Tool_Kit;

namespace BSW_Tool_Kit
{
       
    class TargetComputerState
    {
        static bool localState;
        static bool remoteState;
        static bool groupState;

        public static bool localstateCheck
        {
            get
            {
                return localState;
            }
            set
            {
                localState = value;
            }
        }    
        
        public static bool remotestateCheck
        {
            get
            {
                return remoteState;
            }
            set
            {
                remoteState = value;
            }
        }  

        public static bool groupstateCheck
        {
            get
            {
                return groupState;
            }
            set
            {
                groupState = value;
            }
        }


    }
}
