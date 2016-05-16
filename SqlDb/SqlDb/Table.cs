using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDb
{
    public class Table
    {
        public string Name { get; private set; }
        public string Schema { get; private set; }

        public Table(string Name, string Schema = "dbo")
        {
            this.Name = Name;
            this.Schema = Schema;
        }

        public override string ToString()
        {
            return string.Format("[{0}].[{1}]", this.Schema, this.Name);
        }

        public bool Exists()
        {
          return new Table("TABLES", "INFORMATION_SCHEMA").Select("*", "TABLE_NAME = @Table AND TABLE_SCHEMA = @Schema", "Table", this.Name, "Schema", this.Schema).Rows.Count == 1;
        }

        public DataTable Select(string What = "*", string Where = "", params object[] list)
        {
            return Sql.Instance.Query(string.Format("select {0} from {1} {2}", What, ToString(), !string.IsNullOrEmpty(Where) ? "where " + Where : ""), list);
        }
    }
}
