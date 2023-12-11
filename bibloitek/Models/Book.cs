using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static bibloitek.Models.Auther;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bibloitek.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public Guid ISBN { get; set; } = Guid.NewGuid();
        public bool Available { get; set; }
        public DateTime? BorrowingDate { get; set; }
        public DateTime? ReturnTime { get; set; }
        public int YearPublished { get; set; } = new Random().Next(1900, 2023);
        public int Rating { get; set; } = new Random().Next(1, 5);

        public ICollection<Auther>? Authors { get; set; }

        //public int? LoanCardId { get; set; }
        public LoanCard? Loans { get; set; }
    }
}