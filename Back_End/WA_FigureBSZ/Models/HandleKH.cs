using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace WA_FigureBSZ.Models
{
    public class HandleKH
    {
        private SqlConnection cns;
        public HandleKH(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle khach hang
        public List<khach_hang> GAAGI(int id, string t)
        {
            List<khach_hang> Listlsp = new List<khach_hang>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_kh", cns);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@ten_kh", "v");
            com.Parameters.AddWithValue("@email", "v");
            com.Parameters.AddWithValue("@dia_chi", "v");
            com.Parameters.AddWithValue("@sdt", "v");
            com.Parameters.AddWithValue("@note", "v");
            com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new khach_hang
                    {
                        id = Convert.ToInt32(dr["id"]),
                        ten_kh = dr["ten_kh"].ToString(),
                        email = dr["email"].ToString(),
                        dia_chi = dr["dia_chi"].ToString(),
                        sdt = dr["sdt"].ToString(),
                        note = dr["note"].ToString()
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(khach_hang kh, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_kh", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", kh.id);
                com.Parameters.AddWithValue("@ten_kh", kh.ten_kh);
                com.Parameters.AddWithValue("@email", kh.email);
                com.Parameters.AddWithValue("@dia_chi", kh.dia_chi);
                com.Parameters.AddWithValue("@sdt", kh.sdt);
                com.Parameters.AddWithValue("@note", kh.note);
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






















        //public string CRUDkh(khach_hang sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_kh", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@ten_kh", sp.ten_kh);
        //        com.Parameters.AddWithValue("@email", sp.email);
        //        com.Parameters.AddWithValue("@dia_chi", sp.dia_chi);
        //        com.Parameters.AddWithValue("@sdt", sp.sdt);
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
        //public DataSet GAGTkh(khach_hang sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_kh", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@ten_kh", "v");
        //        com.Parameters.AddWithValue("@email", "v");
        //        com.Parameters.AddWithValue("@dia_chi", "v");
        //        com.Parameters.AddWithValue("@sdt", "v");
        //        com.Parameters.AddWithValue("@note", "v");
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
