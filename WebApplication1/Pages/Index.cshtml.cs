using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDbContext _context;
		public IndexModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public class UserModel
		{
			public string Id { get; set; }
			public string UserName { get; set; }
			public List<string> Claimes { get; set; }
		}
		public List<UserModel> UserList { get; set; }
		public void OnGet()
		{
			var list = _context.Users.ToList();
			UserList = list.Select(x => new UserModel
			{
				Id = x.Id,
				UserName = x.UserName,
				Claimes = _context.UserClaims.Where(c => c.UserId == x.Id).Select(c => $"{c.ClaimType}: {c.ClaimValue}").ToList()
			}).ToList();
		}
	}
}
