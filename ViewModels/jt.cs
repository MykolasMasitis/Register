using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Register.ViewModels
{
    public class jt 
    {
        public int recid { get; private set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool add { get; set; }
        public bool mod { get; set; }
        public bool izgt { get; set; }

        public jt(SqlDataReader reader)
        {
            recid = reader.GetInt32(reader.GetOrdinal("recid"));

            if (reader.GetValue(reader.GetOrdinal("code")) != DBNull.Value)
                code = reader.GetString(reader.GetOrdinal("code"));

            if (reader.GetValue(reader.GetOrdinal("name")) != DBNull.Value)
                name = reader.GetString(reader.GetOrdinal("name"));

            if (reader.GetValue(reader.GetOrdinal("add")) != DBNull.Value)
                add = reader.GetBoolean(reader.GetOrdinal("add"));

            if (reader.GetValue(reader.GetOrdinal("mod")) != DBNull.Value)
                mod = reader.GetBoolean(reader.GetOrdinal("mod"));

            if (reader.GetValue(reader.GetOrdinal("izgt")) != DBNull.Value)
                izgt = reader.GetBoolean(reader.GetOrdinal("izgt"));
        }

        public static List<jt> JtList(string strConn)
        {
            List<jt> list = new List<jt>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlDataReader dr = null;
                SqlCommand command = new SqlCommand(qLoad, conn);
                try
                {
                    dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (dr.Read()) list.Add(new jt(dr));
                }
                finally { if (dr != null) dr.Close(); }
            }
            return list;
        }

        public static void FillComboBox(ComboBox cmb, string strConn)
        {
            cmb.Items.Clear();
            foreach (jt stt in JtList(strConn)) cmb.Items.Add(stt);
        }

        public static string qLoad { get { return "select * from [nsi].[jt]"; } }
    }
}
