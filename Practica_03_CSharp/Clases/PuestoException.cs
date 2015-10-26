using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_03_CSharp.Clases
{
    public class PuestoException:Exception
    {
        public PuestoException(String msg) :
           base(msg)
       {

       }
    }
}
