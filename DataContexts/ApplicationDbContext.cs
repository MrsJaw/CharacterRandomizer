using Microsoft.EntityFrameworkCore;
using CharacterRandomizer.Models;

namespace CharacterRandomizer.DataContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
            
        }

        public DbSet<Race> Races {get;set;}
        public DbSet<FamilyName> FamilyNames {get;set;}
        public DbSet<PersonalName> PersonalNames {get;set;}
        
    }
}