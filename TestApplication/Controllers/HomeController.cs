using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
	public class HomeController : Controller
	{
		// поля для работы с базой данных
		static readonly ModelContainer Model = new ModelContainer();
		static IRepository<UploadHistory> _uploadHistory = new Repository<UploadHistory>(Model);

		// обработка и запись данных в файл
		static readonly ISaving Saving = new FileSaving(); // можно указать другой тип сохранения
		static readonly IProcessing Processing = new WordsCounting(); // Можно создать другой способ обработки и унаследовать его от IProcessing

		#region StandartControllers
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
		#endregion

		// Обработка загруженного файла
		[HttpPost]
		public ActionResult Upload()
		{
			string result = "Файл загружен";
			foreach (string file in Request.Files)
			{
				var newFile = new FileData();
				var upload = Request.Files[file];
				if (upload != null)
				{
					string fileName = Path.GetFileName(upload.FileName);
					upload.SaveAs(@"\Files\" + fileName);
					newFile.FileName = fileName;
					newFile.UploadDate = DateTime.Now;
					newFile.FileSize = upload.ContentLength;
					Processing.Processing(newFile);
					Saving.Save(newFile);
					_uploadHistory.Insert(new UploadHistory()
					{
						FileName = newFile.FileName,
						FileSize = newFile.FileSize,
						UploadDate = newFile.UploadDate
					});
					_uploadHistory.SubmitAll();
				}
				ViewBag.Words = newFile.Words;
			}

			ViewBag.result = result;
			 
			return PartialView("WordCounting");

		}
	}
}