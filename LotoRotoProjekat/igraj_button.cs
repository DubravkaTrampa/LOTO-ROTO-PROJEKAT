using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LotoRotoProjekat
{
    public class igraj_button
    {

        public igraj_button() { }
        public DataTable CreateDataSource()
        {
            DataTable dt = new DataTable();
            DataColumn identity = new DataColumn("ID", typeof(int));
            dt.Columns.Add(identity);
            dt.Columns.Add("Name", typeof(string));
            return dt;
        }
        //This is the AddRow method to add a new row in Table dt 
        public void AddRow(int id, string name, DataTable dt)
        {
            dt.Rows.Add(new object[] { id, name });
        }

    }
}