using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;


namespace TestApplication
{
	public class WordsCounting : IProcessing
	{
		public void Processing(FileData file)
		{
			// подсчет слов в тексте

			string[] stroka;
			string fileName;
			file.Words = new List<Word>();
			Dictionary<string, List<string>> myDict = new Dictionary<string, List<string>>();
			
			fileName = @"\Files\" + file.FileName;

			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(fs);
			while (!sr.EndOfStream)
			{
				stroka = sr.ReadLine().Split(new []
				{
					' ',
					',',
					'.',
					'-',
					':',
					';'
				}, StringSplitOptions.RemoveEmptyEntries);

				foreach (var s in stroka)
				{
					string word = s.ToLower();
					if (file.Words.Any(x => x.WordName == word))
						file.Words.First(x => x.WordName == word).Quantity++;
					else
					{
						file.Words.Add(new Word()
						{
							WordName = word,
							Quantity = 1
						});
					}
				}
			}
			sr.Close();
		}
	}
}