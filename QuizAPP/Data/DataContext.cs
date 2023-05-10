using Microsoft.EntityFrameworkCore;
using QuizAPP.Models;

namespace QuizAPP.Data
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		public DbSet<QuizModels> Quiz { get; set; }
	}
}
