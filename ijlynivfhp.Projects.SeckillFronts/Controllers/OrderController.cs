using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ijlynivfhp.Projects.SeckillFronts.Controllers
{
    /// <summary>
    /// 订单页面控制器
    /// </summary>
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(int ProductId, int ProductCount,
                            decimal ProductPrice, string ProductUrl,
                            string ProductTitle)
        {
            ViewData.Add("ProductId", ProductId);
            ViewData.Add("ProductCount", ProductCount);
            ViewData.Add("ProductPrice", ProductPrice);
            ViewData.Add("ProductUrl", ProductUrl);
            ViewData.Add("ProductTitle", ProductTitle);
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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