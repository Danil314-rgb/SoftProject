using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    public class Technical_Tasks : Employee
    {        
        static string connectionString2 = @"Server=DESKTOP-H2IQK0E\SQLEXPRESS;Trusted_Connection=True;";
        static string name = "Employee";

        public static void Add_New_DB() //Создание новой БД  
        {
            try
            {
                string sqlExpession1 = $"create database SoftEmployee"; // изменить название перед отправлением create database SoftEmployee

                using (SqlConnection connection1 = new SqlConnection(connectionString2))
                {
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand(sqlExpession1, connection1);
                    command1.ExecuteNonQuery();
                }

                Add_New_Table();
            }
            catch (Exception)
            {
                Console.WriteLine("База Данных уже существует! \tМожно приступать к работе!");
            }

        }
        public static void Add_New_Table() // Создание таблицы "Employee" в БД
        {
            string sqlExpession = $" Create table {name}" + // Employee
                $" (Id int not null UNIQUE ," +
                $" Name nvarchar(20) not null," +
                $" Surname nvarchar(20) not null," +
                $" Position nvarchar(20) not null)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpession, connection);
                command.ExecuteNonQuery();
            }
            Add_Admin();
        }

        public static void Add_Admin() //Создаёт пользователя Админ
        {
            string Admin = "Admin";

            string sqlExpression2 = $"INSERT INTO Employee (Id, Name, Surname, Position) VALUES ('1', 'Admin', 'Admin', 'Admin')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                command.ExecuteNonQuery();
            }

            string sqlExpession = $" Create table {Admin + Admin} (Name nvarchar(20), nHour int, DateWork date, TimeNow smalldatetime)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpession, connection);
                command.ExecuteNonQuery();
            }
        }        
    }
}
