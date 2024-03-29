﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.States
{
    [DataContract(Name = "PackageState")]
    public enum PackageState
    {
        [EnumMember]
        Unknown,
        [EnumMember]
        CustomerNotHome,
        [EnumMember]
        CustomerWasHome
    }
}
