using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPart5
{
    internal interface Icomparable<T>
    {
        int comperTo(T other);
    }
}
