using Microsoft.Data.Sqlite;
using System;

namespace sqlcons
{
    class Program
    {
        //private static object salary;

        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source=C:/DB/Employees.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT *, sum(salary) as total_salary from employees  INNER JOIN salaries 
                on salaries.emp_no = employees.emp_no
                GROUP by salaries.emp_no
                order by total_salary DESC
                limit 1
                ";
                command.Parameters.AddWithValue("$salary", 1);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var number = reader.GetString(0);
                        var name = reader.GetString(1);
                        var firstName = reader.GetString(2);
                        var lastName = reader.GetString(3);
                        //var name3 = reader.GetString(4);
                        //var name4 = reader.GetString(5);
                        //var name6 = reader.GetString(6);
                        var salary = reader.GetString(10);
                        //var name8 = reader.GetString(8);

                        //Console.WriteLine($"Hello, {number},Mr. {name2}-{name1}!");
                        Console.WriteLine($"Hello, {lastName},{firstName}:Total Salary {salary}");
                    }
                }
            }
        }
    }
}

