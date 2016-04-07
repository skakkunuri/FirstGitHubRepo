using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_PartialView_Demo.Models;

namespace MVC_PartialView_Demo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    var empList = db.Employees.ToList();
                    return View(empList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        } // end of index

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            try
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    using (EmployeeDBEntities db = new EmployeeDBEntities())
                    {
                        var empList = db.Employees.ToList();
                        return View(empList);
                    }
                } // end of if
                else
                {
                    using (EmployeeDBEntities db = new EmployeeDBEntities())
                    {
                        var empList = db.Employees.Where(x => x.EmpName.Contains(searchTerm)).ToList();
                        return View(empList);
                    }

                } // end of else
            } // end of try
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            } // end of catch
        }// end of function

        public PartialViewResult All()
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    var empList = db.Employees.ToList();
                    return PartialView("_StudentP", empList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }// end all
        public PartialViewResult Top3()
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    var empList = db.Employees.OrderBy(x => x.DepartmentID).Take(3).ToList();
                    return PartialView("_StudentP", empList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }// end top 3
        public PartialViewResult Bottom3()
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    var empList = db.Employees.OrderByDescending(x => x.DepartmentID).Take(3).ToList();
                    return PartialView("_StudentP", empList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }// end bottom 3
    }
}