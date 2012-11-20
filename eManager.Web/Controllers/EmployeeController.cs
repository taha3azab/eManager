using System.Linq;
using System.Web.Mvc;
using eManager.Domains;
using eManager.Web.Models;

namespace eManager.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        //
        // GET: /Employee/
        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel { DepartmentId = departmentId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = _db.Departments.Single(d => d.Id == model.DepartmentId);
                var employee = new Employee { Name = model.Name, HireDate = model.HireDate };
                department.Employees.Add(employee);

                _db.Save();

                return RedirectToAction("Detail", "Department", new { id = model.DepartmentId });
            }
            return View(model);
        }

    }
}
