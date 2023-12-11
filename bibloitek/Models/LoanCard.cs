using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibloitek.Models
{
    public class LoanCard
    {
        [Key]
        public int LoanCardId { get; set; }
        public int CustomerId { get; set; }

        public int PIN { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Customer? Customer { get; set; }
    }

}