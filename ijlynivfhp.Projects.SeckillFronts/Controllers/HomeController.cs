using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ijlynivfhp.Projects.SeckillFronts.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ijlynivfhp.Projects.SeckillFronts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Console.WriteLine(await Getss());
            return View();
        }

        public async Task<string> call()
        {
            Console.WriteLine("----------->1");
            Task<int> infoTask = foo();
            Console.WriteLine("----------->2");
            int s = await infoTask;
            Console.WriteLine("----------->3");
            return "1";
        }
        public async Task<int> foo()
        {
            Console.WriteLine("----------->4");
            await Task.Delay(500);
            Console.WriteLine("----------->5");
            return 1;
        }

        public async Task<string> Getss()
        {
            var info = string.Format("----------->1:{0}", Thread.CurrentThread.ManagedThreadId);
            Task<string> task = TaskCaller();
            var infoTaskRunning = string.Format("----------->2:{0}", Thread.CurrentThread.ManagedThreadId);
            var infoTask = await task;
            var infoTaskFinished = string.Format("----------->3:{0}", Thread.CurrentThread.ManagedThreadId);
            return string.Format("{0},{1},{2},{3}", info, infoTask, infoTaskRunning, infoTaskFinished);
        }

        private async Task<string> TaskCaller()
        {
            await Task.Delay(500);
            return string.Format("----------->4:{0}", Thread.CurrentThread.ManagedThreadId);
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
