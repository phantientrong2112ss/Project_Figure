using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleNCC
    {
        private SqlConnection cns;
        public HandleNCC(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle Nha cung cap
        public List<nha_cung_cap> GAAGI(int id, string t)
        {
            List<nha_cung_cap> Listlsp = new List<nha_cung_cap>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_ncc", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@ten_ncc", "sss");
                com.Parameters.AddWithValue("@diachi_ncc", "sss");
                com.Parameters.AddWithValue("@email", "sss");
                com.Parameters.AddWithValue("@sdt", "sss");
                //com.Parameters.AddWithValue("@Delet", 0);
                com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new nha_cung_cap
                    {
                        id = Convert.ToInt32(dr["id"]),
                        ten_ncc = dr["ten_ncc"].ToString(),
                        diachi_ncc = dr["diachi_ncc"].ToString(),
                        email = dr["email"].ToString(),
                        sdt = dr["sdt"].ToString(),
                        //Delet = Convert.ToInt32(dr["Delet"])
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(nha_cung_cap ncc, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_ncc", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", ncc.id);
                com.Parameters.AddWithValue("@ten_ncc", ncc.ten_ncc);
                com.Parameters.AddWithValue("@diachi_ncc", ncc.diachi_ncc);
                com.Parameters.AddWithValue("@email", ncc.email);
                com.Parameters.AddWithValue("@sdt", ncc.sdt);
                //com.Parameters.AddWithValue("@Delet", ncc.Delet);
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


























        //public string CRUDncc(nha_cung_cap sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_ncc", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@ten_ncc", sp.ten_ncc);
        //        com.Parameters.AddWithValue("@diachi_ncc", sp.diachi_ncc);
        //        com.Parameters.AddWithValue("@email", sp.email);
        //        com.Parameters.AddWithValue("@sdt", sp.sdt);
        //        com.Parameters.AddWithValue("@Delet", sp.Delet);
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
        //public DataSet GAGTncc(nha_cung_cap sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_ncc", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@ten_ncc", "sss");
        //        com.Parameters.AddWithValue("@diachi_ncc", "sss");
        //        com.Parameters.AddWithValue("@email", "sss");
        //        com.Parameters.AddWithValue("@sdt", "sss");
        //        com.Parameters.AddWithValue("@Delet", 0);
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
