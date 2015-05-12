using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication
{
	public interface IProcessing
	{
		void Processing(FileData file);
	}
}
