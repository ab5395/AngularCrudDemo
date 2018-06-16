using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Myapp.Data.Dto
{
    [Table("SecurityQuestions")]
    public class SecurityQuestion
    {
        public int SecurityQuestionId { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
