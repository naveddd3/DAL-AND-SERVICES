using St.ColumbusERP.AppCode.Infratructure;
using St.ColumbusERP.Models;
using System.Data;
using System.Data.SqlClient;

namespace St.ColumbusERP.AppCode
{
    public class FeeGroupServices : IFeeGroupServices
    { 
       
        private readonly IDAL _dal;
        public FeeGroupServices(IDAL dal)
        {
            _dal = dal;
    
        }
        public int Add(FeeGroup fg)
        {
            int i = 0;
            string query = "insert into feegroup (GroupName,Description,FromClass,ToClass) values (@GroupName, @Description, @FromClass,@ToClass);";
            SqlParameter[] param = {
                new SqlParameter("@GroupName",fg.GroupName),
                new SqlParameter("@Description",fg.Description),
                new SqlParameter("@FromClass",fg.FromClass),
                new SqlParameter("@ToClass",fg.ToClass)
                };
            i=_dal.Execute(query, param);
            return i;
        }

        public IEnumerable<FeeGroup> GetAll()
        {
            List<FeeGroup> Fg = new List<FeeGroup>();
            DataTable dt = new DataTable();
            string query = "Select * from feegroup";
            dt = _dal.Get(query);
            foreach (DataRow dr in dt.Rows)
            {
                Fg.Add(new FeeGroup
                {
                    GroupId = dr["GroupId"] is DBNull ? 0 : Convert.ToInt32(dr["GroupId"]),
                    GroupName = dr["GroupName"] is DBNull ? String.Empty : (dr["GroupName"]).ToString(),
                    Description = dr["Description"] is DBNull ? String.Empty : (dr["Description"]).ToString(),
                    FromClass = dr["FromClass"] is DBNull ? String.Empty : (dr["FromClass"]).ToString(),
                    ToClass = dr["ToClass"] is DBNull ? String.Empty : (dr["ToClass"]).ToString(),
                });
            }
            return Fg;
        }

        public FeeGroup GetById(int GroupId)
        {
            FeeGroup Fg = new FeeGroup();
            DataTable dt = new DataTable();
            string query = "Select * from feegroup Where GroupId = @GroupId";
            SqlParameter[] param =
            {
                new SqlParameter("@GroupId",GroupId)
            };
            dt = _dal.Get(query, param);
            foreach (DataRow dr in dt.Rows)
            {
                Fg.GroupName = dr["GroupName"] is DBNull ? String.Empty : (dr["GroupName"]).ToString();
                Fg.Description = dr["Description"] is DBNull ? String.Empty : (dr["Description"]).ToString();
                Fg.FromClass = dr["FromClass"] is DBNull ? String.Empty : (dr["FromClass"]).ToString();
                Fg.ToClass = dr["ToClass"] is DBNull ? String.Empty : (dr["ToClass"]).ToString();

            }
            return Fg;
        }
    }
}
