using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AceProject.Models.DAL;
using Lib.Web.Mvc.JQuery.JqGrid;
using AceProject.Models;
using System.Collections;

namespace AceProject.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Edit()
        {
            Task obj = new Task();
            TaskObjects TaskList1 = new TaskObjects();
            var TaskList = obj.LsitTask();
            IList<TaskObjects> p = TaskList;
            ViewBag.List = new SelectList(p.AsEnumerable(), "TaskId", "TaskId");
            return View();
        }

        public ActionResult Delete()
        {
            Task obj = new Task();
            TaskObjects TaskList1 = new TaskObjects();
            var TaskList = obj.LsitTask();
            IList<TaskObjects> p = TaskList;
            ViewBag.List = new SelectList(p.AsEnumerable(), "TaskId", "TaskId");
            return View();
        }

        public string create(string project, string module, string screenName, string task, string estimateHours, string priority, string creator, DateTime startDate, DateTime endDate, string assigned, string startTime, string endTime, string reviewer, string status, string comments)
        {
            TaskObjects c = new TaskObjects();
            c.ProjectName = project;
            c.ModuleName = module;
            c.ScreenName = screenName;

            c.TaskName = task;
            c.EstimateHours = estimateHours;
            c.Priority = priority;

            c.Creator = creator;
            c.StartDate = startDate;
            c.EndDate = endDate;

            c.Assigned = assigned;
            c.StartTime = startTime;
            c.EndTime = endTime;

            c.Reviewer = reviewer;
            c.Status = status;
            c.Comments = comments;

            Task c1 = new Task();

            return c1.create(c);

        }

        [HttpGet]
        public ActionResult GETTASK()
        {
            Task obj = new Task();
            TaskObjects TaskList1 = new TaskObjects ();
            var TaskList = obj.LsitTask();
            IList<TaskObjects> p = TaskList;
            ViewBag.List = new SelectList(p.AsEnumerable(), "TaskId", "TaskId");
            return View();

        }

        public bool updateone(int id, string project, string module, string screenName, string task, string estimateHours, string priority, string creator, DateTime startDate, DateTime endDate, string assigned, string startTime, string endTime, string reviewer, string status, string comments)
        {
            TaskObjects c = new TaskObjects();
            c.TaskId = id;
            c.ProjectName = project;
            c.ModuleName = module;
            c.ScreenName = screenName;

            c.TaskName = task;
            c.EstimateHours = estimateHours;
            c.Priority = priority;

            c.Creator = creator;
            c.StartDate = startDate;
            c.EndDate = endDate;

            c.Assigned = assigned;
            c.StartTime = startTime;
            c.EndTime = endTime;

            c.Reviewer = reviewer;
            c.Status = status;
            c.Comments = comments;

            Task c1 = new Task();

            return c1.Update(c);

        }

        public bool deleteone(int id)
        {
            TaskObjects c = new TaskObjects();
            c.TaskId = id;

            Task c1 = new Task();

            return c1.delete(c);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products(JqGridRequest request, TaskObjects viewModel)
        {

            //Service1Client obj = new Service1Client();

            JqGridResponse response = new JqGridResponse();
            List<TaskObjects> listobj = new List<TaskObjects>();
            Task dal = new Task();
            var m = dal.LsitTask();
            //var m = obj.display();
            listobj = m.ToList();

            foreach (TaskObjects product in listobj)
            {
                response.Records.Add(new JqGridRecord(Convert.ToString(product.TaskId), new List<object>()
                {
                   product.TaskId,
                   product.ProjectName,
                   product.ModuleName,
                   product.ScreenName,
      
                   product.TaskName,
                   product.EstimateHours,
                   product.Priority,
                                
                   product.Creator,
                   product.Reviewer,
                   product.Assigned,

                   product.StartDate,
                   product.EndDate,
               
                  
                   product.StartTime,
                   product.EndTime,
              
                  
                   product.Status,
                   product.Comments,

                }));
            }

            return new JqGridJsonResult() { Data = response };
        }

        public ActionResult Updateselect(Int16 id)
        {
            Task obj = new Task();
            var Modellist = obj.LsitTask();
            var Editlist = Modellist.First(para => para.TaskId == id);
            id = Convert.ToInt16(Editlist.TaskId);
            ViewData["id"] = Editlist.TaskId;
            ViewData["project"] = Editlist.ProjectName;
            ViewData["module"] = Editlist.ModuleName;
            ViewData["screenName"] = Editlist.ScreenName;
            ViewData["task"] = Editlist.TaskName;
            ViewData["estimateHours"] = Editlist.EstimateHours;
            ViewData["priority"] = Editlist.Priority;
            ViewData["creator"] = Editlist.Creator;
            ViewData["startDate"] = Editlist.StartDate;
            ViewData["endDate"] = Editlist.EndDate;
            ViewData["assigned"] = Editlist.Assigned;
            ViewData["startTime"] = Editlist.StartTime;
            ViewData["endTime"] = Editlist.EndTime;
            ViewData["reviewer"] = Editlist.Reviewer;
            ViewData["status"] = Editlist.Status;
            ViewData["comments"] = Editlist.Comments;
            return View(Editlist);
            //return RedirectToAction("Index", "CRUD");
        }

    }
}
