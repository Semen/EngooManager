using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engoo.Core.Model
{
	public class Teacher
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
		public int TeacherId { get; set; }

		public string Name { get; set; }
	}
}
