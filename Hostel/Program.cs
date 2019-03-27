using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel
{
    class Program
    {
        enum Male
        { Woman, Man };
        enum FormsOfEducation
        { InAbsentia,//Заочно
          IntraMural //Очно
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Сколько студентов?");
            int countStudent = int.Parse(Console.ReadLine());
            HostelForStudents[] student = new HostelForStudents[countStudent];
            for (int i = 0; i < countStudent; i++)
            {
                Console.WriteLine($"Введите ФИО {i + 1} студента");
                string nameStudent = Console.ReadLine();
                student[i].Name = nameStudent;
                Console.WriteLine($"Введите группу {i + 1} студента");
                string group = Console.ReadLine();
                student[i].Group = group;
                student[i].AverageMark = rand.Next(30, 100);
                student[i].IncomeFamily = rand.Next(10000, 100000);
                Console.WriteLine($"Введите пол {i + 1} студента /// 0-Женщина, 1-Мужчина");
                int male = int.Parse(Console.ReadLine());
                if (male == 0)
                    student[i].Male = "Женщина";
                else
                    student[i].Male = "Мужчина";
                Console.WriteLine($"Введите форму обучения {i + 1} студента");
                string forms = Console.ReadLine();
                student[i].FormOfEducation = forms;
            }

            Console.WriteLine("**************************************");
            int min = 500000;
            int min1 = 500000;
            for (int i = 0; i < countStudent; i++)
            {
                if(student[i].IncomeFamily < min1)
                Console.WriteLine($"ФИО {i + 1} студента: " + student[i].Name);
                Console.WriteLine($"Группа {i + 1} студента: " + student[i].Group);
                Console.WriteLine($"Средний балл {i + 1} студента: " + student[i].AverageMark);
                Console.WriteLine($"Доход {i + 1} студента: " + student[i].IncomeFamily);
                Console.WriteLine($"Пол {i + 1} студента: " + student[i].Male);
                Console.WriteLine($"Форма обучения {i + 1} студента: " + student[i].FormOfEducation);
            }
            for(int i=0; i<countStudent; i++)
            {
                if (student[i].IncomeFamily < min)
                {
                    min = student[i].IncomeFamily;
                }
            }
            var result1 = from HostelForStudents in student
                          where HostelForStudents.IncomeFamily == min
                          select HostelForStudents;
            foreach (HostelForStudents h1 in result1)
            {
                Console.WriteLine("  FIO students  - " + h1.Name);
                Console.WriteLine("  IncomePay students  - " + min);
                Console.WriteLine("  AverageMark students  - " + h1.AverageMark);
            }
            for (int i = 0; i < countStudent; i++)
            {
                if (student[i].IncomeFamily < min1 && student[i].IncomeFamily > min)
                {
                    min1 = student[i].IncomeFamily;
                }
            }
            var result2 = from HostelForStudents in student
                          where HostelForStudents.IncomeFamily == min1
                          select HostelForStudents;
            foreach (HostelForStudents h2 in result2)
            {
                Console.WriteLine("  FIO students  - " + h2.Name);
                Console.WriteLine("  IncomePay students  - " + min1);
                Console.WriteLine("  AverageMark students  - " + h2.AverageMark);
            }

            Console.WriteLine("Далее по среднему балу");

        var result = from HostelForStudents in student
                     where HostelForStudents.IncomeFamily>min1
                     orderby HostelForStudents.AverageMark descending
                             select HostelForStudents;
        foreach (HostelForStudents h in result)
            {
                Console.WriteLine("  FIO students  - " + h.Name + " " + h.IncomeFamily);
                Console.WriteLine("  IncomePay students  - " + h.IncomeFamily);
                Console.WriteLine("  AverageMark students  - " + h.AverageMark);
            }
        Console.ReadLine();
        }
            
    }
}
