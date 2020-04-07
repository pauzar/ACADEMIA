using System;
using System.Collections.Generic;
namespace Console_App1
{
    class Program
    {
        static List<string> Name { get; set; }
        static List<double> Marks { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de gestión de alumnos");
            Console.WriteLine("Para introducir la nota de los alumnos use la opción a");
            Console.WriteLine("Para ver las listas use la opción b");
            Console.WriteLine("Para obtener la media de la notas use la opción c");
            Console.WriteLine("Para obtener la media de la notas use la opción e");

            Name = new List<string>();
            Marks = new List<double>();
            var keepdoing = true;
            
            while(keepdoing)
            {
                Console.WriteLine("Introduzca letra:");
                var option = Console.ReadKey().KeyChar;

                Console.WriteLine("");
                if (option == 'a')
                {
                    Add(Name, Marks);
                }
                else if (option == 'b')
                {
                    ShowMenu(Name,Marks);
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
        static void Add(List<string> Lista1, List<double> Listaa)
        {
            while (true)
            {       
                 var add = "si";
                 Console.WriteLine("Quieres introducir alumnos? Si/No");
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
        static void ShowMenu (List<string> Lista1,List<double> Lista)
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
        static void Media (List <double> Lista)
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
