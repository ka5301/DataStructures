using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSImplementations.AppCode.Interfaces
{
    internal interface INode<T,U>
    {
        T Value { get; set; }
        //U Prev { get; set; }
        U Next { get; set; }

    }

}
