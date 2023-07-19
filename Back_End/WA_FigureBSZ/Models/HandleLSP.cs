using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleLSP
    {
        private SqlConnection cns;
        public HandleLSP(string cnstring)
        {
            cns = new SqlConnection(cnstring);
        }
        ///Handle Loai San Pham
        public List<loai_sp> GAAGI(int id,string t)
        {
            List<loai_sp> Listlsp = new List<loai_sp>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_lsp", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id",id);
                com.Parameters.AddWithValue("@tenloai", "");
                //com.Parameters.AddWithValue("@delet", "");
                com.Parameters.AddWithValue("@type", t);
                using (SqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Listlsp.Add(new loai_sp
                        {
                            id = Convert.ToInt32(dr["id"]),
                            tenloai = dr["tenloai"].ToString()
                            //Delet = dr["delet"].ToString()
                        });
                    }
                }
            cns.Close();
            return Listlsp;
        }
        public void CUD(loai_sp loai, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_lsp", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", loai.id);
                com.Parameters.AddWithValue("@tenloai", loai.tenloai);
                    //com.Parameters.AddWithValue("@delet", loai.Delet);
                    com.Parameters.AddWithValue("@type", t);
                com.ExecuteNonQuery();
                cns.Close();
                //return "Success";
            }
            //catch (Exception ex)
            //{
            //    //return ex.Message;
            //}
            finally
            {
                if (cns.State == ConnectionState.Open)
                {
                    cns.Close();
                }
            }
        }

















        //public string CUD(loai_sp loai, string type)
        //{
        //    string message = "";
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_lsp", cns);
        //        cns.Open();
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", loai.id);
        //        com.Parameters.AddWithValue("@tenloai", loai.tenloai);
        //        com.Parameters.AddWithValue("@delet", loai.Delet);
        //        com.Parameters.AddWithValue("@type", type);
        //        com.ExecuteNonQuery();
        //        cns.Close();
        //        message = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //    }
        //    finally
        //    {
        //        if (cns.State == ConnectionState.Open)
        //        {
        //            cns.Close();
        //        }
        //    }
        //    return message;
        //}

        //public DataSet GAGTlsp(loai_sp loai, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_lsp", cns);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", loai.id);
        //        com.Parameters.AddWithValue("@tenloai", "");
        //        com.Parameters.AddWithValue("@delet", "");
        //        com.Parameters.AddWithValue("@type", t);
        //        cns.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(com);
        //        cns.Close();
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
