using Microsoft.EntityFrameworkCore;
using Test_1.models;
using Test_1.Models;

namespace Test_1.DataEF
{
    
    public class MissingPersonEntity :DbContext
    {
        public MissingPersonEntity()
        {
            
        }
        public MissingPersonEntity(DbContextOptions options) : base (options)
        {
            
        }
        public DbSet<FoundPerson> foundPerson { get; set; }
        public DbSet<LostPerson> lostPerson { get; set; }
        public DbSet<User> user { get; set; }

    }
}
