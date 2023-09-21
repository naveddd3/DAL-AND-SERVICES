using Microsoft.AspNetCore.Mvc;
using St.ColumbusERP.AppCode;
using St.ColumbusERP.AppCode.Infratructure;
using St.ColumbusERP.Models;
using System.Data;
using System.Data.SqlClient;

namespace St.ColumbusERP.Controllers
{
    public class FeeGroupController : Controller

    {
        private readonly IDAL _dal;
        private readonly IFeeGroupServices _feegroupservices;
        public FeeGroupController(IDAL dal, IFeeGroupServices feegroupservices)
        {
            _dal = dal;
            _feegroupservices = feegroupservices;
        }
        public IActionResult FeegForm() 
        {
            return View();
        }
        public IActionResult Addfeeg(FeeGroup Fg)
        {
            var i = _feegroupservices.Add(Fg);
            return Json(i);
        }
        
        public IActionResult FeeGroupList()
        {
            var students = _feegroupservices.GetAll();
            return View(students);
        }
        public IActionResult EditFeeg(int GroupId)
        {
            var Edit = _feegroupservices.GetById(GroupId);
            return View(Edit);
        }
        public IActionResult DeleteFeeg(int GroupId)
        {
            int i = 0;
            string query = "DELETE FROM feegroup WHERE GroupId = @GroupId";
            SqlParameter[] param =
            {
                new SqlParameter("@GroupId",GroupId),
            };
            i = _dal.Execute(query, param);
            return Json(i);
        }
    }
}
