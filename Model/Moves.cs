using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using Register.ViewModels;

namespace Register.Model
{
    public class Moves 
    {
        public bool hasError = false;
        public string errorMessage;

        public MoveObservableCollection<move> GetMoves(int id) 
        {
            hasError = false;
            SqlConnection con = new SqlConnection(App.conString);
            SqlCommand cmd = new SqlCommand("select * from moves where kmsid=@id", con); /* ??? */
            cmd.Parameters.Add("@id", SqlDbType.Int, 4);
            cmd.Parameters["@id"].Value = id;
            cmd.CommandType = CommandType.Text;

            MoveObservableCollection<move> moves = new MoveObservableCollection<move>();

            int nrecs = 0;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    move move = new move(
                        (int)reader["recid"],
                        reader.GetValue(reader.GetOrdinal("et")) != DBNull.Value ? (string)reader["et"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("fname")) != DBNull.Value ? (string)reader["fname"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("mkdate")) != DBNull.Value ? (DateTime?)reader["mkdate"] : null,
                        (int)reader["kmsid"],
                        reader.GetValue(reader.GetOrdinal("frecid")) != DBNull.Value ? (string)reader["frecid"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("vs")) != DBNull.Value ? (string)reader["vs"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("s_card")) != DBNull.Value ? (string)reader["s_card"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("n_card")) != DBNull.Value ? (string)reader["n_card"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("c_okato")) != DBNull.Value ? (string)reader["c_okato"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("enp")) != DBNull.Value ? (string)reader["enp"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("dp")) != DBNull.Value ? (DateTime?)reader["dp"] : null,
                        reader.GetValue(reader.GetOrdinal("jt")) != DBNull.Value ? (string)reader["jt"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("scn")) != DBNull.Value ? (string)reader["scn"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("pricin")) != DBNull.Value ? (string)reader["pricin"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("tranz")) != DBNull.Value ? (string)reader["tranz"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("q")) != DBNull.Value ? (string)reader["q"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("err")) != DBNull.Value ? (string)reader["err"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("err_text")) != DBNull.Value ? (string)reader["err_text"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("ans_fl")) != DBNull.Value ? (string)reader["ans_fl"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("nz")) != DBNull.Value ? (short)reader["nz"] : (int)0,
                        reader.GetValue(reader.GetOrdinal("n_kor")) != DBNull.Value ? (int)reader["n_kor"] : (int)0,
                        reader.GetValue(reader.GetOrdinal("fam")) != DBNull.Value ? (string)reader["fam"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("im")) != DBNull.Value ? (string)reader["im"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("ot")) != DBNull.Value ? (string)reader["ot"] : string.Empty,
                        (byte)reader["w"],
                        reader.GetValue(reader.GetOrdinal("dr")) != DBNull.Value ? (DateTime?)reader["dr"] : null,
                        reader.GetValue(reader.GetOrdinal("c_doc")) != DBNull.Value ? (byte)reader["c_doc"] : new byte(),
                        reader.GetValue(reader.GetOrdinal("s_doc")) != DBNull.Value ? (string)reader["s_doc"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("n_doc")) != DBNull.Value ? (string)reader["n_doc"] : string.Empty,
                        reader.GetValue(reader.GetOrdinal("d_doc")) != DBNull.Value ? (DateTime?)reader["d_doc"] : null,
                        reader.GetValue(reader.GetOrdinal("e_doc")) != DBNull.Value ? (DateTime?)reader["e_doc"] : null,
                        (DateTime)reader["created"]
                        );
                    moves.Add(move);
                    nrecs++;
                }

            }
            catch (SqlException ex)
            {
                errorMessage = "GetMoves SQL error, " + ex.Message;
                MessageBox.Show(errorMessage);
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "GetMoves error, " + ex.Message;
                MessageBox.Show(errorMessage);
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            //MessageBox.Show(nrecs.ToString());
            return moves;
        } //GetMoves()

        public bool UpdateMove(kms displayP)
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
            cmd.Parameters.Add("@ul", SqlDbType.Int, 4);
            cmd.Parameters["@ul"].Value = p.ul;
            cmd.Parameters.Add("@dom", SqlDbType.VarChar, 7);
            cmd.Parameters["@dom"].Value = p.dom;
            cmd.Parameters.Add("@kor", SqlDbType.VarChar, 5);
            cmd.Parameters["@kor"].Value = p.kor;
            cmd.Parameters.Add("@str", SqlDbType.VarChar, 5);
            cmd.Parameters["@str"].Value = p.str;
            cmd.Parameters.Add("@kv", SqlDbType.VarChar, 5);
            cmd.Parameters["@kv"].Value = p.kv;

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

        public bool AddMove(kms displayP)
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

        public bool DeleteMove(int recid)
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

    } //class Moves
} //namespace
