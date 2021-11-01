using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ijlynivfhp.Core.WEBService.SeckillFronts.Controllers
{
    /// <summary>
    /// 支付页面控制器
    /// </summary>
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int OrderId, string OrderSn, decimal OrderTotalPrice, int ProductId, string ProductName, int UserId)
        {
            ViewData.Add("OrderId", OrderId);
            ViewData.Add("OrderSn", OrderSn);
            ViewData.Add("OrderTotalPrice", OrderTotalPrice);
            ViewData.Add("ProductId", ProductId);
            ViewData.Add("ProductName", ProductName);
            ViewData.Add("UserId", UserId);
            return View();
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
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

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
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

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
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