using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleNews
    {
        private SqlConnection cns;
        public HandleNews(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        ///Handle Tin Tuc
        public List<news> GAAGI(int id, string t)
        {
            List<news> Listlsp = new List<news>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_news", cns);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id_new", id);
            com.Parameters.AddWithValue("@title", "v");
            com.Parameters.AddWithValue("@content", "v");
            com.Parameters.AddWithValue("@image", "v");
            com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new news
                    {
                        id_new = Convert.ToInt32(dr["id_new"]),
                        title = dr["title"].ToString(),
                        content = dr["content"].ToString(),
                        image = dr["image"].ToString()
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(news nn, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_news", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_new", nn.id_new);
                com.Parameters.AddWithValue("@title", nn.title);
                com.Parameters.AddWithValue("@content", nn.content);
                com.Parameters.AddWithValue("@image", nn.image);
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






























        //public string CRUDnews(news sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_news", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id_new", sp.id_new);
        //        com.Parameters.AddWithValue("@title", sp.title);
        //        com.Parameters.AddWithValue("@content", sp.content);
        //        com.Parameters.AddWithValue("@image", sp.image);
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
        //public DataSet GAGTnews(news sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_news", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id_new", sp.id_new);
        //        com.Parameters.AddWithValue("@title", "v");
        //        com.Parameters.AddWithValue("@content", "v");
        //        com.Parameters.AddWithValue("@image", "v");
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
