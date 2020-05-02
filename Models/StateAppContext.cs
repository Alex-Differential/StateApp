using Microsoft.EntityFrameworkCore;

namespace StateApp.Models
{
    public class StateAppContext : DbContext
    {
        public virtual DbSet<Goverment> Goverments { get; set; }
        public virtual DbSet<Country_World> Country_Worlds { get; set; }
        public virtual DbSet<Polit_System> Polit_Systems { get; set; }
        public virtual DbSet<State_Board> State_Boards { get; set; }
        public virtual DbSet<Economy> Economies { get; set; }
        public virtual DbSet<Econ_Cos_Info> Econ_Cos_Infos { get; set; }

        public StateAppContext(DbContextOptions<StateAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
