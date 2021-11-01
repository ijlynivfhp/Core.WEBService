using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ijlynivfhp.WEBService.SeckillFronts.Controllers
{
    /// <summary>
    /// 秒杀列表控制器
    /// </summary>
    public class SeckillController : Controller
    {
        // GET: Seckill
        public ActionResult Index()
        {
            return View();
        }

        // GET: Seckill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Seckill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seckill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seckill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seckill/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seckill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seckill/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}