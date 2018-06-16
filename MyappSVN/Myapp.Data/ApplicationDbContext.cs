using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Myapp.Data.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Myapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class ContextInitializer
    {
        private ApplicationDbContext _context;

        public ContextInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        //Seed method
        public async Task Seed()
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();

                if (_context.SecurityQuestions.AsNoTracking().Count(x => !x.IsDeleted) == 0)
                {
                    var sq = new List<SecurityQuestion>()
                    {
                        new SecurityQuestion()
                        {
                            IsActive =true,
                            IsDeleted =false,
                            Question ="In what city were you born?"
                        },
                        new SecurityQuestion()
                        {
                            IsActive =true,
                            IsDeleted =false,
                            Question ="What is your mother's maiden name?"
                        },
                        new SecurityQuestion()
                        {
                            IsActive =true,
                            IsDeleted =false,
                            Question ="What is your pet's name?"
                        },
                        new SecurityQuestion(){
                            IsActive =true,
                            IsDeleted =false,
                            Question ="What was your childhood nickname?"
                        },
                        new SecurityQuestion()
                        {
                            IsActive =true,
                            IsDeleted =false,
                            Question ="In what city did you meet your spouse/significant other?"
                        },
                        new SecurityQuestion()
                        {
                            IsActive =true,
                            IsDeleted =false,
                            Question ="What is the name of your favorite childhood friend"
                        },
                        new SecurityQuestion()
                        {
                            IsActive =true,
                            IsDeleted =false,
                            Question ="In what city was your first job?"
                        },
                    };
                    _context.SecurityQuestions.AddRange(sq);

                    await _context.SaveChangesAsync();
                }

                if (_context.ApplicationRoles.AsNoTracking().Count() == 0)
                {
                    var roles = new List<ApplicationRole>()
                    {
                        new ApplicationRole()
                        {
                            Name = "SuperAdmin",
                            Id = "1"
                        },
                        new ApplicationRole()
                        {
                            Name = "Admin",
                            Id = "2"
                        },
                        new ApplicationRole()
                        {
                            Name = "User",
                            Id = "3"
                        }
                    };
                    _context.ApplicationRoles.AddRange(roles);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
               // var file = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "log.txt");
               // File.AppendAllText(file, ex.ToString());
            }
        }
    }
}
