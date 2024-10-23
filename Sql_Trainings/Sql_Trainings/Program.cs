using System;
using System.Data.SqlClient;

namespace Sql_Trainings
{
    class Program
    {
        
        static String connectionString = "Server=SG-LT-N1166\\SQLEXPRESS;Database=CustomerDB;Trusted_Connection=True;";

        static void Main()
        {
            
            while (true)
            {
                Console.WriteLine("Choose a Number:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View Data");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Phone: ");
                            string phone = Console.ReadLine();
                            AddData(name, email, phone);
                            break;
                        case "2":
                            GetData();
                            break;
                        case "3":
                            Console.Write("Enter Customer Id : ");
                            int updateId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string newEmail = Console.ReadLine();
                            Console.Write("Enter Phone: ");
                            string newPhone = Console.ReadLine();
                            UpdateData(updateId, newName, newEmail, newPhone);
                            break;
                        case "4":
                            Console.Write("Enter Customer Id :");
                            int deleteId = int.Parse(Console.ReadLine());
                            DeleteData(deleteId);
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("please choose from above numbers only");
                    Console.WriteLine($"An error occured:{ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        
        static void AddData(string name, string email, string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Customers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Customer added successfully.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"error occurred : {ex.Message}");
            }
        }

        
        static void GetData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Customers";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Id"]} - {reader["Name"]} - {reader["Email"]} - {reader["Phone"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"error occurred : {ex.Message}");
            }
        }

        
        static void UpdateData(int id, string name, string email, string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Customers SET Name=@Name, Email=@Email, Phone=@Phone WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("update completed");
                    }
                    else
                    {
                        Console.WriteLine("Data not found");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"error occurred : {ex.Message}");
            }
        }

        
        static void DeleteData(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Customers WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Customer deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("record with id not found");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"error occured : {ex.Message}");
            }
        }
    }
}
