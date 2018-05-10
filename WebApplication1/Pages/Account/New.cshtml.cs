using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Account
{
	public class NewModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public NewModel(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		[BindProperty]
		public UserInputModel Input { get; set; }
		public void OnGet()
		{
			Input = new UserInputModel
			{
				Email = "jay.shen@haha.haha",
				Claims = new List<UserInputModel.ClaimsItem> {
					new UserInputModel.ClaimsItem{ }
				}
			};

		}

		public async Task<IActionResult> OnPostAddCliamAsync()
		{
			Input.Claims.Add(new UserInputModel.ClaimsItem { });
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
				var result = await _userManager.CreateAsync(user, Input.Password);
				if (result.Succeeded)
				{
					var cliams = Input.Claims.Select(x=> new System.Security.Claims.Claim(x.Type, x.Value));
					await _userManager.AddClaimsAsync(user, cliams);
					return RedirectToPage("/Index");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return Page();
		}
	}
}