using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Myapp.Data.Dto
{
    public class ApplicationRole : IdentityRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
