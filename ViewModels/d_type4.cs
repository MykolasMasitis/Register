using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Register.ViewModels
{
    public class d_type4
    {
        public int recid { get; private set; }
        public string code { get; set; }
        public string name { get; set; }

        public d_type4(SqlDataReader reader)
        {
            recid = reader.GetInt32(reader.GetOrdinal("recid"));

            if (reader.GetValue(reader.GetOrdinal("code")) != DBNull.Value)
                code = reader.GetString(reader.GetOrdinal("code"));

            if (reader.GetValue(reader.GetOrdinal("name")) != DBNull.Value)
                name = reader.GetString(reader.GetOrdinal("name"));

        }

        public static List<d_type4> dT4List(string strConn)
        {
            List<d_type4> list = new List<d_type4>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlDataReader dr = null;
                SqlCommand command = new SqlCommand(qLoad, conn);
                try
                {
                    dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (dr.Read()) list.Add(new d_type4(dr));
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                finally { if (dr != null) dr.Close(); }
            }
            return list;
        }

        public static void FillComboBox(ComboBox cmb, string strConn)
        {
            cmb.Items.Clear();
            foreach (d_type4 stt in dT4List(strConn)) cmb.Items.Add(stt);
        }

        public static string qLoad { get { return "select * from [nsi].[d_type4]"; } }
    }
}
