using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    public class Help_Empl_Task
    {
        public static void Goto(int t, string name, string surname) 
        {
            int action = t;
            
            if (t == 1)
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор добаления времени сотруднику. \t2-Выход из программы");
                int number = Help_Leader_Task.GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Empl_Salary.Add_My_Hour(name, surname); 
                }
                else
                {
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    return;
                }
            }
            
            else if (t == 2)
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор просмотра часов и дат работы сотрудника. \t2-Выход из программы");
                int number = Help_Leader_Task.GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Empl_Salary.See_My_Day(name, surname);
                }
                else
                {
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    return;
                }
            }            
        }
    }
}
