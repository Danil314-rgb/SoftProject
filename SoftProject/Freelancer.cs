using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    public class Freelancer : Employee
    {
        //static string connectionString = @"Server=DESKTOP-H2IQK0E\SQLEXPRESS;Database=SoftEmployee;Trusted_Connection=True;";
        
        public static void Add_My_Hour(string names, string surname) // Добавление часов 
        {
            Console.WriteLine("\tДобавление часов работ!");

            Console.Write("Введите количество часов! ");
            int hour = Help_Leader_Task.GetInt32UserInput("Введите целое число: ", "Ошибка ввода!");
            DateTime data = Help_Leader_Task.GetDateTimeInput("Введите год.месяц.день: ", "Ошибка ввода! Введите дату как в примере (через точку)!");
            DateTime TimeNow = DateTime.Now;

            string sqlExpression = $"INSERT INTO {names +surname} (Name, nHour, DateWork, TimeNow) VALUES ('{names}', '{hour}','{data}','{TimeNow}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Добавление {hour} час(а/ов) работы сотруднику {names} {surname} прошло успешно!");

            Help_Empl_Task.Goto(1, names, surname); 
        }

        public static void See_My_Day(string names, string surname) //Просмотр отработанных дней и часов работы
        {
            Console.WriteLine($"\t\tПросмотр смен и часов работы  сотрудника {names} {surname}! (По периоду с... - по... )");

            DateTime StartTime = Help_Leader_Task.GetDateTimeInput("Введите начало периода год.месяц.день:", "Ошибка ввода! Введите дату как в примере!");
            DateTime EndTime = Help_Leader_Task.GetDateTimeInput("Введите конец периода год.месяц.день:", "Ошибка ввода! Введите дату как в примере!");
            Console.WriteLine($"Выбранный период: {StartTime} - {EndTime}");

            string sqlExpression = $"select * from {names+surname} where DateWork between '{StartTime}' and '{EndTime}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetName(1), reader.GetName(2));

                    while (reader.Read())
                    {
                        int nHours = reader.GetInt32(1);
                        DateTime DateTime = reader.GetDateTime(2);
                        Console.WriteLine("\t{0}\t{1}", nHours, DateTime);
                    }
                }
                reader.Close();
            }
            Console.WriteLine($"Все часы и даты сотрудника {names} {surname} выведены!");
            Help_Empl_Task.Goto(2, names, surname); 

        }

        public static void Can_Do() //Способности Фрилансера
        {
            Console.WriteLine($"Вы можете сделать следующее: \n1-Добавить отработанные часы. " +
                $"\n2-Посмотреть свои отработаные часы и ЗП за перид." +
                $"\n3-Выход из программы.");
        }

        public static void Actions(int b, string names, string surname)
        {
            switch (b)
            {
                case 1:
                    Add_My_Hour(names, surname);
                    break;
                case 2:
                    See_My_Day(names, surname);
                    break;
                default:
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    break;
            }
        }
    }
}
