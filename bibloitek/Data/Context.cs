using System;
using bibloitek.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bibloitek.Data

{

    public class Context : DbContext
    {
        public DbSet<Auther> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanCard> LoanCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" 
                     Server=localhost;
                     Database=NewtonLibrarySamir;
                     TrustServerCertificate=Yes;
                     Trusted_Connection=Yes");
        }

        // Om det behövs, definiera förhållandet mellan entiteterna här (med Fluent API) eller använd attribut för relationer i själva klasserna.
    }
}
    
