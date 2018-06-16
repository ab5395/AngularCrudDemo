using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Myapp.Data.Dto;

namespace Myapp.Services.Interfaces
{
	public interface ISecurityQuestionRepository : IGenericRepository<SecurityQuestion>
	{
		IEnumerable<SecurityQuestion> GetSequrityQuestions(bool asNoTracking, Expression<Func<SecurityQuestion, bool>> predicate, params Expression<Func<SecurityQuestion, object>>[] includeProperties);
	}
}
