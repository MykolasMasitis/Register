﻿using System;
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
        private const int prodStringLen = 50;

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
                    reader.GetValue(reader.GetOrdinal("pv")) != DBNull.Value ? (string)reader["pv"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("nz")) != DBNull.Value ? (string)reader["nz"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("status")) != DBNull.Value ? (byte)reader["status"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("p_doc")) != DBNull.Value ? (byte)reader["p_doc"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("p_doc2")) != DBNull.Value ? (byte)reader["p_doc2"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("vs")) != DBNull.Value ? (string)reader["vs"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("vs_data")) != DBNull.Value ? (DateTime?)reader["vs_data"] : null,
                    reader.GetValue(reader.GetOrdinal("sn_card")) != DBNull.Value ? (string)reader["sn_card"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("enp")) != DBNull.Value ? (string)reader["enp"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("gz_data")) != DBNull.Value ? (DateTime?)reader["gz_data"] : null,
                    reader.GetValue(reader.GetOrdinal("q")) != DBNull.Value ? (string)reader["q"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("dp")) != DBNull.Value ? (DateTime?)reader["dp"] : null,
                    reader.GetValue(reader.GetOrdinal("dt")) != DBNull.Value ? (DateTime?)reader["dt"] : null,
                    reader.GetValue(reader.GetOrdinal("fam")) != DBNull.Value ? (string)reader["fam"] : string.Empty,
                    (string)reader["d_type1"],
                    reader.GetValue(reader.GetOrdinal("im")) != DBNull.Value ? (string)reader["im"] : string.Empty,
                    (string)reader["d_type2"],
                    reader.GetValue(reader.GetOrdinal("ot")) != DBNull.Value ? (string)reader["ot"] : string.Empty,
                    (string)reader["d_type3"],
                    (byte)reader["w"],
                    reader.GetValue(reader.GetOrdinal("dr")) != DBNull.Value ? (DateTime?)reader["dr"] : null,
                    reader.GetValue(reader.GetOrdinal("true_dr")) != DBNull.Value ? (byte)reader["true_dr"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("adr_id")) != DBNull.Value ? (int)reader["adr_id"] : (int)0,
                    reader.GetValue(reader.GetOrdinal("adr50_id")) != DBNull.Value ? (int)reader["adr50_id"] : (int)0,
                    reader.GetValue(reader.GetOrdinal("jt")) != DBNull.Value ? (string)reader["jt"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("scn")) != DBNull.Value ? (string)reader["scn"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("kl")) != DBNull.Value ? (byte)reader["kl"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("cont")) != DBNull.Value ? (string)reader["cont"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("c_doc")) != DBNull.Value ? (byte)reader["c_doc"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("s_doc")) != DBNull.Value ? (string)reader["s_doc"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("n_doc")) != DBNull.Value ? (string)reader["n_doc"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("d_doc")) != DBNull.Value ? (DateTime?)reader["d_doc"] : null,
                    reader.GetValue(reader.GetOrdinal("e_doc")) != DBNull.Value ? (DateTime?)reader["e_doc"] : null,
                    reader.GetValue(reader.GetOrdinal("x_doc")) != DBNull.Value ? (byte)reader["x_doc"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("u_doc")) != DBNull.Value ? (string)reader["u_doc"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("snils")) != DBNull.Value ? (string)reader["snils"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("gr")) != DBNull.Value ? (string)reader["gr"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("mr")) != DBNull.Value ? (string)reader["mr"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("d_reg")) != DBNull.Value ? (DateTime?)reader["d_reg"] : null,
                    reader.GetValue(reader.GetOrdinal("form")) != DBNull.Value ? (byte)reader["form"] :(byte)0,
                    reader.GetValue(reader.GetOrdinal("predst")) != DBNull.Value ? (string)reader["predst"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("spos")) != DBNull.Value ? (byte)reader["spos"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("d_type4")) != DBNull.Value ? (byte)reader["d_type4"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("coment")) != DBNull.Value ? (string)reader["coment"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("ktg")) != DBNull.Value ? (string)reader["ktg"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("gzk_flag")) != DBNull.Value ? (byte)reader["gzk_flag"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("doc_flag")) != DBNull.Value ? (byte)reader["doc_flag"] : (byte)0,
                    reader.GetValue(reader.GetOrdinal("uec_flag")) != DBNull.Value ? (string)reader["uec_flag"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("s_card2")) != DBNull.Value ? (string)reader["s_card2"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("n_card2")) != DBNull.Value ? (string)reader["n_card2"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("is2fio")) != DBNull.Value ? (string)reader["is2fio"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("ofioid")) != DBNull.Value ? (int)reader["ofioid"] : (int)0,
                    reader.GetValue(reader.GetOrdinal("is2doc")) != DBNull.Value ? (string)reader["is2doc"] : string.Empty,
                    reader.GetValue(reader.GetOrdinal("odocid")) != DBNull.Value ? (int)reader["odocid"] : (int)0,
                    reader.GetValue(reader.GetOrdinal("mcod")) != DBNull.Value ? (string)reader["mcod"] : string.Empty,
                    !reader.IsDBNull(reader.GetOrdinal("oper")) ? (byte)reader["oper"] : new byte(),
                    reader.GetValue(reader.GetOrdinal("operpv")) != DBNull.Value ? (byte)reader["operpv"] : (byte)0,
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
                errorMessage = "GetPersonS error, " + ex.Message;
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

        public bool UpdatePerson(kms displayP)
        {
            kms p = displayP;
            hasError = false;

            SqlConnection con = new SqlConnection(App.conString);
            SqlCommand cmd = new SqlCommand("UpdatePerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@recid", SqlDbType.Int, 4);
            cmd.Parameters["@recid"].Value = p.recid;
            cmd.Parameters.Add("@act", SqlDbType.Bit);
            cmd.Parameters["@act"].Value = p.act;
            cmd.Parameters.Add("@pv", SqlDbType.VarChar, 3);
            cmd.Parameters["@pv"].Value = p.pv;
            cmd.Parameters.Add("@nz", SqlDbType.VarChar, 3);
            cmd.Parameters["@nz"].Value = p.nz;
            cmd.Parameters.Add("@status", SqlDbType.TinyInt);
            cmd.Parameters["@status"].Value = p.status;
            cmd.Parameters.Add("@p_doc", SqlDbType.TinyInt);
            cmd.Parameters["@p_doc"].Value = p.p_doc;
            cmd.Parameters.Add("@p_doc2", SqlDbType.TinyInt);
            cmd.Parameters["@p_doc2"].Value = p.p_doc2;
            cmd.Parameters.Add("@vs", SqlDbType.VarChar, 9);
            cmd.Parameters["@vs"].Value = p.vs;
            cmd.Parameters.Add("@vs_data", SqlDbType.Date);
            cmd.Parameters["@vs_data"].Value = p.vs_data;
            cmd.Parameters.Add("@sn_card", SqlDbType.VarChar, 17);
            cmd.Parameters["@sn_card"].Value = p.sn_card;
            cmd.Parameters.Add("@enp", SqlDbType.VarChar, 16);
            cmd.Parameters["@enp"].Value = p.enp;
            cmd.Parameters.Add("@gz_data", SqlDbType.Date);
            cmd.Parameters["@gz_data"].Value = p.gz_data;
            cmd.Parameters.Add("@q", SqlDbType.VarChar, 2);
            cmd.Parameters["@q"].Value = p.q;
            cmd.Parameters.Add("@dp", SqlDbType.Date);
            cmd.Parameters["@dp"].Value = p.dp;
            cmd.Parameters.Add("@dt", SqlDbType.Date);
            cmd.Parameters["@dt"].Value = p.dt;
            cmd.Parameters.Add("@fam", SqlDbType.VarChar, 40);
            cmd.Parameters["@fam"].Value = p.fam;
            cmd.Parameters.Add("@d_type1", SqlDbType.VarChar, 1);
            cmd.Parameters["@d_type1"].Value = p.d_type1;
            cmd.Parameters.Add("@im", SqlDbType.VarChar, 40);
            cmd.Parameters["@im"].Value = p.im;
            cmd.Parameters.Add("@d_type2", SqlDbType.VarChar, 1);
            cmd.Parameters["@d_type2"].Value = p.d_type2;
            cmd.Parameters.Add("@ot", SqlDbType.VarChar, 40);
            cmd.Parameters["@ot"].Value = p.ot;
            cmd.Parameters.Add("@d_type3", SqlDbType.VarChar, 1);
            cmd.Parameters["@d_type3"].Value = p.d_type3;
            cmd.Parameters.Add("@w", SqlDbType.TinyInt);
            cmd.Parameters["@w"].Value = p.w;
            cmd.Parameters.Add("@dr", SqlDbType.Date);
            cmd.Parameters["@dr"].Value = p.dr;
            cmd.Parameters.Add("@true_dr", SqlDbType.TinyInt);
            cmd.Parameters["@true_dr"].Value = p.true_dr;
            cmd.Parameters.Add("@adr_id", SqlDbType.Int, 4);
            cmd.Parameters["@adr_id"].Value = p.adr_id;
            cmd.Parameters.Add("@adr50_id", SqlDbType.Int, 4);
            cmd.Parameters["@adr50_id"].Value = p.adr50_id;
            cmd.Parameters.Add("@jt", SqlDbType.VarChar, 1);
            cmd.Parameters["@jt"].Value = p.jt;
            cmd.Parameters.Add("@scn", SqlDbType.VarChar, 1);
            cmd.Parameters["@scn"].Value = p.scn;
            cmd.Parameters.Add("@kl", SqlDbType.TinyInt);
            cmd.Parameters["@kl"].Value = p.kl;
            cmd.Parameters.Add("@cont", SqlDbType.VarChar, 40);
            cmd.Parameters["@cont"].Value = p.cont;
            cmd.Parameters.Add("@c_doc", SqlDbType.TinyInt);
            cmd.Parameters["@c_doc"].Value = p.c_doc;
            cmd.Parameters.Add("@s_doc", SqlDbType.VarChar, 9);
            cmd.Parameters["@s_doc"].Value = p.s_doc;
            cmd.Parameters.Add("@n_doc", SqlDbType.VarChar, 8);
            cmd.Parameters["@n_doc"].Value = p.n_doc;
            cmd.Parameters.Add("@d_doc", SqlDbType.Date);
            cmd.Parameters["@d_doc"].Value = p.d_doc;
            cmd.Parameters.Add("@e_doc", SqlDbType.Date);
            cmd.Parameters["@e_doc"].Value = p.e_doc;
            cmd.Parameters.Add("@x_doc", SqlDbType.TinyInt);
            cmd.Parameters["@x_doc"].Value = p.x_doc;
            cmd.Parameters.Add("@u_doc", SqlDbType.VarChar);
            cmd.Parameters["@u_doc"].Value = p.u_doc;
            cmd.Parameters.Add("@snils", SqlDbType.VarChar, 14);
            cmd.Parameters["@snils"].Value = p.snils;
            cmd.Parameters.Add("@gr", SqlDbType.VarChar, 3);
            cmd.Parameters["@gr"].Value = p.gr;
            cmd.Parameters.Add("@mr", SqlDbType.VarChar);
            cmd.Parameters["@mr"].Value = p.mr;
            cmd.Parameters.Add("@d_reg", SqlDbType.Date);
            cmd.Parameters["@d_reg"].Value = p.d_reg;
            cmd.Parameters.Add("@form", SqlDbType.TinyInt);
            cmd.Parameters["@form"].Value = p.form;
            cmd.Parameters.Add("@predst", SqlDbType.VarChar, 1);
            cmd.Parameters["@predst"].Value = p.predst;
            cmd.Parameters.Add("@spos", SqlDbType.TinyInt);
            cmd.Parameters["@spos"].Value = p.spos;
            cmd.Parameters.Add("@d_type4", SqlDbType.TinyInt);
            cmd.Parameters["@d_type4"].Value = p.d_type4;
            cmd.Parameters.Add("@coment", SqlDbType.VarChar);
            cmd.Parameters["@coment"].Value = p.coment;
            cmd.Parameters.Add("@ktg", SqlDbType.VarChar, 1);
            cmd.Parameters["@ktg"].Value = p.ktg;
            cmd.Parameters.Add("@gzk_flag", SqlDbType.TinyInt);
            cmd.Parameters["@gzk_flag"].Value = p.gzk_flag;
            cmd.Parameters.Add("@doc_flag", SqlDbType.TinyInt);
            cmd.Parameters["@doc_flag"].Value = p.doc_flag;
            cmd.Parameters.Add("@uec_flag", SqlDbType.VarChar, 1);
            cmd.Parameters["@uec_flag"].Value = p.uec_flag;
            cmd.Parameters.Add("@s_card2", SqlDbType.VarChar, 12);
            cmd.Parameters["@s_card2"].Value = p.s_card2;
            cmd.Parameters.Add("@n_card2", SqlDbType.VarChar, 32);
            cmd.Parameters["@n_card2"].Value = p.n_card2;
            cmd.Parameters.Add("@is2fio", SqlDbType.VarChar, 1);
            cmd.Parameters["@is2fio"].Value = p.is2fio;
            cmd.Parameters.Add("@ofioid", SqlDbType.Int, 4);
            cmd.Parameters["@ofioid"].Value = p.ofioid;
            cmd.Parameters.Add("@is2doc", SqlDbType.VarChar, 1);
            cmd.Parameters["@is2doc"].Value = p.is2doc;
            cmd.Parameters.Add("@odocid", SqlDbType.Int, 4);
            cmd.Parameters["@odocid"].Value = p.odocid;
            cmd.Parameters.Add("@mcod", SqlDbType.VarChar, 7);
            cmd.Parameters["@mcod"].Value = p.mcod;
            cmd.Parameters.Add("@oper", SqlDbType.TinyInt);
            cmd.Parameters["@oper"].Value = p.oper;
            cmd.Parameters.Add("@operpv", SqlDbType.TinyInt);
            cmd.Parameters["@operpv"].Value = p.operpv;
            cmd.Parameters.Add("@isrereg", SqlDbType.TinyInt);
            cmd.Parameters["@isrereg"].Value = p.isrereg;
            cmd.Parameters.Add("@osmoid", SqlDbType.Int, 4);
            cmd.Parameters["@osmoid"].Value = p.osmoid;
            cmd.Parameters.Add("@permid", SqlDbType.Int, 4);
            cmd.Parameters["@permid"].Value = p.permid;
            cmd.Parameters.Add("@perm2id", SqlDbType.Int, 4);
            cmd.Parameters["@perm2id"].Value = p.perm2id;
            cmd.Parameters.Add("@enp2id", SqlDbType.Int, 4);
            cmd.Parameters["@enp2id"].Value = p.enp2id;
            cmd.Parameters.Add("@predstid", SqlDbType.Int, 4);
            cmd.Parameters["@predstid"].Value = p.predstid;
            cmd.Parameters.Add("@wrkid", SqlDbType.Int, 4);
            cmd.Parameters["@wrkid"].Value = p.wrkid;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 5);
            cmd.Parameters["@plant"].Value = p.plant;
            cmd.Parameters.Add("@dpok", SqlDbType.Date);
            cmd.Parameters["@dpok"].Value = p.dpok;
            cmd.Parameters.Add("@blanc", SqlDbType.VarChar, 5);
            cmd.Parameters["@blanc"].Value = p.blanc;
            cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
            cmd.Parameters["@photo"].Value = p.photo;

            int rows = 0;
            try
            {
                con.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = "Update SQL error, " + ex.Message;
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            return (!hasError);
        } //UpdatePerson()

        public bool AddPerson(kms displayP)
        {
            kms p = displayP;
            hasError = false;
            SqlConnection con = new SqlConnection(App.conString);
            SqlCommand cmd = new SqlCommand("AddPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@recid", SqlDbType.Int, 4);
            cmd.Parameters["@recid"].Value = p.recid;
            cmd.Parameters["@recid"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@act", SqlDbType.Bit);
            cmd.Parameters["@act"].Value = p.act;
            cmd.Parameters.Add("@pv", SqlDbType.VarChar, 3);
            cmd.Parameters["@pv"].Value = p.pv;
            cmd.Parameters.Add("@nz", SqlDbType.VarChar, 3);
            cmd.Parameters["@nz"].Value = p.nz;
            cmd.Parameters.Add("@status", SqlDbType.TinyInt);
            cmd.Parameters["@status"].Value = p.status;
            cmd.Parameters.Add("@p_doc", SqlDbType.TinyInt);
            cmd.Parameters["@p_doc"].Value = p.p_doc;
            cmd.Parameters.Add("@p_doc2", SqlDbType.TinyInt);
            cmd.Parameters["@p_doc2"].Value = p.p_doc2;
            cmd.Parameters.Add("@vs", SqlDbType.VarChar, 9);
            cmd.Parameters["@vs"].Value = p.vs;
            cmd.Parameters.Add("@vs_data", SqlDbType.Date);
            cmd.Parameters["@vs_data"].Value = p.vs_data;
            cmd.Parameters.Add("@sn_card", SqlDbType.VarChar, 17);
            cmd.Parameters["@sn_card"].Value = p.sn_card;
            cmd.Parameters.Add("@enp", SqlDbType.VarChar, 16);
            cmd.Parameters["@enp"].Value = p.enp;
            cmd.Parameters.Add("@gz_data", SqlDbType.Date);
            cmd.Parameters["@gz_data"].Value = p.gz_data;
            cmd.Parameters.Add("@q", SqlDbType.VarChar, 2);
            cmd.Parameters["@q"].Value = p.q;
            cmd.Parameters.Add("@dp", SqlDbType.Date);
            cmd.Parameters["@dp"].Value = p.dp;
            cmd.Parameters.Add("@dt", SqlDbType.Date);
            cmd.Parameters["@dt"].Value = p.dt;
            cmd.Parameters.Add("@fam", SqlDbType.VarChar, 40);
            cmd.Parameters["@fam"].Value = p.fam;
            cmd.Parameters.Add("@d_type1", SqlDbType.VarChar, 1);
            cmd.Parameters["@d_type1"].Value = p.d_type1;
            cmd.Parameters.Add("@im", SqlDbType.VarChar, 40);
            cmd.Parameters["@im"].Value = p.im;
            cmd.Parameters.Add("@d_type2", SqlDbType.VarChar, 1);
            cmd.Parameters["@d_type2"].Value = p.d_type2;
            cmd.Parameters.Add("@ot", SqlDbType.VarChar, 40);
            cmd.Parameters["@ot"].Value = p.ot;
            cmd.Parameters.Add("@d_type3", SqlDbType.VarChar, 1);
            cmd.Parameters["@d_type3"].Value = p.d_type3;
            cmd.Parameters.Add("@w", SqlDbType.TinyInt);
            cmd.Parameters["@w"].Value = p.w;
            cmd.Parameters.Add("@dr", SqlDbType.Date);
            cmd.Parameters["@dr"].Value = p.dr;
            cmd.Parameters.Add("@true_dr", SqlDbType.TinyInt);
            cmd.Parameters["@true_dr"].Value = p.true_dr;
            cmd.Parameters.Add("@adr_id", SqlDbType.Int, 4);
            cmd.Parameters["@adr_id"].Value = p.adr_id;
            cmd.Parameters.Add("@adr50_id", SqlDbType.Int, 4);
            cmd.Parameters["@adr50_id"].Value = p.adr50_id;
            cmd.Parameters.Add("@jt", SqlDbType.VarChar, 1);
            cmd.Parameters["@jt"].Value = p.jt;
            cmd.Parameters.Add("@scn", SqlDbType.VarChar, 1);
            cmd.Parameters["@scn"].Value = p.scn;
            cmd.Parameters.Add("@kl", SqlDbType.TinyInt);
            cmd.Parameters["@kl"].Value = p.kl;
            cmd.Parameters.Add("@cont", SqlDbType.VarChar, 40);
            cmd.Parameters["@cont"].Value = p.cont;
            cmd.Parameters.Add("@c_doc", SqlDbType.TinyInt);
            cmd.Parameters["@c_doc"].Value = p.c_doc;
            cmd.Parameters.Add("@s_doc", SqlDbType.VarChar, 9);
            cmd.Parameters["@s_doc"].Value = p.s_doc;
            cmd.Parameters.Add("@n_doc", SqlDbType.VarChar, 8);
            cmd.Parameters["@n_doc"].Value = p.n_doc;
            cmd.Parameters.Add("@d_doc", SqlDbType.Date);
            cmd.Parameters["@d_doc"].Value = p.d_doc;
            cmd.Parameters.Add("@e_doc", SqlDbType.Date);
            cmd.Parameters["@e_doc"].Value = p.e_doc;
            cmd.Parameters.Add("@x_doc", SqlDbType.TinyInt);
            cmd.Parameters["@x_doc"].Value = p.x_doc;
            cmd.Parameters.Add("@u_doc", SqlDbType.VarChar);
            cmd.Parameters["@u_doc"].Value = p.u_doc;
            cmd.Parameters.Add("@snils", SqlDbType.VarChar, 14);
            cmd.Parameters["@snils"].Value = p.snils;
            cmd.Parameters.Add("@gr", SqlDbType.VarChar, 3);
            cmd.Parameters["@gr"].Value = p.gr;
            cmd.Parameters.Add("@mr", SqlDbType.VarChar);
            cmd.Parameters["@mr"].Value = p.mr;
            cmd.Parameters.Add("@d_reg", SqlDbType.Date);
            cmd.Parameters["@d_reg"].Value = p.d_reg;
            cmd.Parameters.Add("@form", SqlDbType.TinyInt);
            cmd.Parameters["@form"].Value = p.form;
            cmd.Parameters.Add("@predst", SqlDbType.VarChar, 1);
            cmd.Parameters["@predst"].Value = p.predst;
            cmd.Parameters.Add("@spos", SqlDbType.TinyInt);
            cmd.Parameters["@spos"].Value = p.spos;
            cmd.Parameters.Add("@d_type4", SqlDbType.TinyInt);
            cmd.Parameters["@d_type4"].Value = p.d_type4;
            cmd.Parameters.Add("@coment", SqlDbType.VarChar);
            cmd.Parameters["@coment"].Value = p.coment;
            cmd.Parameters.Add("@ktg", SqlDbType.VarChar, 1);
            cmd.Parameters["@ktg"].Value = p.ktg;
            cmd.Parameters.Add("@gzk_flag", SqlDbType.TinyInt);
            cmd.Parameters["@gzk_flag"].Value = p.gzk_flag;
            cmd.Parameters.Add("@doc_flag", SqlDbType.TinyInt);
            cmd.Parameters["@doc_flag"].Value = p.doc_flag;
            cmd.Parameters.Add("@uec_flag", SqlDbType.VarChar, 1);
            cmd.Parameters["@uec_flag"].Value = p.uec_flag;
            cmd.Parameters.Add("@s_card2", SqlDbType.VarChar, 12);
            cmd.Parameters["@s_card2"].Value = p.s_card2;
            cmd.Parameters.Add("@n_card2", SqlDbType.VarChar, 32);
            cmd.Parameters["@n_card2"].Value = p.n_card2;
            cmd.Parameters.Add("@is2fio", SqlDbType.VarChar, 1);
            cmd.Parameters["@is2fio"].Value = p.is2fio;
            cmd.Parameters.Add("@ofioid", SqlDbType.Int, 4);
            cmd.Parameters["@ofioid"].Value = p.ofioid;
            cmd.Parameters.Add("@is2doc", SqlDbType.VarChar, 1);
            cmd.Parameters["@is2doc"].Value = p.is2doc;
            cmd.Parameters.Add("@odocid", SqlDbType.Int, 4);
            cmd.Parameters["@odocid"].Value = p.odocid;
            cmd.Parameters.Add("@mcod", SqlDbType.VarChar, 7);
            cmd.Parameters["@mcod"].Value = p.mcod;
            cmd.Parameters.Add("@oper", SqlDbType.TinyInt);
            cmd.Parameters["@oper"].Value = p.oper;
            cmd.Parameters.Add("@operpv", SqlDbType.TinyInt);
            cmd.Parameters["@operpv"].Value = p.operpv;
            cmd.Parameters.Add("@isrereg", SqlDbType.TinyInt);
            cmd.Parameters["@isrereg"].Value = p.isrereg;
            cmd.Parameters.Add("@osmoid", SqlDbType.Int, 4);
            cmd.Parameters["@osmoid"].Value = p.osmoid;
            cmd.Parameters.Add("@permid", SqlDbType.Int, 4);
            cmd.Parameters["@permid"].Value = p.permid;
            cmd.Parameters.Add("@perm2id", SqlDbType.Int, 4);
            cmd.Parameters["@perm2id"].Value = p.perm2id;
            cmd.Parameters.Add("@enp2id", SqlDbType.Int, 4);
            cmd.Parameters["@enp2id"].Value = p.enp2id;
            cmd.Parameters.Add("@predstid", SqlDbType.Int, 4);
            cmd.Parameters["@predstid"].Value = p.predstid;
            cmd.Parameters.Add("@wrkid", SqlDbType.Int, 4);
            cmd.Parameters["@wrkid"].Value = p.wrkid;
            cmd.Parameters.Add("@plant", SqlDbType.VarChar, 5);
            cmd.Parameters["@plant"].Value = p.plant;
            cmd.Parameters.Add("@dpok", SqlDbType.Date);
            cmd.Parameters["@dpok"].Value = p.dpok;
            cmd.Parameters.Add("@blanc", SqlDbType.VarChar, 5);
            cmd.Parameters["@blanc"].Value = p.blanc;
            cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
            cmd.Parameters["@photo"].Value = p.photo;

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();                       //create the new product in DB
                //p.ProductId = (int)cmd.Parameters["@ProductId"].Value;  //set the returned ProductId in the SqlProduct object
                //displayP.ProductAdded2DB(p);                            //update corresponding Product ProductId using SqlProduct
            }
            catch (SqlException ex)
            {
                errorMessage = "Add SQL error, " + ex.Message;
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "ADD error, " + ex.Message;
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            return !hasError;
        } //AddProduct()

        public bool DeletePerson(int recid) 
        {
            hasError = false;
            SqlConnection con = new SqlConnection(App.conString);
            SqlCommand cmd = new SqlCommand("DeletePerson", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@recid", SqlDbType.Int, 4);
            cmd.Parameters["@recid"].Value = recid;
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = "DELETE SQL error, " + ex.Message;
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "DELETE error, " + ex.Message;
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            return !hasError;
        }// DeleteProduct()

    } //class StoreDB
} //namespace
