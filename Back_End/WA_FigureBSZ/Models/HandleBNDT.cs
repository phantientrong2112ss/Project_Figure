using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleBNDT
    {
        private SqlConnection cns;
        public HandleBNDT(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle Bnhap Detail
        public List<bill_detail_nhap> GAAGI(int id, string t)
        {
            List<bill_detail_nhap> Listlsp = new List<bill_detail_nhap>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_bnd", cns);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@id_bill_nhap", 1);
            com.Parameters.AddWithValue("@id_sp", 1);
            com.Parameters.AddWithValue("@sl", 1);
            com.Parameters.AddWithValue("@don_vi", "vv");
            com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new bill_detail_nhap
                    {
                        id = Convert.ToInt32(dr["id"]),
                        id_bill_nhap = Convert.ToInt32(dr["id_bill_nhap"]),
                        id_sp = Convert.ToInt32(dr["id_sp"]),
                        sl = Convert.ToInt32(dr["sl"]),
                        don_vi = dr["don_vi"].ToString()
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(bill_detail_nhap bdn, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_bnd", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", bdn.id);
                com.Parameters.AddWithValue("@id_bill_nhap", bdn.id_bill_nhap);
                com.Parameters.AddWithValue("@id_sp", bdn.id_sp);
                com.Parameters.AddWithValue("@sl", bdn.sl);
                com.Parameters.AddWithValue("@don_vi", bdn.don_vi);
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

        public DataSet Gdtbnbyid(bill_detail_nhap sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getdtofbn", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id_bill_nhap);
                com.Parameters.AddWithValue("@type", "getsbyid");
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

















        //public string CRUDbnd(bill_detail_nhap sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bnd", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_bill_nhap", sp.id_bill_nhap);
        //        com.Parameters.AddWithValue("@id_sp", sp.id_sp);
        //        com.Parameters.AddWithValue("@sl", sp.sl);
        //        com.Parameters.AddWithValue("@don_vi", sp.don_vi);
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
        //public DataSet GAGTbnd(bill_detail_nhap sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bnd", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_bill_nhap", 1);
        //        com.Parameters.AddWithValue("@id_sp", 1);
        //        com.Parameters.AddWithValue("@sl", 1);
        //        com.Parameters.AddWithValue("@don_vi", "vv");
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
