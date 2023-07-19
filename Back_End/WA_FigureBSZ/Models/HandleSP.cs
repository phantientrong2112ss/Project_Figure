using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleSP
    {
        private SqlConnection cns;
        public HandleSP(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle San Pham
        public List<san_pham> GAAGI(int id, string t)
        {
            List<san_pham> Listsp = new List<san_pham>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_sp", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@name", "sss");
                com.Parameters.AddWithValue("@id_loai_sp", 1);
                com.Parameters.AddWithValue("@id_ncc", 1);
                com.Parameters.AddWithValue("@mota_sp", "vvv");
                com.Parameters.AddWithValue("@unit_price", 1);
                com.Parameters.AddWithValue("@gia_km", 1);
                com.Parameters.AddWithValue("@so_luong", 1);
                com.Parameters.AddWithValue("@image", "vvv");
                com.Parameters.AddWithValue("@img2", "vvv");
                com.Parameters.AddWithValue("@img3", "vvv");
                com.Parameters.AddWithValue("@don_vi_tinh", 1);
                //com.Parameters.AddWithValue("@Delet", 1);
                com.Parameters.AddWithValue("@newss", 1);
                com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listsp.Add(new san_pham
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = dr["name"].ToString(),
                        id_loai_sp = Convert.ToInt32(dr["id_loai_sp"]),
                        id_ncc = Convert.ToInt32(dr["id_ncc"]),
                        mota_sp = dr["mota_sp"].ToString(),
                        unit_price = Convert.ToInt32(dr["unit_price"]),
                        gia_km = Convert.ToInt32(dr["gia_km"]),
                        so_luong = Convert.ToInt32(dr["so_luong"]),
                        image = dr["image"].ToString(),
                        img2 = dr["img2"].ToString(),
                        img3 = dr["img3"].ToString(),
                        don_vi_tinh = dr["don_vi_tinh"].ToString(),
                        //Delet = Convert.ToInt32(dr["Delet"]),
                        newss = Convert.ToInt32(dr["newss"])
                    });
                }
            }
            cns.Close();
            return Listsp;
        }
        public string CUD(san_pham sp, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_sp", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@name", sp.name);
                com.Parameters.AddWithValue("@id_loai_sp", sp.id_loai_sp);
                com.Parameters.AddWithValue("@id_ncc", sp.id_ncc);
                com.Parameters.AddWithValue("@mota_sp", sp.mota_sp);
                com.Parameters.AddWithValue("@unit_price", sp.unit_price);
                com.Parameters.AddWithValue("@gia_km", sp.gia_km);
                com.Parameters.AddWithValue("@so_luong", sp.so_luong);
                com.Parameters.AddWithValue("@image", sp.image);
                com.Parameters.AddWithValue("@img2", sp.img2);
                com.Parameters.AddWithValue("@img3", sp.img3);
                com.Parameters.AddWithValue("@don_vi_tinh", sp.don_vi_tinh);
                //com.Parameters.AddWithValue("@Delet", sp.Delet);
                com.Parameters.AddWithValue("@newss", sp.newss);
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
       
        /// GET SP by ID LSP
        public DataSet Gbidlsp(san_pham sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getspbyidlsp", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id_loai_sp);
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
























        //public string CRUDsp(san_pham sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_sp", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@name", sp.name);
        //        com.Parameters.AddWithValue("@id_loai_sp", sp.id_loai_sp);
        //        com.Parameters.AddWithValue("@id_ncc", sp.id_ncc);
        //        com.Parameters.AddWithValue("@mota_sp", sp.mota_sp);
        //        com.Parameters.AddWithValue("@unit_price", sp.unit_price);
        //        com.Parameters.AddWithValue("@gia_km", sp.gia_km);
        //        com.Parameters.AddWithValue("@so_luong", sp.so_luong);
        //        com.Parameters.AddWithValue("@image", sp.image);
        //        com.Parameters.AddWithValue("@img2", sp.img2);
        //        com.Parameters.AddWithValue("@img3", sp.img3);
        //        com.Parameters.AddWithValue("@don_vi_tinh", sp.don_vi_tinh);
        //        com.Parameters.AddWithValue("@Delet", sp.Delet);
        //        com.Parameters.AddWithValue("@newss", sp.newss);
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
        //public DataSet GAGTsp(san_pham sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_sp", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@name", "sss");
        //        com.Parameters.AddWithValue("@id_loai_sp", 1);
        //        com.Parameters.AddWithValue("@id_ncc", 1);
        //        com.Parameters.AddWithValue("@mota_sp", "vvv");
        //        com.Parameters.AddWithValue("@unit_price", 1);
        //        com.Parameters.AddWithValue("@gia_km", 1);
        //        com.Parameters.AddWithValue("@so_luong", 1);
        //        com.Parameters.AddWithValue("@image", "vvv");
        //        com.Parameters.AddWithValue("@img2", "vvv");
        //        com.Parameters.AddWithValue("@img3", "vvv");
        //        com.Parameters.AddWithValue("@don_vi_tinh", 1);
        //        com.Parameters.AddWithValue("@Delet", 1);
        //        com.Parameters.AddWithValue("@newss", 1);
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
