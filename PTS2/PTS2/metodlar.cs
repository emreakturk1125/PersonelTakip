using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PTS2
{
    public class metodlar
    {

        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("data source = EMREE-BILG\\MSSQL2014 ; initial catalog = personeltakip; integrated security = true");
            baglanti.Open();
            return (baglanti);
        }

        //(string sqlcumle)
        public int cmd(string sqlcumle)
        {
            SqlConnection baglanti = this.baglan();
            SqlCommand sorgu = new SqlCommand(sqlcumle, baglanti);
            int sonuc = 0;

            try
            {
                sonuc = sorgu.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "(" + sqlcumle + ")");
            }
            sorgu.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return (sonuc);
        }
        public DataTable GetDataTable(SqlCommand cmd)
        {
            SqlConnection baglanti = this.baglan();
            cmd.Connection = baglanti;
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable();
            try
            {
                dap.Fill(dt);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "(" + cmd.CommandText + ")");
            }
            dap.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return dt;

        }
        public DataRow GetDataRow(SqlCommand cmd)
        {
            DataTable dt = GetDataTable(cmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
                return dt.Rows[0];
        }

        public string GetDataCell(SqlCommand cmd)
        {
            DataTable dt = GetDataTable(cmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
                return (dt.Rows[0][0]).ToString();

        }
    }
}