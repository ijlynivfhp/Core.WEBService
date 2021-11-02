using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ijlynivfhp.Projects.SeckillFronts.Controllers
{
    /// <summary>
    /// 秒杀商品详情控制器
    /// </summary>
    public class DetailController : Controller
    {
        /// <summary>
        /// 首页展示
        /// </summary>
        /// <param name="Id">秒杀编号</param>
        /// <param name="endtime">秒杀时间</param>
        /// <returns></returns>
        public ActionResult Index(int seckillId, string endtime)
        {
            // 1、添加页面数据
            ViewData.Add("seckillId", seckillId);
            ViewData.Add("endtime", endtime);
            return View();
        }

        // GET: Detail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detail/Create
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

        // GET: Detail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Detail/Edit/5
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

        // GET: Detail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Detail/Delete/5
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