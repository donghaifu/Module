using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;


namespace npsql
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        private static void test()
        {
            using (var conn = new NpgsqlConnection("Host=192.168.1.35;Username=postgres;Password=Ytogroup1234567;Database=testdb"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data
                    //cmd.CommandText = "INSERT INTO data (some_field) VALUES ('Hello world')";
                    //cmd.ExecuteNonQuery();

                    // Retrieve all rows

                    cmd.CommandText = "SELECT OwnerName FROM public.ownerlist ORDER BY ownerno ASC";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0));
                        }
                    }
                }
            }         
        
        
        }



    }
}
