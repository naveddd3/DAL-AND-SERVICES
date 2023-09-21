using St.ColumbusERP.Models;

namespace St.ColumbusERP.AppCode.Infratructure
{
    public interface IFeeGroupServices
    {
        int Add(FeeGroup fg);
        IEnumerable<FeeGroup> GetAll();
        FeeGroup GetById(int id);
    }
}
