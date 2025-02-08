using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorAutoProjectail.Appdata
{
    internal class Connection
    {
        public static BorAutoBaseEntities c;
        public static BorAutoBaseEntities context
        {
            get
            {
                if (c == null)
                    c = new BorAutoBaseEntities();
                return c;
            }
        }
    }
}
