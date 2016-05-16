using SqlDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Sql.Instance.Connect("CTU-PD", "BI");
            Table Students = new Table("Students");
            Console.WriteLine(Students.Exists());
            DataTable dt = Students.Select();
            foreach(DataRow row in dt.Rows)
            {
                foreach(DataColumn col in dt.Columns)
                {
                    Console.WriteLine(string.Format("[{0}]: {1}", col.ColumnName, row[col]));
                }
            }
        }
    }
}
