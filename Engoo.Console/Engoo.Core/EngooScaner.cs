using Engoo.Core.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Engoo.Core
{
	public class EngooScaner
	{
		public List<Lesson> GetSchedules(int teachedId)
		{
			const string Url = "https://engoo.com/teachers/{0}.json";

			using (WebClient wc = new WebClient())
			{
				var json = wc.DownloadString(string.Format(Url, teachedId));

				dynamic obj = JObject.Parse(json);

				var schedules = ((IEnumerable<dynamic>)obj.schedules.result).Select(x => new Lesson
				{
					LessonId = x.lesson_id,
					LessonDate = DateTime.ParseExact(x.lesson_date.ToString() + "T" + x.scheduled_start_time.ToString(), "s", CultureInfo.InvariantCulture),
					Status = x.status,
					LockedLesson = x.locked_lesson,
					TimePassed = x.time_passed,
					TeacherId = teachedId
					
				}).ToList();

				return schedules;
			}
		}
	}
}
