using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibloitek.Models
{
    public class Auther
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigeringsattribut för böcker
        public ICollection<Book> Books { get; set; }
    }

}

