using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.States
{
    public enum PackageState
    {
        TakenByCustomer,
        LeftInfrontDoor,
        Returned,
        NotDelivered
    }
}
