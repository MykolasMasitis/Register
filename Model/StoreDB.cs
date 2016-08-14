using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Register;
using Register.ViewModels;

namespace Register.Model
{
    public class StoreDB
    {
        public bool hasError = false;
        public string errorMessage;

        private string GetStringOrNull(SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? "" : (string)reader[columnName];
        }

        public MyObservableCollection<kms> GetPersons()
        {
            hasError = false;
            SqlConnection con = new SqlConnection(App.conString);
            SqlCommand cmd = new SqlCommand("select top(100) * from kms", con);
            cmd.CommandType = CommandType.Text;

            MyObservableCollection<kms> persons = new MyObservableCollection<kms>();

            int nrecs = 0;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                kms person = new kms(
                    (int)reader["recid"],
                    (bool)reader["act"],
                    (string)reader["pv"],
                    (string)reader["nz"],
                    (byte)reader["status"],
                    (byte)reader["p_doc"],
                    (byte)reader["p_doc2"],
                    (string)reader["vs"],
                    reader.GetValue(reader.GetOrdinal("vs_data")) != DBNull.Value ? (DateTime?)reader["vs_data"] : null,
                    (string)reader["sn_card"],
                    (string)reader["enp"],
                    reader.GetValue(reader.GetOrdinal("gz_data")) != DBNull.Value ? (DateTime?)reader["gz_data"] : null,
                    (string)reader["q"],
                    reader.GetValue(reader.GetOrdinal("dp")) != DBNull.Value ? (DateTime?)reader["dp"] : null,
                    reader.GetValue(reader.GetOrdinal("dt")) != DBNull.Value ? (DateTime?)reader["dt"] : null,
                        (string)reader["fam"], (string)reader["d_type1"],
                        (string)reader["im"], (string)reader["d_type2"],
                        (string)reader["ot"], (string)reader["d_type3"],
                    (byte)reader["w"],
                    reader.GetValue(reader.GetOrdinal("dr")) != DBNull.Value ? (DateTime?)reader["dr"] : null,
                    reader.GetValue(reader.GetOrdinal("true_dr")) != DBNull.Value ? (byte)reader["true_dr"] : new byte(),
                    (int?)reader["adr_id"],
                    (int?)reader["adr50_id"],
                    (string)reader["jt"],
                    (string)reader["scn"],
                    reader.GetValue(reader.GetOrdinal("kl")) != DBNull.Value ? (byte)reader["kl"] : new byte(),
                    (string)reader["cont"],
                    reader.GetValue(reader.GetOrdinal("c_doc")) != DBNull.Value ? (byte)reader["c_doc"] : new byte(),
                    (string)reader["s_doc"],
                    (string)reader["n_doc"],
                    reader.GetValue(reader.GetOrdinal("d_doc")) != DBNull.Value ? (DateTime?)reader["d_doc"] : null,
                    reader.GetValue(reader.GetOrdinal("e_doc")) != DBNull.Value ? (DateTime?)reader["e_doc"] : null,
                    reader.GetValue(reader.GetOrdinal("x_doc")) != DBNull.Value ? (byte)reader["x_doc"] : new byte(),
                    (string)reader["u_doc"],
                    (string)reader["snils"],
                    (string)reader["gr"],
                    (string)reader["mr"],
                    reader.GetValue(reader.GetOrdinal("d_reg")) != DBNull.Value ? (DateTime?)reader["d_reg"] : null,
                    (byte)reader["form"],
                    (string)reader["predst"],
                    (byte)reader["spos"],
                    (byte)reader["d_type4"],
                    (string)reader["coment"],
                    (string)reader["ktg"],
                    (byte)reader["gzk_flag"],
                    (byte)reader["doc_flag"],
                    (string)reader["uec_flag"],
                    (string)reader["s_card2"],
                    (string)reader["n_card2"],
                    (string)reader["is2fio"],
                    (int?)reader["ofioid"],
                    (string)reader["is2doc"],
                    (int?)reader["odocid"],
                    (string)reader["mcod"],
                    !reader.IsDBNull(reader.GetOrdinal("oper")) ? (byte)reader["oper"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("operpv")) != DBNull.Value ? (byte)reader["operpv"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("isrereg")) != DBNull.Value ? (byte)reader["isrereg"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("osmoid")) != DBNull.Value ? (int)reader["osmoid"] : new int(),
                    reader.GetValue(reader.GetOrdinal("permid")) != DBNull.Value ? (int)reader["permid"] : new int(),
                    reader.GetValue(reader.GetOrdinal("perm2id")) != DBNull.Value ? (int)reader["perm2id"] : new int(),
                    reader.GetValue(reader.GetOrdinal("enp2id")) != DBNull.Value ? (int)reader["enp2id"] : new int(),
                    reader.GetValue(reader.GetOrdinal("predstid")) != DBNull.Value ? (int)reader["predstid"] : new int(),
                    reader.GetValue(reader.GetOrdinal("wrkid")) != DBNull.Value ? (int)reader["wrkid"] : new int(),
                    reader.GetValue(reader.GetOrdinal("plant")) != DBNull.Value ? (string)reader["plant"] : String.Empty,
                    reader.GetValue(reader.GetOrdinal("dpok")) != DBNull.Value ? (DateTime?)reader["dpok"] : null,
                    reader.GetValue(reader.GetOrdinal("blanc")) != DBNull.Value ? (string)reader["blanc"] : String.Empty,
                    (DateTime)reader["created"]
                    );
                    persons.Add(person);
                    nrecs++;
                }

            }
            catch(SqlException ex)
            {
                errorMessage = "GetPerson SQL error, " + ex.Message;
                MessageBox.Show(errorMessage);
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "GetPerson error, " + ex.Message;
                MessageBox.Show(errorMessage);
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            //MessageBox.Show(nrecs.ToString());
            return persons;
        } //GetPersons()
    } //class StoreDB
} //namespace
