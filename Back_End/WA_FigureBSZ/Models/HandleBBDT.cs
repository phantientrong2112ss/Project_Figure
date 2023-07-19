using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class HandleBBDT
    {
        private SqlConnection cns;
        public HandleBBDT(string cstring)
        {
            cns = new SqlConnection(cstring);
        }
        public List<bill_detail_ban> GAAGI(int id, string t)
        {
            List<bill_detail_ban> Listlsp = new List<bill_detail_ban>();
            DataSet ds = new DataSet();
            cns.Open();
            SqlCommand com = new SqlCommand("P_bbd", cns);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@id_bill_ban", 1);
            com.Parameters.AddWithValue("@id_sp", 1);
            com.Parameters.AddWithValue("@unit_prices", 1);
            com.Parameters.AddWithValue("@sl", 1);
            com.Parameters.AddWithValue("@type", t);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Listlsp.Add(new bill_detail_ban
                    {
                        id = Convert.ToInt32(dr["id"]),
                        id_bill_ban = Convert.ToInt32(dr["id_bill_ban"]),
                        id_sp = Convert.ToInt32(dr["id_sp"]),
                        unit_prices = Convert.ToInt32(dr["unit_prices"]),
                        sl = Convert.ToInt32(dr["sl"])
                    });
                }
            }
            cns.Close();
            return Listlsp;
        }
        public string CUD(bill_detail_ban bdb, string t)
        {
            try
            {
                cns.Open();
                SqlCommand com = new SqlCommand("P_bbd", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", bdb.id);
                com.Parameters.AddWithValue("@id_bill_ban", bdb.id_bill_ban);
                com.Parameters.AddWithValue("@id_sp", bdb.id_sp);
                com.Parameters.AddWithValue("@unit_prices", bdb.unit_prices);
                com.Parameters.AddWithValue("@sl", bdb.sl);
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
        /// GET dtbillban by ID billban
        public DataSet Gdtbbbyid(bill_detail_ban sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getdtofbb", cns);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id_bill_ban);
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


























        //public string CRUDbbd(bill_detail_ban sp, string type)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bbd", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_bill_ban", sp.id_bill_ban);
        //        com.Parameters.AddWithValue("@id_sp", sp.id_sp);
        //        com.Parameters.AddWithValue("@unit_prices", sp.unit_prices);
        //        com.Parameters.AddWithValue("@sl", sp.sl);
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
        //public DataSet GAGTbbd(bill_detail_ban sp, out string msg, string t)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("P_bbd", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@id", sp.id);
        //        com.Parameters.AddWithValue("@id_bill_ban", 1);
        //        com.Parameters.AddWithValue("@id_sp", 1);
        //        com.Parameters.AddWithValue("@unit_prices", 1);
        //        com.Parameters.AddWithValue("@sl", 1);
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
