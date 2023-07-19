using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleBB
    {
        private SqlConnection cns;
        public HandleBB(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle Bills ban
        public List<bills_ban> GAAGI(int id, string t)
        {
            List<bills_ban> Listlsp = new List<bills_ban>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_bb", cns);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@id_kh", "sss");
            com.Parameters.AddWithValue("@date_order", "2001-01-15");
            com.Parameters.AddWithValue("@tong_tien", 0);
            com.Parameters.AddWithValue("@payment", "sss");
            com.Parameters.AddWithValue("@status", "sss");
            com.Parameters.AddWithValue("@note", "sss");
            com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new bills_ban
                    {
                        id = Convert.ToInt32(dr["id"]),
                        id_kh = Convert.ToInt32(dr["id_kh"]),
                        date_order = DateTime.Parse(dr["date_order"].ToString()),
                        tong_tien = Convert.ToInt32(dr["tong_tien"]),
                        payment = dr["payment"].ToString(),
                        status = dr["status"].ToString(),
                        note = dr["note"].ToString()
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(bills_ban bb, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_bb", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", bb.id);
                com.Parameters.AddWithValue("@id_kh", bb.id_kh);
                com.Parameters.AddWithValue("@date_order", bb.date_order);
                com.Parameters.AddWithValue("@tong_tien", bb.tong_tien);
                com.Parameters.AddWithValue("@payment", bb.payment);
                com.Parameters.AddWithValue("@status", bb.status);
                com.Parameters.AddWithValue("@note", bb.note);
                com.Parameters.AddWithValue("@type", t);
                com.ExecuteNonQuery();
                cns.Close();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (cns.State == ConnectionState.Open)
                {
                    cns.Close();
                }
            }
        }
        /// GET ID current of bill ban
        public DataSet Gidcbb(out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getcurrentidofbb", cns);
                com.CommandType = CommandType.StoredProcedure;
                cns.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                cns.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
























        //public string CRUDbb(bills_ban sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bb", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_kh", sp.id_kh);
        //        com.Parameters.AddWithValue("@date_order", sp.date_order);
        //        com.Parameters.AddWithValue("@tong_tien", sp.tong_tien);
        //        com.Parameters.AddWithValue("@payment", sp.payment);
        //        com.Parameters.AddWithValue("@status", sp.status);
        //        com.Parameters.AddWithValue("@note", sp.note);
        //        com.Parameters.AddWithValue("@type", type);
        //        con.Open();
        //        com.ExecuteNonQuery();
        //        con.Close();
        //        msg = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return msg;
        //}
        //public DataSet GAGTbb(bills_ban sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bb", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_kh", "sss");
        //        com.Parameters.AddWithValue("@date_order", "2001-01-15");
        //        com.Parameters.AddWithValue("@tong_tien", 0);
        //        com.Parameters.AddWithValue("@payment", "sss");
        //        com.Parameters.AddWithValue("@status", "sss");
        //        com.Parameters.AddWithValue("@note", "sss");
        //        com.Parameters.AddWithValue("@type", t);
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(com);
        //        con.Close();
        //        da.Fill(ds);
        //        msg = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return ds;
        //}


    }
}
