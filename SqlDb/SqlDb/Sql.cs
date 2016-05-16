using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SqlDb
{
    public class Sql
    {
        private static Sql instance;
        public static Sql Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sql();
                }
                return instance;
            }
        }


        public static Sql GetInstance()
        {
            return Instance;
        }

        private SqlConnection sqlCon;
        private SqlCommand sqlCmd;

        public void Connect(string ServerName, string InitialCatalog)
        {
            sqlCon = new SqlConnection(string.Format("Server={0};Database={1};Trusted_Connection=True;", ServerName, InitialCatalog));
            Connect();
        }
        public void Connect(string ServerName, String InitialCatalog, string Username, string Password)
        {
            sqlCon = new SqlConnection(string.Format("Server={0};Database={1};User Id={2};Password = {3};", ServerName, InitialCatalog, Username, Password));
            Connect();
        }

        public void Connect()
        {
            try
            {
                sqlCon.Open();
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Execute(string CommandText, params SqlParameter[] parameters)
        {
            sqlCmd = sqlCon.CreateCommand();
            sqlCmd.CommandText = CommandText;
            sqlCmd.Parameters.AddRange(parameters);
            try
            {
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Execute(string CommandText, params object[] list)
        {
            List<SqlParameter> paramaters = new List<SqlParameter>();
            for (int i = 0; i < list.Length - 1; i = i + 2)
            {
                paramaters.Add(new SqlParameter(list[i].ToString(), list[i + 1]));
            }
            Execute(CommandText, paramaters.ToArray());
        }

        public DataTable Query(string CommandText, params SqlParameter[] parameters)
        {
            sqlCmd = sqlCon.CreateCommand();
            sqlCmd.CommandText = CommandText;
            sqlCmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
            {
                try
                {
                    sqlCon.Open();
                    adapter.Fill(dt);
                    sqlCon.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return dt;
            }
        }

        public DataTable Query(string CommandText, params object[] list)
        {
            List<SqlParameter> paramaters = new List<SqlParameter>();
            for (int i = 0; i < list.Length - 1; i = i + 2)
            {
                paramaters.Add(new SqlParameter(list[i].ToString(), list[i + 1]));
            }
            return Query(CommandText, paramaters.ToArray());
        }
    }
}
