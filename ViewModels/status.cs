using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Register.ViewModels
{
    public class status
    {
        public int recid { get; private set; }
        public byte code { get; set; }
        public string name { get; set; }
        public bool used { get; set; }

        public status(SqlDataReader reader)
        {
            recid = reader.GetInt32(reader.GetOrdinal("recid"));

            if (reader.GetValue(reader.GetOrdinal("code")) != DBNull.Value)
                code = reader.GetByte(reader.GetOrdinal("code"));

            if (reader.GetValue(reader.GetOrdinal("name")) != DBNull.Value)
                name = reader.GetString(reader.GetOrdinal("name")).PadLeft(25);

            if (reader.GetValue(reader.GetOrdinal("used")) != DBNull.Value)
                used = reader.GetBoolean(reader.GetOrdinal("used"));
        }

        public static List<status> StatusList(string strConn)
        {
            List<status> list = new List<status>();
            using(SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlDataReader dr = null;
                SqlCommand command = new SqlCommand(qLoad, conn);
                try
                {
                    dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (dr.Read()) list.Add(new status(dr));
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
            foreach (status stt in StatusList(strConn)) cmb.Items.Add(stt);
        }

        public static string qLoad { get { return "select * from [nsi].[status]"; } }
    }
}
