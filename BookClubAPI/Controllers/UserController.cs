using BookClubAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BookClubAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public Db01Context context { get; }
		public UserController(Db01Context appDBContext)
		{
			context = appDBContext;
		}

		[HttpPost]
		[Route("login")]
		public ActionResult Login(LoginView user)
		{
			Rbuser fetchUserData = context.Rbusers
				.Where(m => m.UserName == user.userName && m.Password == user.password)
				.FirstOrDefault();
			if (fetchUserData == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(fetchUserData.UserId);
			}
		}

		[HttpPost]
		[Route("register")]
		public ActionResult Register(Rbuser newUser)
		{
			context.Rbusers.Add(newUser);
			context.SaveChanges();
			return Ok();
		}

		[HttpGet]
		[Route("userfirstname/{id}")]
		public ActionResult GetUserFirstName(int id)
		{
			string userFirstName = context.Rbusers.FirstOrDefault(u => u.UserId == id).FirstName;
			return Ok(new { userFirstName = userFirstName });
		}

		[HttpGet]
		[Route("userslist")]
		public ActionResult GetUsersList()
		{
			List<Rbuser> users = context.Rbusers.ToList();
			return Ok(users);
		}


	}
}