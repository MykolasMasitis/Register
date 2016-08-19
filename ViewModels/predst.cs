using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Register.ViewModels
{
    class predst
    {
        public int recid { get; private set; }
        public string code { get; set; }
        public string name { get; set; }

        public predst(SqlDataReader reader)
        {
            recid = reader.GetInt32(reader.GetOrdinal("recid"));

            if (reader.GetValue(reader.GetOrdinal("code")) != DBNull.Value)
                code = reader.GetString(reader.GetOrdinal("code"));

            if (reader.GetValue(reader.GetOrdinal("name")) != DBNull.Value)
                name = reader.GetString(reader.GetOrdinal("name"));
        }

        public static List<predst> PredstList(string strConn)
        {
            List<predst> list = new List<predst>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlDataReader dr = null;
                SqlCommand command = new SqlCommand(qLoad, conn);
                try
                {
                    dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (dr.Read()) list.Add(new predst(dr));
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
            foreach (predst stt in PredstList(strConn)) cmb.Items.Add(stt);
        }

        public static string qLoad { get { return "select * from [nsi].[predst]"; } }
    }
}
