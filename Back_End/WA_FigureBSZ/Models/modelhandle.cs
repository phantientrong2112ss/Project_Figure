using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class modelhandle
    {
        private SqlConnection con; 
        public modelhandle(string cstring)
        {
            con= new SqlConnection(cstring);
        }
        /// Au Login
        public user Loginn(user sp)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_login", con);
                com.Parameters.AddWithValue("@users_name", sp.users_name);
                com.Parameters.AddWithValue("@password", sp.password);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (ds.Tables[0].Rows.Count != 0)
            {
                return sp;
            }
            else
                return null;
        }   

        /// GET SP by ID LSP
        public DataSet Gbidlsp(san_pham sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getspbyidlsp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id_loai_sp);
                com.Parameters.AddWithValue("@type", "getsbyid");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        /// GET dtbillban by ID billban
        public DataSet Gdtbbbyid(bill_detail_ban sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getdtofbb", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id_bill_ban);
                com.Parameters.AddWithValue("@type", "getsbyid");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        /// GET dtbillnhap by ID billnhap
        public DataSet Gdtbnbyid(bill_detail_nhap sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getdtofbn", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id_bill_nhap);
                com.Parameters.AddWithValue("@type", "getsbyid");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        /// GET ID current of bill ban
        public DataSet Gidcbb(out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_getcurrentidofbb", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        ///Handle San Pham
        public string CRUDsp(san_pham sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_sp", con);
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
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTsp(san_pham sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_sp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
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
                com.Parameters.AddWithValue("@Delet", 1);
                com.Parameters.AddWithValue("@newss", 1);
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Loai San Pham
        public string CRUDlsp(loai_sp loai,string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_lsp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", loai.id);
                com.Parameters.AddWithValue("@tenloai",loai.tenloai);
                //com.Parameters.AddWithValue("@delet",loai.Delet);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTlsp(loai_sp loai, out string msg,string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_lsp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id",loai.id);
                com.Parameters.AddWithValue("@tenloai","");
                com.Parameters.AddWithValue("@delet","");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
       
        ///Handle Tin Tuc
        public string CRUDnews(news sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_news", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_new", sp.id_new);
                com.Parameters.AddWithValue("@title", sp.title);
                com.Parameters.AddWithValue("@content", sp.content);
                com.Parameters.AddWithValue("@image", sp.image);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTnews(news sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_news", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_new", sp.id_new);
                com.Parameters.AddWithValue("@title", "v");
                com.Parameters.AddWithValue("@content", "v");
                com.Parameters.AddWithValue("@image", "v");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle khach hang
        public string CRUDkh(khach_hang sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_kh", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@ten_kh", sp.ten_kh);
                com.Parameters.AddWithValue("@email", sp.email);
                com.Parameters.AddWithValue("@dia_chi", sp.dia_chi);
                com.Parameters.AddWithValue("@sdt", sp.sdt);
                com.Parameters.AddWithValue("@note", sp.note);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTkh(khach_hang sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_kh", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@ten_kh", "v");
                com.Parameters.AddWithValue("@email", "v");
                com.Parameters.AddWithValue("@dia_chi", "v");
                com.Parameters.AddWithValue("@sdt", "v");
                com.Parameters.AddWithValue("@note", "v");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Nha cung cap
        public string CRUDncc(nha_cung_cap sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_ncc", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@ten_ncc", sp.ten_ncc);
                com.Parameters.AddWithValue("@diachi_ncc", sp.diachi_ncc);
                com.Parameters.AddWithValue("@email", sp.email);
                com.Parameters.AddWithValue("@sdt", sp.sdt);
                //com.Parameters.AddWithValue("@Delet", sp.Delet);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTncc(nha_cung_cap sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_ncc", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@ten_ncc", "sss");
                com.Parameters.AddWithValue("@diachi_ncc", "sss");
                com.Parameters.AddWithValue("@email", "sss");
                com.Parameters.AddWithValue("@sdt", "sss");
                com.Parameters.AddWithValue("@Delet", 0);
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Nhan vien
        public string CRUDnv(nhan_vien sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_nv", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@ten_nhanvien", sp.ten_nhanvien);
                com.Parameters.AddWithValue("@gioitinh", sp.gioitinh);
                com.Parameters.AddWithValue("@ngaysinh", sp.ngaysinh);
                com.Parameters.AddWithValue("@quequan", sp.quequan);
                com.Parameters.AddWithValue("@sdt", sp.sdt);
                com.Parameters.AddWithValue("@email", sp.email);
                com.Parameters.AddWithValue("@capbac", sp.capbac);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTnv(nhan_vien sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_nv", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@ten_nhanvien", "sss");
                com.Parameters.AddWithValue("@gioitinh", "sss");
                com.Parameters.AddWithValue("@ngaysinh", "2001-01-15");
                com.Parameters.AddWithValue("@quequan", "sss");
                com.Parameters.AddWithValue("@sdt", "sss");
                com.Parameters.AddWithValue("@email", "sss");
                com.Parameters.AddWithValue("@capbac", "1");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Tai khoan
        public string CRUDus(user sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_tk", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@full_name", sp.full_name);
                com.Parameters.AddWithValue("@users_name", sp.users_name);
                com.Parameters.AddWithValue("@email", sp.email);
                com.Parameters.AddWithValue("@password", sp.password);
                com.Parameters.AddWithValue("@phone", sp.phone);
                com.Parameters.AddWithValue("@address", sp.address);
                com.Parameters.AddWithValue("@image", sp.image);
                //com.Parameters.AddWithValue("@Delet", sp.Delet);
                com.Parameters.AddWithValue("@remember_token", sp.remember_token);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTus(user sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_tk", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@full_name", "sss");
                com.Parameters.AddWithValue("@users_name", "sss");
                com.Parameters.AddWithValue("@email", "sss");
                com.Parameters.AddWithValue("@password", "sss");
                com.Parameters.AddWithValue("@phone", "sss");
                com.Parameters.AddWithValue("@address", "sss");
                com.Parameters.AddWithValue("@image", "sss");
                com.Parameters.AddWithValue("@Delet", 1);
                com.Parameters.AddWithValue("@remember_token", "sss");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Bills ban
        public string CRUDbb(bills_ban sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_bb", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_kh", sp.id_kh);
                com.Parameters.AddWithValue("@date_order", sp.date_order);
                com.Parameters.AddWithValue("@tong_tien", sp.tong_tien);
                com.Parameters.AddWithValue("@payment", sp.payment);
                com.Parameters.AddWithValue("@status", sp.status);
                com.Parameters.AddWithValue("@note", sp.note);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTbb(bills_ban sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_bb", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_kh", "sss");
                com.Parameters.AddWithValue("@date_order", "2001-01-15");
                com.Parameters.AddWithValue("@tong_tien", 0);
                com.Parameters.AddWithValue("@payment", "sss");
                com.Parameters.AddWithValue("@status", "sss");
                com.Parameters.AddWithValue("@note", "sss");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Bill nhap
        public string CRUDbn(bills_nhap sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_bn", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_ncc", sp.id_ncc);
                com.Parameters.AddWithValue("@id_nhanvien", sp.id_nhanvien);
                com.Parameters.AddWithValue("@date_order", sp.date_order);
                com.Parameters.AddWithValue("@tong_tien", sp.tong_tien);
                com.Parameters.AddWithValue("@thanh_toan", sp.thanh_toan);
                com.Parameters.AddWithValue("@note", sp.note);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTbn(bills_nhap sp, string t)
        {
            string
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_bn", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_ncc", 1);
                com.Parameters.AddWithValue("@id_nhanvien", 1);
                com.Parameters.AddWithValue("@date_order", "2001-01-15");
                com.Parameters.AddWithValue("@tong_tien", 1);
                com.Parameters.AddWithValue("@thanh_toan", "sss");
                com.Parameters.AddWithValue("@note", "sss");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Bban detail
        public string CRUDbbd(bill_detail_ban sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_bbd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_bill_ban", sp.id_bill_ban);
                com.Parameters.AddWithValue("@id_sp", sp.id_sp);
                com.Parameters.AddWithValue("@unit_prices", sp.unit_prices);
                com.Parameters.AddWithValue("@sl", sp.sl);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTbbd(bill_detail_ban sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_bbd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_bill_ban", 1);
                com.Parameters.AddWithValue("@id_sp", 1);
                com.Parameters.AddWithValue("@unit_prices", 1);
                com.Parameters.AddWithValue("@sl", 1);
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        ///Handle Bnhap Detail
        public string CRUDbnd(bill_detail_nhap sp, string type)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("P_bnd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_bill_nhap", sp.id_bill_nhap);
                com.Parameters.AddWithValue("@id_sp", sp.id_sp);
                com.Parameters.AddWithValue("@sl", sp.sl);
                com.Parameters.AddWithValue("@don_vi", sp.don_vi);
                com.Parameters.AddWithValue("@type", type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet GAGTbnd(bill_detail_nhap sp, out string msg, string t)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("P_bnd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", sp.id);
                com.Parameters.AddWithValue("@id_bill_nhap", 1);
                com.Parameters.AddWithValue("@id_sp", 1);
                com.Parameters.AddWithValue("@sl", 1);
                com.Parameters.AddWithValue("@don_vi", "vv");
                com.Parameters.AddWithValue("@type", t);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Close();
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

    }
}
