using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Myapp.Data.Dto;
using System.Collections.Generic;

namespace Myapp.Services.Interfaces
{
	public interface IUserManagementRepository : IGenericRepository<ApplicationUser>
	{
		//Task<ApplicationUser> GetUserByEmailAsync(string email, bool asNoTracking);
		//Task<ApplicationUser> GetSingleUserAsync(bool asNoTracking, Expression<Func<ApplicationUser, bool>> predicate,
		//			params Expression<Func<ApplicationUser, object>>[] includeProperties);
		//Task<List<ApplicationUser>> GetUsersAsync(Expression<Func<ApplicationUser, bool>> predicate, bool asNoTracking);
	}

}