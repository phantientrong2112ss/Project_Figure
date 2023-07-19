using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace WA_FigureBSZ.Models
{
    public class HandleBN
    {
        private SqlConnection cns;
        public HandleBN(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle Bill nhap
        ///Handle Loai San Pham
        public List<bills_nhap> GAAGI(int id, string t)
        {
            List<bills_nhap> Listlsp = new List<bills_nhap>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_bn", cns);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@id_ncc", 1);
            com.Parameters.AddWithValue("@id_nhanvien", 1);
            com.Parameters.AddWithValue("@date_order", "2001-01-15");
            com.Parameters.AddWithValue("@tong_tien", 1);
            com.Parameters.AddWithValue("@thanh_toan", "sss");
            com.Parameters.AddWithValue("@note", "sss");
            com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new bills_nhap
                    {
                        id = Convert.ToInt32(dr["id"]),
                        id_ncc = Convert.ToInt32(dr["id_ncc"]),
                        id_nhanvien = Convert.ToInt32(dr["id_nhanvien"]),
                        date_order = DateTime.Parse(dr["date_order"].ToString()),
                        tong_tien = Convert.ToInt32(dr["tong_tien"]),
                        thanh_toan = dr["thanh_toan"].ToString(),
                        note = dr["note"].ToString()
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(bills_nhap bn, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_bn", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", bn.id);
                com.Parameters.AddWithValue("@id_ncc", bn.id_ncc);
                com.Parameters.AddWithValue("@id_nhanvien", bn.id_nhanvien);
                com.Parameters.AddWithValue("@date_order", bn.date_order);
                com.Parameters.AddWithValue("@tong_tien", bn.tong_tien);
                com.Parameters.AddWithValue("@thanh_toan", bn.thanh_toan);
                com.Parameters.AddWithValue("@note", bn.note);
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





























        //public string CRUDbn(bills_nhap sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bn", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_ncc", sp.id_ncc);
        //        com.Parameters.AddWithValue("@id_nhanvien", sp.id_nhanvien);
        //        com.Parameters.AddWithValue("@date_order", sp.date_order);
        //        com.Parameters.AddWithValue("@tong_tien", sp.tong_tien);
        //        com.Parameters.AddWithValue("@thanh_toan", sp.thanh_toan);
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
        //public DataSet GAGTbn(bills_nhap sp, string t)
        //{
        //    string
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bn", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_ncc", 1);
        //        com.Parameters.AddWithValue("@id_nhanvien", 1);
        //        com.Parameters.AddWithValue("@date_order", "2001-01-15");
        //        com.Parameters.AddWithValue("@tong_tien", 1);
        //        com.Parameters.AddWithValue("@thanh_toan", "sss");
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
