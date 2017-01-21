using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engoo.Core.Model
{
	public class Lesson
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
		public int LessonId { get; set; }

		public DateTime LessonDate { get; set; }

		public int Status { get; set; }

		public bool TimePassed { get; set; }

		public bool LockedLesson { get; set; }
	}
}
