using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

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
		public ActionResult Upload()
		{
			string result = "Файл загружен";
			foreach (string file in Request.Files)
			{
				var newFile = new FileData(new WordsCounting()); // Можно создать другой способ обработки и унаследовать его от IProcessing
				var upload = Request.Files[file];
				if (upload != null)
				{
					string fileName = System.IO.Path.GetFileName(upload.FileName);
					upload.SaveAs(@"\Files\" + fileName);
					newFile.FileName = fileName;
					newFile.UploadDate = DateTime.Today;
					newFile.FileSize = upload.ContentLength;
					newFile.Processing();
				}
				ViewBag.Words = newFile.Words;
			}

			ViewBag.result = result;
			 
			return PartialView("WordCounting");

		}
	}
}