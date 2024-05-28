using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Answer> Answers {get;set;}
        public DbSet<Question> Questions {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<UserGroup> UserGroups {get;set;}
        public DbSet<SelectedChoices> SelectedChoices {get;set;}
    }
}