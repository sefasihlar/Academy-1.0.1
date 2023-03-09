﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
	[Authorize(Roles = "Müdür")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public UserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View(new AppUserListModel()
			{
				Users = (List<AppUser>)_userManager.Users
				
			});
		}
	}
}
