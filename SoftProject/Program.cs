using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Для создания новой базы данных сотрудников введите 1," +
                " Eсли база данных уже существует, введите 2: ");
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Ошибка ввода! Введите целое число: ");
            }
            if (number == 1)
            {
                Technical_Tasks.Add_New_DB();
            }

            Employee.Pass_check_User();            
        }
    }
}
