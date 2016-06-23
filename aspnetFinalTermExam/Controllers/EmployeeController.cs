using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using aspnetFinalTermExam.Models;

namespace aspnetFinalTermExam.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(Employees item)
        {
            EmployeeService EmployeeService = new EmployeeService();
            ViewBag.Employeedata = EmployeeService.GetEmployeesName(item);

            CodeTableService CodeTableService = new CodeTableService();
            List<CodeTable> result1 = CodeTableService.GetTitle();
            List<SelectListItem> CodeTableData = new List<SelectListItem>();
            CodeTableData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item1 in result1)
            {
                CodeTableData.Add(new SelectListItem()
                {
                    Text = item1.CodeVal.ToString(),
                    Value = item1.CodeId.ToString()
                });
                ViewData["CodeTableData"] = CodeTableData;
            }


            return View();
        }

        [HttpPost()]
        public JsonResult DeleteEmployee(string EmployeeID)
        {

            try
            {

                EmployeeService EmployeeService = new EmployeeService();
                EmployeeService.DeleteEmployeeByID(EmployeeID);

                return this.Json(true);
            }
            catch (Exception)
            {
                return this.Json(false);
            }
        }
        public ActionResult InsertIndex(Employees item)
        {
            CodeTableService CodeTableService = new CodeTableService();
            List<CodeTable> result1 = CodeTableService.GetTitle();
            List<SelectListItem> CodeTableData = new List<SelectListItem>();
            CodeTableData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item1 in result1)
            {
                CodeTableData.Add(new SelectListItem()
                {
                    Text = item1.CodeVal.ToString(),
                    Value = item1.CodeId.ToString()
                });
                ViewData["CodeTableData"] = CodeTableData;
            }

            EmployeeService EmployeeService = new EmployeeService();
            List<Employees> result2 = EmployeeService.GetCountry();
            List<SelectListItem> CountryData = new List<SelectListItem>();
            CountryData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item2 in result2)
            {
                CountryData.Add(new SelectListItem()
                {
                    Text = item2.Country.ToString(),
                    Value = item2.Country.ToString()
                });
                ViewData["CountryData"] = CountryData;
            }
            List<Employees> result3 = EmployeeService.GetCity();
            List<SelectListItem> CityData = new List<SelectListItem>();
            CityData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item3 in result3)
            {
                CityData.Add(new SelectListItem()
                {
                    Text = item3.City.ToString(),
                    Value = item3.City.ToString()
                });
                ViewData["CityData"] = CityData;
            }
            List<Employees> result4 = EmployeeService.GetGender();
            List<SelectListItem> GenderData = new List<SelectListItem>();
            GenderData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item4 in result4)
            {
                GenderData.Add(new SelectListItem()
                {
                    Text = item4.Gender.ToString(),
                    Value = item4.Gender.ToString()
                });
                ViewData["GenderData"] = GenderData;
            }
            List<Employees> result5 = EmployeeService.GetManagerID();
            List<SelectListItem> ManagerIDData = new List<SelectListItem>();
            ManagerIDData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item5 in result5)
            {
                ManagerIDData.Add(new SelectListItem()
                {
                    Text = item5.ManagerID.ToString(),
                    Value = item5.ManagerID.ToString()
                });
                ViewData["ManagerIDData"] = ManagerIDData;
            }




            return View();
        }

        [HttpPost()]
        public ActionResult InsertEmployees(Models.Employees Employees)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    EmployeeService EmployeeService = new EmployeeService();
                    EmployeeService.InsertEmployees(Employees);
                    return RedirectToAction("./Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return View(Employees);
        }
    }
}
