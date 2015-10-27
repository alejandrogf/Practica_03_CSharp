using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_03_CSharp.Clases
{
    public static class Extension
    {
        //Metodo de extensión, el primer parámetro siempre es this, para hacer referencia 
        //a lo que se le pasa, luego el tipo de parámetro y el parámetro.
        //Si hay varios a pasar, se puede hacer añadiendolos en la lista
        public static string Sustituye(this string original)
        {
            var cadena = original.Replace("a", "A");
            return cadena;
        }
    }
}
