using DuruOnlineStore.Data.Entities.Identities;
using Microsoft.AspNetCore.Identity;

namespace DuruOnlineStore.WebUI.Services
{
	public interface IUserService
	{
		int GetUserId();
	}

	public class UserService : IUserService
	{
		private readonly IHttpContextAccessor _httpContext;
		private readonly UserManager<AppUser> _userManager;

		public UserService(IHttpContextAccessor httpContext, UserManager<AppUser> userManager)
		{
			_httpContext = httpContext;
			_userManager = userManager;
		}
		public int GetUserId()
		{
			if (_httpContext?.HttpContext?.User != null)
			{
				var user = _httpContext.HttpContext.User;
				var userIdStr = _userManager.GetUserId(user);
				return userIdStr != null ? Convert.ToInt32(userIdStr) : -1;
			}
			return -1;
		}
	}
}
