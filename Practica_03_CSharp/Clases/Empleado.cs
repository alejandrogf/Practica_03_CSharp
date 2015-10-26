using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_03_CSharp.Clases
{
    public enum EstudiosEnum
    {
        Basico = 1,
        Medio = 2,
        Superior = 3,
        Doctor = 4
    }

    public enum PuestoEnum
    {
        Programador = 1,
        Analista = 2,
        DirectorP = 3,
        DirectorIt = 4
    }


    public class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }



        //public EstudiosEnum Estudios { get; set; }

        private EstudiosEnum _estudios;

        public EstudiosEnum Estudios
        {
            get { return _estudios; }
            set
            {
                if ((int)value < 1 | (int)value > 4)
                {
                    var msg = $"El nivel de estudios ({value}) es incorrecto.";
                    throw new EstudiosException(msg);
                }
                _estudios = value;
            }
        }




        private PuestoEnum _puesto;

        public PuestoEnum Puesto
        {
            get { return _puesto; }
            set
            {
                if ((int)value > (int)Estudios)
                {
                    var msg = $"El nivel de estudios ({Estudios}) no "
                        + $"permite optar al puesto seleccionado ({value})";
                    throw new PuestoException(msg);
                }
                _puesto = value;
            }
        }
        
    }
}
