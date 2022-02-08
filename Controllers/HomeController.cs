using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quads.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quads.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TaskContext TaskContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TaskContext task)
        {
            _logger = logger;
            TaskContext = task;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var taskList = TaskContext.Tasks.ToList();
            return View(taskList);
        }


        [HttpGet]
        public IActionResult ListAllTasks()
        {
            var taskList = TaskContext.Tasks.ToList();
            return View(taskList);
        }


        // New task stuff
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            //ViewBag.Categories = context.Categories.ToList();
            return View("AddEditTask");
        }
        //submit new movie
        [HttpPost]
        public IActionResult AddTask(Models.Task task)
        {
           TaskContext.Add(task);
           TaskContext.SaveChanges();
            return RedirectToAction("Index");
        }



        //edit task stuff

        [HttpGet]
        public IActionResult Edit(int TaskID)
        {
            Models.Task task = TaskContext.Tasks.Single(x => x.TaskID == TaskID);
            ViewBag.Categories = TaskContext.Categories.ToList();

            return View("AddEditTask", task);
        }

        //Submitting the edited movie
        [HttpPost]
        public IActionResult Edit(Models.Task updatedTask)
        {
            if (ModelState.IsValid) 
            { 
            TaskContext.Update(updatedTask);
            TaskContext.SaveChanges();

            return RedirectToAction("Index");

             }

            else
            {
                ViewBag.Categories = TaskContext.Categories.ToList();
                return View("AddEditTask");
            }

        }

        [HttpGet]
        public IActionResult ChangeTaskDoneState(int TaskID)
        {
            Models.Task task = TaskContext.Tasks.Single(x => x.TaskID == TaskID);
            task.IsCompleted =  !(task.IsCompleted);
            TaskContext.Update(task);
            TaskContext.SaveChanges();

            var taskList = TaskContext.Tasks.ToList();


            return View("Index", taskList);
        }

        public IActionResult ChangeTaskDoneStateListAll(int TaskID)
        {
            Models.Task task = TaskContext.Tasks.Single(x => x.TaskID == TaskID);
            task.IsCompleted = !(task.IsCompleted);
            TaskContext.Update(task);
            TaskContext.SaveChanges();

            var taskList = TaskContext.Tasks.ToList();


            return View("ListAllTasks", taskList);

        }

        [HttpGet]
        public IActionResult Delete(int TaskID)
        {
            Models.Task task = TaskContext.Tasks.Single(x => x.TaskID == TaskID);
            ViewBag.Categories = TaskContext.Categories.ToList();

            return View("Confirmation", task);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task task)
        {
            TaskContext.Tasks.Remove(task);
            TaskContext.SaveChanges();

            var taskList = TaskContext.Tasks.ToList();
            return View("index", taskList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
