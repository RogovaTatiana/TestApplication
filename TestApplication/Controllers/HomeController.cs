using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpPost]
		public JsonResult Upload()
		{
			foreach (string file in Request.Files)
			{
				var upload = Request.Files[file];
				if (upload != null)
				{
					// получаем имя файла
					string fileName = System.IO.Path.GetFileName(upload.FileName);
					// сохраняем файл в папку Files в проекте
					upload.SaveAs(Server.MapPath("~/Files/" + fileName));
				}
			}
			return Json("файл загружен");
		}
	}
}