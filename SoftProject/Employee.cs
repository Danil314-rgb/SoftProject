using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    public class Employee
    {
        public static string connectionString = @"Server=DESKTOP-H2IQK0E\SQLEXPRESS;Database=SoftEmployee;Trusted_Connection=True;";
        public static void Pass_check_User() // Пароль с проверкой на наличие сотрудника 
        {
            int id = Help_Leader_Task.GetInt32UserInput("\nВведите идентифицирующий личность, пароль (Id): ", "Ошибка ввода!");
            string name = Help_Leader_Task.GetUserInput("Имя сотрудника: ", "Строка не должна быть пустой.");
            string surname = Help_Leader_Task.GetUserInput("Фамилия сотрудника: ", "Строка не должна быть пустой.");

            string queryString = $"SELECT * FROM Employee WHERE Name='{name}' and Id='{id}' and Surname = '{surname}'"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try   
                {
                    connection.Open();  
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string position = reader.GetString(3);

                            if (position == "Работник") // если Работник
                            {
                                Empl_Salary.Can_Do();
                                int b = Help_Leader_Task.GetInt32UserInput("Выберите действие: ", "Ошибка ввода! Введите целое число: ");
                                Empl_Salary.Actions(b, name, surname);
                            }
                            else if (position == "Фрилансер")// если Фрилансер
                            {
                                Freelancer.Can_Do();
                                int b = Help_Leader_Task.GetInt32UserInput("Выберите действие: ", "Ошибка ввода! Введите целое число: ");
                                Freelancer.Actions(b, name, surname);
                            }
                            else if (position == "Admin" || position == "Руководитель")// Если Руководитель и Админ
                            {
                                Leader.Can_Do();
                                int b = Help_Leader_Task.GetInt32UserInput("Выберите действие: ", "Ошибка ввода! Введите целое число: ");
                                Leader.Actions(b);
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Пароль не подходит к Имени сотрудника");
                        Console.WriteLine("\n\tВыберите дальнейшее действие! " +
                            "\n1-Повтор ввода пароля. \t2-Выход из программы.");
                        int number = Help_Leader_Task.GetInt32UserInput("Действие под номером: ", "Ошибка ввода! Введите целое число: ");
                        if (number == 1)
                        {
                            Pass_check_User();
                        }
                        else
                        {
                            Console.WriteLine("\n\tВыход из программы выполнен!");
                            return;
                        }
                    }
                }
                catch  
                {
                    Console.WriteLine("\n\tБаза данных отсутствует, либо не найдена! Проверьте соединение либо создайте Базу даных!");
                    Technical_Tasks.Add_New_DB();
                }

            }
        }
    }
}
