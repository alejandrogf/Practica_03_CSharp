using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica_03_CSharp.Clases;

namespace Practica_03_CSharp
{
    internal class Program
    {
        private static List<Empleado> listaEmpl = new List<Empleado>()
        {
            new Empleado()
            {
                Nombre = "Julian Martinez",
                Estudios = EstudiosEnum.Medio,
                Edad = 37,
                Puesto = PuestoEnum.Analista,
            },
            new Empleado()
            {
                Nombre = "Ana Marca",
                Estudios = EstudiosEnum.Doctor,
                Edad = 23,
                Puesto = PuestoEnum.DirectorP,
            },
            new Empleado()
            {
                Nombre = "Jonas Tomas",
                Estudios = EstudiosEnum.Superior,
                Edad = 37,
                Puesto = PuestoEnum.Analista,
            },
            new Empleado()
            {
                Nombre = "Andres Garcia",
                Estudios = EstudiosEnum.Medio,
                Edad = 22,
                Puesto = PuestoEnum.Programador,
            },
            new Empleado()
            {
                Nombre = "Julian Martinez Jr",
                Estudios = EstudiosEnum.Superior,
                Edad = 19,
                Puesto = PuestoEnum.Programador,
            },
            new Empleado()
            {
                Nombre = "Miguel Cooper",
                Estudios = EstudiosEnum.Doctor,
                Edad = 37,
                Puesto = PuestoEnum.DirectorIt,
            },
        };


        private static void Main(string[] args)
        {
            int op;
            do
            {
                Console.WriteLine("\n\n*************************MENU**********************\n" +
                                  "Por favor, selecciona una opción.\n\n" +
                                  "\n1.- Dar de alta un empleado" +
                                  "\n2.- Consultar plantilla" +
                                  "\n3.- Buscar" +
                                  "\n4.- Salir");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Alta();
                        Console.ReadLine();
                        break;

                    case 2:
                        Listado();
                        break;

                    case 3:
                        Buscar();
                        break;
                }
            } while (op != 4);
        }

        private static void Buscar()
        {
            Console.WriteLine("\n\nNombre a buscar:");
            var n = Console.ReadLine();

            Console.WriteLine("\n\nBuscar por edad:");
            var e = Convert.ToInt32(Console.ReadLine());
            //Las expresiones lambda son muy similares al SQL (y a ABAP)

            //var p = listaEmpl.Where(o => o.Edad == e && o.Nombre.Contains(n)).OrderBy(o => o.Nombre).Take(3);

            //También se puede escribir en un formato pseudo-sql
            var p = from o in listaEmpl
                where o.Nombre.Contains(n) && o.Edad == e
                orderby o.Edad descending
                select o;



            foreach (var empleado in p)
            {
                Console.WriteLine("{0} Estudios {1} Puesto {2}",
                    empleado.Nombre, empleado.Estudios, empleado.Puesto);
            }

        }

        private static void Listado()
        {
            foreach (var empleado in listaEmpl)
            {
                Console.WriteLine("\nNombre:  {0} " +
                                  "Edad:  {1} " +
                                  "Estudios:  {2} " +
                                  "Puesto:  {3} ",
                    empleado.Nombre, empleado.Edad, empleado.Estudios, empleado.Puesto);
            }
        }

        private static void Alta()
        {
            Console.WriteLine("\n\nNombre: ");
            var nombre = Console.ReadLine();

            Console.WriteLine("\nEdad: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nNivel de Estudios*: " +
                              "\n*Debe seleccionar un valor de la siguiente lista:" +
                              "\n1.- Básico" +
                              "\n2.- Medio" +
                              "\n3.- Superior" +
                              "\n4.- Doctor\n\n");
            //Al tener la enumeracion con numeros tmb, me sirve tanto escribir el valor
            //como el numero de la opción.
            EstudiosEnum estudios;
            EstudiosEnum.TryParse(Console.ReadLine(), out estudios);

            Console.WriteLine("\n¿Qué puesto va a desempeñar?*: " +
                              "\n * Debe seleccionar un valor de la siguiente lista: " +
                              "\n1.- Programador" +
                              "\n2.- Analista" +
                              "\n3.- Director Proyecto" +
                              "\n4.- Director IT\n\n");
            PuestoEnum puesto;
            PuestoEnum.TryParse(Console.ReadLine(), out puesto);


            try
            {
                listaEmpl.Add(new Empleado()
                {
                    Nombre = nombre,
                    Edad = edad,
                    Estudios = estudios,
                    Puesto = puesto,
                });

                Console.WriteLine("\n\nEmpleado registrado.\n\n");
            }
            catch (PuestoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EstudiosException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
