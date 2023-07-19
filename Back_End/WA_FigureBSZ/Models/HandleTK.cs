using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleTK
    {
        private SqlConnection cns;
        public HandleTK(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        public List<user> GAAGI(int id, string t)
        {
            List<user> Listus = new List<user>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_tk", cns);
            com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@full_name", "sss");
                com.Parameters.AddWithValue("@users_name", "sss");
                com.Parameters.AddWithValue("@email", "sss");
                com.Parameters.AddWithValue("@password", "sss");
                com.Parameters.AddWithValue("@phone", "sss");
                com.Parameters.AddWithValue("@address", "sss");
                com.Parameters.AddWithValue("@image", "sss");
                com.Parameters.AddWithValue("@capquyen", 1);
                com.Parameters.AddWithValue("@remember_token", "sss");
                com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listus.Add(new user
                    {
                        id = Convert.ToInt32(dr["id"]),
                        full_name = dr["full_name"].ToString(),
                        users_name = dr["users_name"].ToString(),
                        email = dr["email"].ToString(),
                        password = dr["password"].ToString(),
                        phone = dr["phone"].ToString(),
                        address = dr["address"].ToString(),
                        image = dr["image"].ToString(),
                        capquyen = Convert.ToInt32(dr["capquyen"]),
                        //Delet = Convert.ToInt32(dr["Delet"]),
                        remember_token = dr["remember_token"].ToString()
                    });
                }
            }
            cns.Close();
            return Listus;
        }
        public string CUD(user tk, string t)
        {
            try
            {
                SqlCommand com = new SqlCommand("P_tk", cns);
                cns.Open();
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", tk.id);
                com.Parameters.AddWithValue("@full_name", tk.full_name);
                com.Parameters.AddWithValue("@users_name", tk.users_name);
                com.Parameters.AddWithValue("@email", tk.email);
                com.Parameters.AddWithValue("@password", tk.password);
                com.Parameters.AddWithValue("@phone", tk.phone);
                com.Parameters.AddWithValue("@address", tk.address);
                com.Parameters.AddWithValue("@image", tk.image);
                com.Parameters.AddWithValue("@capquyen", tk.capquyen);
                //com.Parameters.AddWithValue("@Delet", tk.Delet);
                com.Parameters.AddWithValue("@remember_token", tk.remember_token);
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
     
       




























        //public string CRUDus(user sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_tk", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@full_name", sp.full_name);
        //        com.Parameters.AddWithValue("@users_name", sp.users_name);
        //        com.Parameters.AddWithValue("@email", sp.email);
        //        com.Parameters.AddWithValue("@password", sp.password);
        //        com.Parameters.AddWithValue("@phone", sp.phone);
        //        com.Parameters.AddWithValue("@address", sp.address);
        //        com.Parameters.AddWithValue("@image", sp.image);
        //        com.Parameters.AddWithValue("@Delet", sp.Delet);
        //        com.Parameters.AddWithValue("@remember_token", sp.remember_token);
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
        //public DataSet GAGTus(user sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_tk", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@full_name", "sss");
        //        com.Parameters.AddWithValue("@users_name", "sss");
        //        com.Parameters.AddWithValue("@email", "sss");
        //        com.Parameters.AddWithValue("@password", "sss");
        //        com.Parameters.AddWithValue("@phone", "sss");
        //        com.Parameters.AddWithValue("@address", "sss");
        //        com.Parameters.AddWithValue("@image", "sss");
        //        com.Parameters.AddWithValue("@Delet", 1);
        //        com.Parameters.AddWithValue("@remember_token", "sss");
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
