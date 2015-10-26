using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica_03_CSharp.Clases;

namespace Practica_03_CSharp
{
    class Program
    {
        static List<Empleado> listaEmpl = new List<Empleado>();
        static void Main(string[] args)
        {

            int op;
            do
            {
                Console.WriteLine("\n\n*************************MENU**********************\n" +
                                  "Por favor, selecciona una opción.\n\n" +
                                  "\n1.- Dar de alta un empleado" +
                                  "\n2.- Consultar plantilla" +
                                  "\n3.- Salir");
                op = Convert.ToInt32(Console.ReadLine());
                
                switch (op)
                {
                    case 1:
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
                        
                        Console.ReadLine();
                        break;

                    case 2:

                        foreach (var empleado in listaEmpl)
                        {
                            Console.WriteLine("\nNombre:    {0}" +
                                              "\nEdad:      {1}" +
                                              "\nEstudios:  {2}" +
                                              "\nPuesto:    {3}\n\n",
                                empleado.Nombre, empleado.Edad, empleado.Estudios, empleado.Puesto);
                        }

                        break;
                }

            } while (op != 3);

        }

    }
}
