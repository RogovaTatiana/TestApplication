using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
	public class FileData
	{
		public string FileName { get; set; }
		public int FileSize { get; set; }
		public DateTime UploadDate { get; set; }
		public List<Word> Words { get; set; }

	}
}