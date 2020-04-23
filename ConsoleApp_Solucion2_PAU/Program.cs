using Console_App1.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_App1
{
    class Program
    {
        public static Dictionary <string,Student> Students = new Dictionary<string, Student>();
        public static Dictionary<string,Subjects> Subjects = new Dictionary<string,Subjects>();
        public static Dictionary <int,Exam> Exams= new Dictionary<int,Exam>();
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de gestión de alumnos");
            Console.WriteLine("Para ir a la gestión de alumnos use la opción a");
            Console.WriteLine("Para ir a la gestión de asignaturas use la opción s");
            Console.WriteLine("Para ir a la gestion de examenes y estadisiticas use la opción e");

            var keepdoing = true;
            
            while(keepdoing)
            {
                Console.WriteLine("Introduzca letra:");
                var option = Console.ReadKey().KeyChar;

                Console.WriteLine("");
                if (option == 'a')
                {
                    ShowStudentsMenu();
                }
                else if (option == 's')
                {
                    ShowSubjectsMenu();
                }
                else if (option == 'e')
                {
                    ShowExamsMenu();
                }
                else
                {
                    Console.WriteLine("Seguro pusiste bien las opciones?");
                    keepdoing = false;
                }
            }
        }
        static void ShowStudentsMenu()
        {
            Console.WriteLine();
            ShowStudentsMenuOptions();

            var keepdoing = true;

            while (keepdoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        ShowAllStudents();
                        break;
                    case "add":
                        AddStudents();
                        break;
                    case "edit":
                        EditStudents();
                        break;
                    case "del":
                        RemoveStudents();
                        break;
                    case "m":
                        keepdoing = false;
                        break;
                    default:
                        //AddMark(text);
                        break;

                }
            }
        }
        public static void ShowStudentsMenuOptions()
        {
            Console.WriteLine("--ShowMenu de Estudiantes--");

            Console.WriteLine("Para ver todos los estudiantes escriba all");
            Console.WriteLine("Para añadir un nuevo estudiante escriba add ");
            Console.WriteLine("Para editar un nuevo estudiante escriba edit");
            Console.WriteLine("Para borrar un estudiante escriba del");
            Console.WriteLine("Para volver al menu principal escria m");
        }
        public static void AddStudents()
        {
            Console.WriteLine("Primero inserte el dni o escriba anular para interrumpir");

            var keepdoing1 = true;

            while(keepdoing1)
            {
                var dni = Console.ReadLine();

                if(dni =="anular")
                {
                    break;
                }
                else if(string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("Puede que este mal escrito, o esta vacio");
                }
                else if (Students.ContainsKey(dni))
                {
                    Console.WriteLine($"Ya existe un estudiante con este {dni}");
                }
                else 
                {
                    while (true)
                    {
                        Console.WriteLine("Ahora inserte el nombre o escriba anular para salir");
                        var name = Console.ReadLine();

                        if (name == "anular")
                        {
                            keepdoing1 = false;
                            break;
                        }
                        else if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("El nombre esta vacio");
                        }
                        else
                        {                            
                            var student = new Student()
                            {
                                Id = Guid.NewGuid(),
                                Dni = dni,
                                Name = name,
                            };
                            Students.Add(student.Dni, student);

                            keepdoing1 = false;
                            break;
                        }
                    }
                }
            }         
            ShowStudentsMenuOptions();
        }
        static void ShowAllStudents ()
        {
            foreach(var student in Students.Values)
            {
                Console.WriteLine($" {student.Dni} {student.Name} ");
            }
        }
        static void EditStudents()
        {
            Console.WriteLine("Inserte el dni del alumno que desea modificar");
            var dni = Console.ReadLine();
            foreach (var student in Students.Values)
            {
                if(student.Dni==dni)
                {
                    Console.WriteLine("Introduzca el nuevo nombre que desea modificar");
                    var nuevo_nombre = Console.ReadLine();
                    student.Name = nuevo_nombre;
                }
            }
            ShowAllStudents();
        }
        static void RemoveStudents()
        {
            Console.WriteLine("Inserte el dni del alumno que desea eliminar");
            var dni = Console.ReadLine();
            foreach (var student in Students.Values)
            {
                if (student.Dni == dni)
                {
                    Console.WriteLine("Se ha eliminado el alumno con dni " + student.Dni);
                    Students.Remove(student.Dni);
                }
            }
            ShowAllStudents();
        }


        static void ShowSubjectsMenu()
        {
            Console.WriteLine();
            ShowSubjectsMenuOptions();

            var keepdoing = true;

            while (keepdoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        ShowAllSubjects();
                        break;
                    case "add":
                        AddSubjects();
                        break;
                    case "edit":
                        EditSubjects();                        
                        break;
                    case "del":
                        RemoveSubjects();
                        break;
                    case "m":
                        keepdoing = false;
                        break;
                    default:
                        Console.WriteLine("No se ha introducido correctamente la opción, vuelva a intentarlo");
                        //////
                        break;

                }
            }
        }
        public static void ShowSubjectsMenuOptions()
        {
            Console.WriteLine("--ShowMenu de Asignaturas--");

            Console.WriteLine("Para ver todos los asignaturas escriba all");
            Console.WriteLine("Para añadir un nuevo asignaturas escriba add ");
            Console.WriteLine("Para editar un nuevo asignaturas escriba edit");
            Console.WriteLine("Para borrar un asignaturas escriba del");
            Console.WriteLine("Para volver al menu principal escria m");
        }
        public static void AddSubjects()
        {
            Console.WriteLine("Inserte una asigantura o escriba anular para interrumpir");

            var keepdoing1 = true;

            while (keepdoing1)
            {
                var subject = Console.ReadLine();

                if (subject == "anular")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(subject))
                {
                    Console.WriteLine("Puede que este esta vacio");
                }
                else if (Students.ContainsKey(subject))
                {
                    Console.WriteLine($"Ya existe un estudiante con este {subject}");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Ahora inserte el nombre del profesor o escriba anular para salir");
                        var teacher = Console.ReadLine();

                        if (teacher == "anular")
                        {
                            keepdoing1 = false;
                            break;
                        }
                        else if (string.IsNullOrEmpty(teacher))
                        {
                            Console.WriteLine("El nombre esta vacio");
                        }
                        else
                        {
                            var subjects = new Subjects()
                            {
                                Id = Guid.NewGuid(),
                                Name = subject,
                                Teacher = teacher
                            };
                            Subjects.Add(subjects.Name, subjects);
                            keepdoing1 = false;
                            break;
                        }
                    }
                }
            }
            ShowSubjectsMenuOptions();
        }
        static void ShowAllSubjects()
        {
            foreach (var subjects in Subjects.Values)
            {
                Console.WriteLine($"{subjects.Name} {subjects.Teacher}");
            }
        }
        static void EditSubjects()
        {
            Console.WriteLine("Si dese a modificar el nombre de una asignatura use s ");
            Console.WriteLine("Si dese a modificar el nombre del profesor de la asignatura use p ");

            var text = Console.ReadLine();

            switch (text)
            {
            case "s":
                Console.WriteLine("Inserte la asignatura que desea modificar");
                var subject = Console.ReadLine();
                foreach (var subjects in Subjects.Values)
                {
                    if (subjects.Name == subject)
                    {
                        Console.WriteLine("Introduzca el nuevo nombre de la asignatura");
                        var new_subject = Console.ReadLine();
                        subjects.Name = new_subject;
                        Console.WriteLine("Asi quedaría la nueva lista");
                        ShowAllSubjects();
                    }
                }
                break;

            case "p":
                Console.WriteLine("Inserte el nombre del profesor que desea modificar");
                var teacher = Console.ReadLine();
                foreach (var subjects in Subjects.Values)
                {
                    if (subjects.Teacher == teacher)
                    {
                        Console.WriteLine("Introduzca el nuevo nombre del profesor que desea modificar");
                        var new_teacher = Console.ReadLine();
                        subjects.Teacher = new_teacher;
                        Console.WriteLine("Asi quedaría la nueva lista");
                        ShowAllSubjects();
                    }
                }
                break;
            default:
                Console.WriteLine("No se ha introducido correctamente la opción, vuelva a intentarlo");
                break;
            }
        }
        static void RemoveSubjects()
        {
            Console.WriteLine("Inserte la asignatura que desea eliminar");
            var subject = Console.ReadLine();
            foreach (var subjects in Subjects.Values)
            {
                if (subjects.Name == subject)
                {
                    Console.WriteLine("Introduzca el nombre de la asignatura que desea eliminar");
                    Subjects.Remove(subjects.Name);
                    Console.WriteLine("Se ha eliminado la asignatura con nombre " + subjects.Name);
                    Console.WriteLine("Asi quedaría la nueva lista");
                    ShowAllSubjects();
                }
            }
        }


        static void ShowExamsMenu()
        {
            Console.WriteLine();
            ShowExamsMenuOptions();

            var keepdoing = true;

            while (keepdoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        ShowAllExams();
                        break;
                    case "add":
                        AddExams();
                        break;
                    case "edit":
                        EditExams();                        
                        break;
                    case "del":
                        RemoveExams();
                        break;
                    case "m":
                        keepdoing = false;
                        break;
                    default:
                        Console.WriteLine("No se ha introducido correctamente la opción, vuelva a intentarlo");
                        //////
                        break;

                }
            }
        }
        public static void ShowExamsMenuOptions()
        {
            Console.WriteLine("--ShowMenu de Exams--");

            Console.WriteLine("Para ver todos los examens escriba all");
            Console.WriteLine("Para añadir un nuevo examen escriba add ");
            Console.WriteLine("Para editar un nuevo examen escriba edit");
            Console.WriteLine("Para borrar un examen escriba del");
            Console.WriteLine("Para volver al menu principal escria m");
        }
        public static void AddExams()
        {
            Console.WriteLine("Primero inserte el dni del alumno o escriba anular para interrumpir");
            var dni = Console.ReadLine();
            Console.WriteLine("Inserte la asignatura");
            var sub = Console.ReadLine();
            Console.WriteLine("Inserte el ID del examen");
            var idExam = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserte la nota");
            var mark = Double.Parse(Console.ReadLine());
            
            var student = Students[dni];
            var subject = Subjects[sub];
            var keepdoing = true;
            while(keepdoing)
            {
                if (dni == student.Dni)
                    //var student = Students.Values.FirstOrDefault(x => x.Dni == dni);
                {
                    if (sub == subject.Name)
                    {
                        var exam = new Exam()
                        {
                            Id = Guid.NewGuid(),
                            idExam = idExam,
                            Mark = mark,
                            Student = student,
                            Subject = subject,
                        };
                        Exams.Add(exam.idExam, exam);
                    }
                    else
                    {
                        Console.WriteLine($"Es posible que no hayas introducido correctamente la asignatura");
                    }
                }
                else
                {
                    Console.WriteLine($"Es posible que no hayas introducido correctamente la asignatura");
                }
            }
          
            ShowStudentsMenuOptions();
        }
        public static void ShowAllExams()
        {
            foreach (var exam in Exams.Values)
            {
                Console.WriteLine($"{exam.Student.Dni} {exam.Student.Name} {exam.Subject.Name} {exam.Subject.Teacher} {exam.idExam} {exam.Mark} ");
            }
        }
        static void EditExams()
        {
            Console.WriteLine("Inserte el ID del examen que desa modificar");
            var id = int.Parse(Console.ReadLine());
            foreach (var exam in Exams.Values)
            {
                if (exam.idExam == id)
                {
                    Console.WriteLine($"la nota correspondiente al {id} es {exam.Mark}, inserte la nueva nota ");
                    var nueva_Mark = double.Parse(Console.ReadLine());
                    exam.Mark = nueva_Mark;
                }
            }
            ShowAllExams();
        }
        static void RemoveExams()
        {
            Console.WriteLine("Inserte el id del examen que desea eliminar");
            var id = int.Parse(Console.ReadLine());
            foreach (var exam in Exams.Values)
            {
                if (exam.idExam == id)
                {
                    Console.WriteLine($"la nota correspondiente al {id} es {exam.Mark} y se ha eliminado");
                    Exams.Remove(exam.idExam);
                }
            }
            ShowAllExams();
        }

        //public static void ShowStatsMenu ()

        //{
        //    double suma = 0.0;
        //    for (int i = 0; i < Students.Count; i++)
        //    {
        //        suma = suma + Students[i];
        //    }
        //    double resultado = suma / Students.Count;
        //    Console.WriteLine("La media es " + resultado);
        //}
    }
}
