using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Myapp.Data;
using Myapp.Data.Dto;
using Myapp.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Myapp.Services.Repositories
{
    public class UserManagementRepository : GenericRepository<ApplicationUser>, IUserManagementRepository
    {
        private readonly ApplicationDbContext _db;
        public UserManagementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email, bool asNoTracking) => await GetAll(asNoTracking).FirstOrDefaultAsync(x => x.Email == email);

        public async Task<ApplicationUser> GetSingleUserAsync(bool asNoTracking, Expression<Func<ApplicationUser, bool>> predicate, params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            if (asNoTracking)
                return await GetSingleWithoutTrackingAsync(predicate, includeProperties);
            else
                return await GetSingleAsync(predicate, includeProperties);
        }

        public async Task<List<ApplicationUser>> GetUsersAsync(Expression<Func<ApplicationUser, bool>> predicate, bool asNoTracking) => await ListAsync(predicate, asNoTracking);
    }
}
