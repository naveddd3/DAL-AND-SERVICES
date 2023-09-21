using System.Data;
using System.Data.SqlClient;

namespace St.ColumbusERP.AppCode
{
    public interface IDAL
    {
        int Execute(string Sqlquery, SqlParameter[] param, CommandType command = CommandType.Text);
        DataTable Get(string Sqlquery ,CommandType command = CommandType.Text);

        DataTable Get(string Sqlquery, SqlParameter[] param, CommandType command = CommandType.Text);
    }
}
