using Engoo.Core;
using Engoo.Core.DAO;
using Engoo.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engoo.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			EngooScaner scaner = new EngooScaner();

			var schedules =  scaner.GetSchedules(123);
			using (var repo = new LessonRepository())
			{
				var list = schedules.Select(x => repo.AddOrUpdate(x)).ToList();
				int newCount = list.Count(x => repo.Context.Entry(x).State == System.Data.Entity.EntityState.Added);

				if (newCount > 0)
				{
					EmailHelper.SendNotice("https://engoo.com/teachers/14557");
				}

				repo.SaveChanges();
			}
		}
	}
}
