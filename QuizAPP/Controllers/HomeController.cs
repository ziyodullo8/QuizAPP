using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPP.Data;
using QuizAPP.Models;
using System.Diagnostics;

namespace QuizAPP.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DataContext _dataContext;

		public HomeController(ILogger<HomeController> logger, DataContext dataContext)
		{
			_logger = logger;
			_dataContext = dataContext;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult delete()
		{
			return View();
		}
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Natija()
		{
			return View();
		}
		//public IActionResult QuizList()
		//{
		//	return View();
		//}

		public IActionResult Privacy()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> QuizList()
		{
			var quiz = await _dataContext.Quiz.ToListAsync();
			return View(quiz);
		}

		[HttpGet]
		public async Task<IActionResult> DeleteList()
		{
			var quiz = await _dataContext.Quiz.ToListAsync();
			return View(quiz);
		}


		[HttpPost]
		public async Task<IActionResult> Create(QuizModels quiz)
		{
			if (!ModelState.IsValid)
			{
				return View(quiz);
			}
			await _dataContext.Quiz.AddAsync(quiz);
			await _dataContext.SaveChangesAsync();
			return View(quiz);
		}

		//[HttpPost]
		//public async Task<IActionResult> Radio(RadioModel radio)
		//{
		//	if (radio.Radio1 == true)
		//	{
		//		if()
		//	}
		//} 
   
		
        public async Task<IActionResult> Delete(int id)
        {
            var quiz = await _dataContext.Quiz.FirstOrDefaultAsync(n => n.id == id);
            if (quiz is null)
            {
                return View(new NotFoundResult());
            }
            _dataContext.Quiz.Remove(quiz);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}