using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyCardsSystem.DBManager
{
    using AssemblyCard = Model.AssemblyCard;


    public class CardsContext : DbContext
    {
        public DbSet<AssemblyCard> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ACardsDB;Trusted_Connection=True;");
        }
    }
}
