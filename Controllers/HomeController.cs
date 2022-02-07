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

        // New task stuff
        [HttpGet]
        public IActionResult AddTask()
        {
            //ViewBag.Categories = context.Categories.ToList();
            return View("AddEditTask");
        }
        //submit new movie
        [HttpPost]
        public IActionResult AddTask(Models.Task task)
        {
            //context.Add(task);
            //context.SaveChanges();
            return RedirectToAction("Quad");
        }



        //edit task stuff

        [HttpGet]
        public IActionResult Edit(int TaskID)
        {
            Models.Task task = TaskContext.Tasks.Single(x => x.TaskID == TaskID);
            //ViewBag.Categories = context.Categories.ToList();

            return View("AddEditTask", task);
        }

        //Submitting the edited movie
        [HttpPost]
        public IActionResult Edit(Models.Task updatedTask)
        {
            TaskContext.Update(updatedTask);
            TaskContext.SaveChanges();

            return RedirectToAction("Quad");
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
