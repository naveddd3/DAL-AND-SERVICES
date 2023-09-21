using System.Data;
using System.Data.SqlClient;

namespace St.ColumbusERP.AppCode
{
    public class DAL : IDAL
    {
        private readonly string ConnectionString;
        public DAL(ConnectionHelper connectionHelper)
        {

            ConnectionString = connectionHelper.Default;
        }
        public int Execute(string Sqlquery, SqlParameter[] param, CommandType command = CommandType.Text)
        {
            int i = 0;
            try
            {
                using(SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(Sqlquery,con);
                    cmd.CommandType = CommandType.Text;
                    foreach (var p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                    con.Open();
                    i=cmd.ExecuteNonQuery(); 

                }
            }
            catch (Exception ex)
            {

                
            }
            return i;
        }

        public DataTable Get(string Sqlquery, CommandType command = CommandType.Text)
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(Sqlquery, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable Get(string Sqlquery, SqlParameter[] param, CommandType command = CommandType.Text)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(Sqlquery, con);
                    cmd.CommandType = CommandType.Text;
                    foreach (var p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }


    }
}

