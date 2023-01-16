namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public class DBManager
{
    public static string conString = @"server=localhost;
                                        port=3306;
                                        user=root;
                                        password=root123;
                                        database=employee;";

    // public static List<Employee> GetAllEmployees()
    // {
    //     List<Employee> emps = new List<Employee>();

    //     return List<Employee>;
    // }

    public static List<Employee> GetAllEmployees()
    {
        List<Employee> emps=new List<Employee>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {

            string query = "SELECT * FROM employees";
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader[0].ToString());
                string name = reader[1].ToString();
                string email = reader[2].ToString();
                string password = reader[3].ToString();
                emps.Add(new Employee
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Password = password
                });
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
        finally
        {
            con.Close();
        }
        return emps;
    }

    public static Employee GetEmployeeById(int id)
    {
        Employee emp=null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {

            string query = "SELECT * FROM employees WHERE id=" + id;
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                int id1 = int.Parse(reader[0].ToString());
                string name = reader[1].ToString();
                string email = reader[2].ToString();
                string password = reader[3].ToString();
                emp = new Employee
                {
                    Id = id1,
                    Name = name,
                    Email = email,
                    Password = password
                };
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
        finally
        {
            con.Close();
        }
        return emp;
    }

    public static bool Insert(Employee emp)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "INSERT INTO employees VALUES (" + emp.Id + ",'" + emp.Name
            + "','" + emp.Email + "','" + emp.Password + "')";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            status = true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool Update(Employee emp)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;

        try
        {
            string query = "UPDATE employees SET name='" + emp.Name + "',email='" + emp.Email + "',password='" + emp.Password + "' WHERE id =" + emp.Id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool Delete(int id)
    {
        bool status = false;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;

        try
        {
            string query = "DELETE FROM employees WHERE id =" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

}
