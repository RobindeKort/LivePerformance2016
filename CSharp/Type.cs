using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    [DataContract]
    public enum Type
    {
        [EnumMember]
        VA,
        [EnumMember]
        TI,
        [EnumMember]
        NI
    }
}
