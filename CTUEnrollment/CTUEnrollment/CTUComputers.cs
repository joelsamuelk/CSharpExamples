using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTUEnrollment
{
    public class CTUComputers
    {
        private static CTUComputers instance;
        public static CTUComputers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CTUComputers();
                }
                return instance;
            }
        }
    }
}
