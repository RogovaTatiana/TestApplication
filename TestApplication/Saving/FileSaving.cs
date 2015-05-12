using System;
using System.IO;
using TestApplication.Models;

namespace TestApplication
{
	public class FileSaving : ISaving
	{
		public void Save(FileData file)
		{
			// сохранение в файл
			string fileName = "/Files/result.txt";
			var ww = new StreamWriter(fileName, true);
			ww.WriteLine(file.FileName);
			ww.WriteLine(String.Format("Размер файла: {0} байт", file.FileSize));
			ww.WriteLine(String.Format("Дата загруки: {0}", file.UploadDate));
			foreach (var word in file.Words)
			{
				ww.WriteLine(word);
			}
			ww.Close();
		}
	}
}