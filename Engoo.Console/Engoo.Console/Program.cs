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
			int teacherId = 7181;

			var newCount = ScanTeachersLessons(teacherId);

			if (newCount > 0)
			{
				EmailHelper.SendNotice($"https://engoo.com/teachers/{teacherId}");
			}

			System.Console.WriteLine("Scanned lessons: " + newCount);
		}


		private static int ScanTeachersLessons(int teacherId)
		{
			var schedules = new EngooScaner().GetSchedules(teacherId);

			using (var repo = new LessonRepository())
			{
				var list = schedules.Select(x => repo.AddOrUpdate(x)).ToList();
				int newCount = list.Count(x => repo.Context.Entry(x).State == System.Data.Entity.EntityState.Added);
				repo.SaveChanges();

				return newCount;
			}
		}
	}
}
