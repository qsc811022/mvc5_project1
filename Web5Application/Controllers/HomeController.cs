using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Web5Application.Service;

namespace Web5Application.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		[HttpPost]
		public async Task<ActionResult> Chat(JsonInputModel inputModel)
		{
			if (ModelState.IsValid)
			{
				var chatService = new ChatService(); // 或者通過依賴注入獲取
				var response = await chatService.GetResponse(inputModel.Input);
				return Content(response);
			}
			return Json(new { success = false, message = "Invalid input" });
		}

		public class JsonInputModel
		{
			public string Input { get; set; }
		}
	}
}