using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static bibloitek.Models.LoanCard;


namespace bibloitek.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigeringsattribut för LoanCards som tillhör kunden
        public ICollection<LoanCard> LoanCards { get; set; }
    }
}
