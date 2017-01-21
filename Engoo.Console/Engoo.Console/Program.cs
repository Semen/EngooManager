using Engoo.Core;
using Engoo.Core.DAO;
using Engoo.Core.Helpers;
using Engoo.Core.Model;
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
			var teachers = new List<Teacher>
			{
				new Teacher { TeacherId = 7181, Name = "Mizza" },
				new Teacher { TeacherId = 14557, Name = "ULE" }
			};

			var freeTeachers = new List<Teacher>();

			foreach (var teacher in teachers)
			{
				var newCount = ScanTeachersLessons(teacher.TeacherId);

				if (newCount > 0)
				{
					freeTeachers.Add(teacher);
				}

				System.Console.WriteLine($"Teacher: {teacher.Name}; Scanned lessons: {newCount}; Date: {DateTime.Now.ToString("s")}");
			}

			EmailHelper.SendNotice(freeTeachers);
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
