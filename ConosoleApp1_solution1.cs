
using System;
using System.Collections.Generic;
namespace Console_App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de gestión de alumnos");
            Console.WriteLine("Para introducir la nota de los alumnos use la opción a");
            Console.WriteLine("Para ver las listas use la opción b");
            Console.WriteLine("Para obtener la media de la notas use la opción c");
            Console.WriteLine("Para obtener la media de la notas use la opción e");

            List<string> Name = new List<string>();
            List<double> Marks = new List<double>();
            var keepdoing = true;
            var add = "si";

            while (keepdoing)
            {
                Console.WriteLine("Introduzca letra:");
                var option = Console.ReadKey().KeyChar;

                if (option == 'a')
                {
                    Console.WriteLine("Introduzca el nombre del alumno");
                    Name.Add(Console.ReadLine());
                    Console.WriteLine("y la nota plis:");
                    Marks.Add(Convert.ToDouble(Console.ReadLine()));

                    while (true)
                    {
                        Console.WriteLine("Quieres seguir introduciendo alumnos? Si/No");
                        add = Console.ReadLine();
                        if (add == "si")
                        {
                            Console.WriteLine("Pon el nombre:");
                            Name.Add(Console.ReadLine());
                            Console.WriteLine("y la nota plis:");
                            Marks.Add(Convert.ToDouble(Console.ReadLine()));
                        }
                        else
                        {
                            Console.WriteLine("Se ha finalizado el añadir a peñota");
                            break;
                        }
                    }
                    Console.WriteLine("Eliga otra opción (a,b,c,e). Recuerde que para salir es la opción e");
                }
                else if (option == 'b')
                {
                    foreach (var n in Name)
                    {
                        Console.WriteLine(n.ToString());
                    }
                    foreach (var m in Marks)
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
                else if (option == 'c')
                {
                    Media(Marks);
                }
                else if (option == 'e')
                {
                    Console.WriteLine("Que te vaya todo super!");
                    keepdoing = false;
                }
                else
                {
                    Console.WriteLine("Seguro pusiste bien las opciones?");
                }
            }
        }
        public static void Media(List<double> Lista)
        {
            double suma = 0.0;
            for (int i = 0; i < Lista.Count; i++)
            {
                suma = suma + Lista[i];
            }
            double resultado = suma / Lista.Count;
            Console.WriteLine("La media es " + resultado);
        }

    }
}
