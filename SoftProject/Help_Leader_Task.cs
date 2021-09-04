using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    public class Help_Leader_Task // Проверка на ввод пустой строки для string и int и DateTime
    {
        public static string GetUserInput(string message, string errorMessage, bool addAnEmptyLineIfAnErrorOccured = true)
        {
            bool success;
            string value;
            do
            {
                Console.Write(message);
                value = Console.ReadLine();
                success = !string.IsNullOrWhiteSpace(value);
                if (!success)
                {
                    Console.WriteLine(errorMessage);
                    if (addAnEmptyLineIfAnErrorOccured)
                    {
                        Console.WriteLine();
                    }
                }
            } while (!success);

            return value;
        }                               
        //Проверка на вводимое число 
        public static int GetInt32UserInput(string message, string errorMessage, bool addAnEmptyLineIfAnErrorOccured = true)
        {
            bool success;
            int value;
            do
            {
                Console.Write(message);
                string text = Console.ReadLine();
                success = int.TryParse(text, out value);
                if (!success)
                {
                    Console.WriteLine(errorMessage);
                    if (addAnEmptyLineIfAnErrorOccured)
                    {
                        Console.WriteLine();
                    }
                }
            } while (!success);

            return value;
        }
        //Проверка на вводимую дату
        public static DateTime GetDateTimeInput(string message, string errorMessage, bool addAnEmptyLineIfAnErrorOccured = true)
        {
            bool success;
            DateTime value;
            do
            {
                Console.Write(message);
                string text = Console.ReadLine();
                success = DateTime.TryParse(text, out value);
                if (!success)
                {
                    Console.WriteLine(errorMessage);
                    if (addAnEmptyLineIfAnErrorOccured)
                    {
                        Console.WriteLine();
                    }
                }
            } while (!success);

            return value;
        }

        //Проверка на вводимую Должность при добавлении нового сотрудника
        public static string GetPositionInput(string message, string errorMessage, bool addAnEmptyLineIfAnErrorOccured = true)
        {
            bool success;
            string value;
            do
            {
            my:
                Console.Write(message);
                value = Console.ReadLine();
                success = !string.IsNullOrWhiteSpace(value);
                if (!success) 
                {
                    Console.WriteLine(errorMessage);
                    if (addAnEmptyLineIfAnErrorOccured)
                    {
                        Console.WriteLine();
                    }
                }
                
                if (value == "Руководитель")
                {
                    return value;
                }
                if (value == "Работник")
                {
                    return value;
                }
                if (value == "Фрилансер")
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nДолжность должна соответствовать одной из трёх предложенных!");
                    goto my;
                }
            }
            while (!success);            
        }
        public static void Goto(int t) 
        {
            int action = t;
            if (t == 1)
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор добаления сотрудников. \t2-Выход из программы");
                int number = GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Leader.Add_Empl();
                }
                else 
                {
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    return;
                }
            }
            else if (t == 2 )
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор добаления времени сотруднику. \t2-Выход из программы");
                int number = GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Leader.Add_Hours_and_Days();
                }                
                else 
                {
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    return;
                }
            }
            else if (t == 3 )
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор удаления сотрудника. \t2-Выход из программы");
                int number = GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Leader.Delete_Empl();
                }
                else 
                {
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    return;
                }
            }

            else if (t == 4)
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор просмотра часов и дат работы сотрудника. \t2-Выход из программы");
                int number = GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Leader.See_One_Person();
                }
                else 
                {
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    return;
                }
            }
            else if (t == 5)
            {
                Console.WriteLine("\n\tВыберете дальнейшее действие! " +
                    "\n1-Повтор просмотра часов и дат всего штата. \t2-Выход из программы");
                int number = GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                if (number == 1)
                {
                    Leader.See_All_Person();
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
