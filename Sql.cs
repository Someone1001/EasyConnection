using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace EasyConnection
{
    public class Sql
    {
        public static void SendQuery(SqlConnection con, string command)
        {
            SqlCommand com = new SqlCommand(command, con);
            con.Open();
            com.ExecuteReader();
            con.Close();
        }

        public static string[] GetRow(SqlConnection con, string command)
        {
            SqlCommand com = new SqlCommand(command);
            con.Open();
            SqlDataReader sqlReader = com.ExecuteReader();
            int count = sqlReader.FieldCount;
            string[] var = new string[count];
            if (sqlReader.HasRows)
            {
                sqlReader.Read();


                for (int i = 0; i < count; i++)
                    var[i] = sqlReader[i].ToString();
                con.Close();
                return var;
            }
            else
            {
                string[] error = { "Error" };
                con.Close();
                return error;
            }

        }

        public static int GetRowCount(SqlConnection con, string table)
        {
            SqlCommand com = new SqlCommand(String.Format("Select count(*) from {0};",table) , con);
            con.Open();
            SqlDataReader sqlReader = com.ExecuteReader();
            sqlReader.Read();
            int count = sqlReader.GetInt32(0);
            con.Close();
            return count;
        }





    }
}
