using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace EasyConnection
{
    public class Sql
    {
        public static void SendQuery(string CS, string command)
        {
            SqlConnection con = new SqlConnection(CS);
            SqlCommand com = new SqlCommand(command, con);
            con.Open();
            com.ExecuteReader();
            con.Close();
        }

        public static string[] GetRow(string CS, string table , string condition)
        {
            SqlConnection con = new SqlConnection(CS);
            SqlCommand com = new SqlCommand(String.Format("select * from {0} where {1}",table,condition), con);
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

        //public static string[] GetRow(string CS, string table , int primaryKey) 
        //{
          

        //}
    }
}
