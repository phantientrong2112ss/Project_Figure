using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleNV
    {
        private SqlConnection cns;
        public HandleNV(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle Nhan vien
        public List<nhan_vien> GAAGI(int id, string t)
        {
            List<nhan_vien> Listlsp = new List<nhan_vien>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_nv", cns);
            com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@ten_nhanvien", "sss");
                com.Parameters.AddWithValue("@gioitinh", "sss");
                com.Parameters.AddWithValue("@ngaysinh", "2001-01-15");
                com.Parameters.AddWithValue("@quequan", "sss");
                com.Parameters.AddWithValue("@sdt", "sss");
                com.Parameters.AddWithValue("@email", "sss");
                com.Parameters.AddWithValue("@capbac", "1");
                com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new nhan_vien
                    {
                        id = Convert.ToInt32(dr["id"]),
                        ten_nhanvien = dr["ten_nhanvien"].ToString(),
                        gioitinh = dr["gioitinh"].ToString(),
                        ngaysinh = DateTime.Parse(dr["ngaysinh"].ToString()),
                        quequan = dr["quequan"].ToString(),
                        sdt = dr["sdt"].ToString(),
                        email = dr["email"].ToString(),
                        capbac = dr["capbac"].ToString(),
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(nhan_vien nv, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_nv", cns);
                com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", nv.id);
                    com.Parameters.AddWithValue("@ten_nhanvien", nv.ten_nhanvien);
                    com.Parameters.AddWithValue("@gioitinh", nv.gioitinh);
                    com.Parameters.AddWithValue("@ngaysinh", nv.ngaysinh);
                    com.Parameters.AddWithValue("@quequan", nv.quequan);
                    com.Parameters.AddWithValue("@sdt", nv.sdt);
                    com.Parameters.AddWithValue("@email", nv.email);
                    com.Parameters.AddWithValue("@capbac", nv.capbac);
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


















        //public string CRUDnv(nhan_vien sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_nv", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@ten_nhanvien", sp.ten_nhanvien);
        //        com.Parameters.AddWithValue("@gioitinh", sp.gioitinh);
        //        com.Parameters.AddWithValue("@ngaysinh", sp.ngaysinh);
        //        com.Parameters.AddWithValue("@quequan", sp.quequan);
        //        com.Parameters.AddWithValue("@sdt", sp.sdt);
        //        com.Parameters.AddWithValue("@email", sp.email);
        //        com.Parameters.AddWithValue("@capbac", sp.capbac);
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
        //public DataSet GAGTnv(nhan_vien sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_nv", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@ten_nhanvien", "sss");
        //        com.Parameters.AddWithValue("@gioitinh", "sss");
        //        com.Parameters.AddWithValue("@ngaysinh", "2001-01-15");
        //        com.Parameters.AddWithValue("@quequan", "sss");
        //        com.Parameters.AddWithValue("@sdt", "sss");
        //        com.Parameters.AddWithValue("@email", "sss");
        //        com.Parameters.AddWithValue("@capbac", "1");
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
