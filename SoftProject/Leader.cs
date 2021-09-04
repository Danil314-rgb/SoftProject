using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftProject
{
    public class Leader : Employee
    {              
        public static void Add_Empl()  // Добавление нового сотрудника 
        {
            Console.WriteLine("\tДобавление новых сотрудников!");
            Console.Write($"\nВведите (числом) количество сотрудников! \nНовых сотрудников будет: ");

            int number;                                             
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Ошибка ввода! Введите целое число: ");
            }
            Console.WriteLine();

            for (int i = 0; i < number; i++)
            {
                int id = Help_Leader_Task.GetInt32UserInput("Индивидуальный ключ: ", "Ошибка ввода! Введите целое число. ");
                string name = Help_Leader_Task.GetUserInput("Имя сотрудника: ", "Строка не должна быть пустой.");
                string surname = Help_Leader_Task.GetUserInput("Фамилия сотрудника: ", "Строка не должна быть пустой.");
                string position = Help_Leader_Task.GetPositionInput("Должность сотрудника (Руководитель, Работник, Фрилансер): ", "Строка не должна быть пустой.");
                Console.WriteLine();

                Regex regex = new Regex(@"(\W)");
                MatchCollection matches = regex.Matches(name);
                MatchCollection matches1 = regex.Matches(surname);
                if (matches.Count > 0 || matches1.Count > 0)
                {
                    Console.WriteLine($"Введёное Имя: {name} Введёная Фамилия: {surname}");
                    Console.WriteLine("Ошибка! В Имени или Фамилии присутствуют недопустимые символы!");                    
                    continue;
                }
                else
                {
                    check_User_Add_New_Empl(connectionString, name, surname);
                    if (t == 1)
                    {
                        Console.WriteLine("\n\tТакой сотрудник уже существует в базе сотрудников! Выход из программы!");
                        continue;
                    }
                    try
                    {
                        string sqlExpression = $"INSERT INTO Employee (Id, Name, Surname, Position) VALUES ('{id}', '{name}', '{surname}','{position}')";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.ExecuteNonQuery();
                        }

                        string sqlExpession = $" Create table {name + surname} (Name nvarchar(20), nHour int, DateWork date, TimeNow smalldatetime)";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpession, connection);
                            command.ExecuteNonQuery();
                        }

                        Console.WriteLine("Сотрудник успешно добавлен!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\tВозникла ошибка! \n\tПроверьте вводимый Индивидуальный ключ!");
                    }                    
                }
            }
            Help_Leader_Task.Goto(1);
        }
        public static int check_User_Add_New_Empl(string connectionString,  string name, string surname )  // Проверка на наличие сотрудника 
        {
            string queryString = $"SELECT COUNT(*) FROM Employee WHERE Name='{name}' and Surname ='{surname}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();

                if (count > 0)
                {
                    return t = 1;
                }
                else
                {
                    return t = 0;
                }
            }
        }
        static public int t;
        public static void Add_Hours_and_Days()  //Добавление часов работы
        {
            Console.WriteLine("\tДобавление времени и дат работы сотрудникам! (По Имени)");                    
            string name = Help_Leader_Task.GetUserInput("Имя сотрудника: ", "Строка не должна быть пустой.");
            string surname = Help_Leader_Task.GetUserInput("Фамилия сотрудника: ", "Строка не должна быть пустой.");
            checkUser(connectionString, name, surname);
                      
            if (t == 1)
            {
                Console.Write("Введите количество часов! ");                
                int hour = Help_Leader_Task.GetInt32UserInput("Введите целое число: ", "Ошибка ввода!");                
                DateTime data = Help_Leader_Task.GetDateTimeInput("Введите год.месяц.день: ", "Ошибка ввода! Введите дату как в примере (через точку)!");
                DateTime TimeNow = DateTime.Now;
                                
                string sqlExpression = $"INSERT INTO {name+surname} (Name, nHour, DateWork, TimeNow) VALUES ('{name}', '{hour}','{data}','{TimeNow}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Добавление часов работы прошло успешно!");
            }
            else
            {
                Console.WriteLine("Такого сотрудника не существует!");
            }
            Help_Leader_Task.Goto(2);
        }
        public static int checkUser(string connectionString, string name, string surname)  // Проверка на наличие сотрудника 
        {
            string queryString = $"SELECT COUNT(*) FROM Employee WHERE Name='{name}' and Surname ='{surname}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();

                if (count > 0)
                {
                    Console.WriteLine("Yes");
                   return t = 1;
                }
                else
                {
                    Console.WriteLine("No");
                    return t=0;
                }
            }
        }

        public static void Delete_Empl()  //Удаление сотрудников
        {
            Console.WriteLine("\t\tУдаление сотрудника! (По Имени)");
            Console.WriteLine("\tУдаление сотрудника приведёт к удалению его из базы данных сотрудников, а так же к удалению часов работ!");           
            string name = Help_Leader_Task.GetUserInput("Имя сотрудника: ", "Строка не должна быть пустой.");
            string surname = Help_Leader_Task.GetUserInput("Фамилия сотрудника: ", "Строка не должна быть пустой.");
            checkUser(connectionString, name, surname);
                        
            if (t == 1)
            {
                string sqlExpression = $"delete from Employee where Name ='{name}' and Surname = '{surname}'";                                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }

                string sqlExpression1 = $"drop table {name + surname} ";
                using (SqlConnection connection1 = new SqlConnection(connectionString))
                {
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
                    command1.ExecuteNonQuery();
                }
                Console.WriteLine("Сотрудник успешно удалён! Пока)");
                Help_Leader_Task.Goto(3);
            }
            else
            {
                Console.WriteLine("Такого сотрудника не существует!");
                Help_Leader_Task.Goto(3);
            }
        }

        public static void See_One_Person() //Просмотр отработанных дней и часов работы одного сотрудника
        {
            Console.WriteLine("\t\tПросмотр смен и часов работы конкретного сотрудника! (По Имени и периоду с... - по... )");

            string name = Help_Leader_Task.GetUserInput("Имя сотрудника: ", "Строка не должна быть пустой.");
            string surname = Help_Leader_Task.GetUserInput("Фамилия сотрудника: ", "Строка не должна быть пустой.");
            checkUser(connectionString, name, surname);

            if (t == 1 )
            {
                DateTime StartTime = Help_Leader_Task.GetDateTimeInput("Введите начало периода год.месяц.день:", "Ошибка ввода! Введите дату как в примере!");
                DateTime EndTime = Help_Leader_Task.GetDateTimeInput("Введите конец периода год.месяц.день:", "Ошибка ввода! Введите дату как в примере!");
                Console.WriteLine($"Выбранный период: {StartTime} - {EndTime}");

                string sqlExpression = $"select * from {name+surname} where DateWork between '{StartTime}' and '{EndTime}'";

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
                Console.WriteLine($"Все часы и даты сотрудника {name+surname} выведены!");
            }
            else
            {
                Console.WriteLine("Такого сотрудника не сущесвует! Попробуйте другого!");
            }
            Help_Leader_Task.Goto(4);
        }

        public static void See_All_Person() //Просмотр отработанных дней и часов работы всего штата 
        {
            Console.WriteLine("\t\tПросмотр смен и часов работы всего штата! (По периоду с... - по... )");
            DateTime StartTime = Help_Leader_Task.GetDateTimeInput("Введите начало периода год.месяц.день:", "Ошибка ввода! Введите дату как в примере!");
            DateTime EndTime = Help_Leader_Task.GetDateTimeInput("Введите конец периода год.месяц.день:", "Ошибка ввода! Введите дату как в примере!");
            Console.WriteLine($"Выбранный период: {StartTime} - {EndTime}");

            string sqlExpression = $"select Name, Surname from Employee";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("\tName\tnHour\tDateWork");

                    while (reader.Read())
                    {
                        string Name = reader.GetString(0);
                        string Surname = reader.GetString(1); 

                        string sqlExpression1 = $"select Name, nHour, DateWork from {Name+Surname} Where DateWork between '{StartTime}' and '{EndTime}' ";

                        using (SqlConnection connection1 = new SqlConnection(connectionString))
                        {
                            connection1.Open();
                            SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
                            SqlDataReader reader1 = command1.ExecuteReader();

                            if (reader1.HasRows)
                            {
                                while (reader1.Read())
                                {
                                    string Name1 = reader1.GetString(0);
                                    int nHour1 = reader1.GetInt32(1);
                                    DateTime DateTime1 = reader1.GetDateTime(2);
                                    Console.WriteLine("\t{0}\t{1}\t{2}", Name1, nHour1, DateTime1);
                                }
                            }
                        }
                    }
                }
                reader.Close();
            }
            Console.WriteLine($"Все часы и даты сотрудников выведены!");
            Help_Leader_Task.Goto(5);
        }


        public static void Can_Do() // Способности Руководителя
        {
            Console.WriteLine($"Вы можете сделать следующее: " +
                $"\n1-Добавить нового сотрудника в систему. " +
                $"\n2-Добавить время работы сотрудникам." +
                $"\n3-Удалить сотрудника из системы." +
                $"\n4-Посмотреть часы работы за период по конкретному сотруднику." +
                $"\n5-Посмотреть часы работы за период по всем сотрудникам." +
                $"\n6-Выход из программы.");
        }
        public static void Actions(int a)
        {
            switch (a)
            {
                case 1:
                    Add_Empl();
                    break;
                case 2:
                    Add_Hours_and_Days();
                    break;
                case 3:
                    Delete_Empl();
                    break;
                case 4:
                    See_One_Person();
                    break;
                case 5:
                    See_All_Person();
                    break;
                default:
                    Console.WriteLine("\n\tВыход из программы выполнен!");
                    break;                   
            }
        }
    }
}
