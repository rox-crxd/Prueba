using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.CodeDom;
using System.Data.SqlClient;

namespace Prueba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

            Console.WriteLine(cadena);
            SqlConnection conn = null;
            SqlCommand cmd;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(cadena);
                conn.Open();
                cmd = new SqlCommand("usp_prueba", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
                 }
                catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            Console.ReadKey();
            }
    }
}
