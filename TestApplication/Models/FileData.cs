using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
	public class FileData
	{
		private readonly IProcessing processing;

		public FileData(IProcessing processing)
		{
			this.processing = processing;
		}
		public string FileName { get; set; }
		public int FileSize { get; set; }
		public DateTime UploadDate { get; set; }
		public string FileText { get; set; }
		public List<Word> Words { get; set; }
		public void Processing()
		{
			processing.Processing(this);
		}

	}
}