using System;
using System.IO;
using TestApplication.Models;

namespace TestApplication
{
	public class FileSaving : ISaving
	{
		public void Save(FileData file)
		{
			// ���������� � ����
			string fileName = "/Files/result.txt";
			var ww = new StreamWriter(fileName, true);
			ww.WriteLine(file.FileName);
			ww.WriteLine(String.Format("������ �����: {0} ����", file.FileSize));
			ww.WriteLine(String.Format("���� �������: {0}", file.UploadDate));
			foreach (var word in file.Words)
			{
				ww.WriteLine(word);
			}
			ww.Close();
		}
	}
}