using Engoo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engoo.Core.DAO
{
	public class LessonRepository: IDisposable
	{
		public EngooContext Context { get; private set; }

		public LessonRepository()
		{
			Context = new EngooContext();
		}

		public Lesson AddOrUpdate(Lesson lesson)
		{
			var model = Context.Schedules.FirstOrDefault(x => x.LessonId == lesson.LessonId);

			if (model != null)
			{
				model.LockedLesson = lesson.LockedLesson;
				model.Status = lesson.Status;
				model.TimePassed = lesson.TimePassed;
			}
			else
			{
				Context.Schedules.Add(lesson);
			}

			return lesson;
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}

		public void Dispose()
		{
			Context.Dispose();
		}
	}
}
