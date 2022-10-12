using System;
using System.Text;
using System.Data.Odbc;
using System.Data;
using Cthuvien;

//namespace CVfp
//{
    public class CVfp
    {
        private OdbcConnection Vfp_connect(string b_thumuc)
        {
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString =
            "Driver={Microsoft Visual FoxPro Driver};" +
            "SourceType=DBF;Exclusive=No;SourceDB=" + b_thumuc + ";";
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }


            return conn;
        }
        private void Vfp_Fdbf_moi(OdbcConnection b_cnn, string b_tenbang, DataTable b_dt_ctr)
        {
            System.IO.File.Delete(b_tenbang);

            string b_str = "create table " + b_tenbang + " (";
            for (int i = 0; i < b_dt_ctr.Rows.Count; i++)
            {
                string b_kieu = b_dt_ctr.Rows[i]["loai"].ToString();
                if (i > 0) b_str = b_str + ",";
                b_str = b_str + b_dt_ctr.Rows[i]["ma"].ToString();
                if (b_kieu.IndexOf("VARCHAR") > -1)
                {
                    int b_ddai = Cthuvien.chuyen.OBJ_I(b_dt_ctr.Rows[i]["dai"]);
                    if (b_ddai > 250) b_ddai = 250;
                    b_str = b_str + " c(" + b_ddai.ToString().Trim() + ")";
                }
                else if (b_kieu.IndexOf("NUMBER") > -1)
                {
                    b_str = b_str + " n(18,2)";
                }

                else if (b_kieu.IndexOf("DATE") > -1)
                {
                    b_str = b_str + " d";
                }

            }
            b_str = b_str + ")";
            OdbcCommand cmd = new OdbcCommand(b_str, b_cnn);
            cmd.ExecuteNonQuery();
        }
        private void Vfp_Fdbf_save(OdbcConnection b_cnn, string b_tenbang, DataTable b_dt)
        {
            string b_str_g = "insert into " + b_tenbang + " values (";
            string b_str = "";
            OdbcCommand b_cmd = new OdbcCommand();
            b_cmd.Connection = b_cnn;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                b_str = b_str_g;
                string b_kieu;
                for (int b_cot = 0; b_cot < b_dt.Columns.Count; b_cot++)
                {
                    if (b_cot > 0) b_str = b_str + ",";
                    b_kieu = b_dt.Columns[b_cot].DataType.ToString().ToUpper();
                    if (b_kieu == "SYSTEM.STRING")
                    {
                        b_str = b_str + "'" + b_dr[b_cot].ToString() + "'";
                    }
                    else if (b_kieu == "SYSTEM.DOUBLE" || b_kieu.IndexOf("SYSTEM.INT") > -1 || b_kieu.IndexOf("SYSTEM.DECIMAL") > -1)
                    {
                        b_str = b_str + b_dr[b_cot].ToString();
                    }
                    else if (b_kieu.IndexOf("SYSTEM.DATE") > -1)
                    {
                        //b_str = b_str + "'" + Cthuvien.chuyen.NG_NGC(Cthuvien.chuyen.OBJ_D(b_dr[b_cot])) + "'";
                        b_str = b_str + "ctod('"+ Cthuvien.chuyen.OBJ_D(b_dr[b_cot]).ToString("MM/dd/yyyy") + "')";
                        //Cthuvien.chuyen.OBJ_D(b_dr[b_cot]).ToString("dd/mm/yyyy")
                    }
                }
                b_str = b_str + ")";
                b_cmd.CommandText = b_str;
                b_cmd.ExecuteNonQuery();
            }
            b_cnn.Close();
        }

        public void Vfp_luu_dbf(string b_tm, string b_tenbang, DataTable b_dt, DataTable b_dt_ctr)
        {
            OdbcConnection b_cnn = Vfp_connect(b_tm);
            Vfp_Fdbf_moi(b_cnn, b_tm + b_tenbang, b_dt_ctr);
            Vfp_Fdbf_save(b_cnn, b_tm + b_tenbang, b_dt);
        }
    }
//}
