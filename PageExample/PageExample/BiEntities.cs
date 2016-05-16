using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageExample
{
    public partial class BIEntities
    {
        private static BIEntities entity;

        public static BIEntities Instance
        {
            get
            {
                if (entity == null)
                {
                    entity = new BIEntities();
                }
                return entity;
            }
        }
    }
}
