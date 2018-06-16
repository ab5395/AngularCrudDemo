using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Myapp.Data;
using Myapp.Data.Dto;
using Myapp.Services.Interfaces;

namespace Myapp.Services.Repositories
{
    public class SecurityQuestionRepository : GenericRepository<SecurityQuestion>, ISecurityQuestionRepository
    {
        private readonly ApplicationDbContext _db;
        public SecurityQuestionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SecurityQuestion> GetSequrityQuestions(bool asNoTracking, Expression<Func<SecurityQuestion, bool>> predicate,
            params Expression<Func<SecurityQuestion, object>>[] includeProperties) => GetAll(predicate, asNoTracking);
    }
}
