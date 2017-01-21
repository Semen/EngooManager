using Engoo.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engoo.Core.DAO
{
	public class EngooContext: DbContext
	{
		public DbSet<Lesson> Schedules { get; set; }


	}
}
