using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_03_CSharp.Clases
{
    public class EstudiosException:Exception
    {
        public EstudiosException(String msg) :
           base(msg)
       {

        }
    }
}
