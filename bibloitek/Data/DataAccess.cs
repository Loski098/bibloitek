using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bibloitek.Models;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace bibloitek.Data
{
   public class DataAccess
   {
        enum titlar
        {
            Samirsbook,josefsbook,stefansbook
        }
    public void Seed()
        {
            for (int i = 0; i < 5; i++)
            {


                csSeedGenerator rnd = new csSeedGenerator();
                createAuther(rnd.FirstName, rnd.LastName);
                createBook(rnd.FromEnum<titlar>().ToString());
                createCustomer(rnd.FirstName, rnd.LastName);
                CreateLoanCard();

            }





        }
        
            





        public void createAuther(string FirstName,string LastName)
        {
            using (var context = new Context())
            {
                Auther auther = new Auther();
                auther.FirstName = FirstName; 
                auther.LastName= LastName;
                context.Authors.Add(auther);
                context.SaveChanges();
            }

        }

        public void createBook(string Titel )
        {
            using (var context = new Context())
            {
                Book book = new Book();
                book.Title = Titel;
                book.YearPublished = new Random().Next(1900,2000);
                book.Rating = new Random().Next(0, 5);
                book.Available = true;
                context.Books.Add(book);
                context.SaveChanges();

            }

        }

        public void createCustomer(string Firstname, string Lastname )
        {
            using (var context = new Context())
            {
                Customer customer = new Customer();
                customer.FirstName = Firstname;
                customer.LastName= Lastname;
                LoanCard loanCard = new LoanCard();
                loanCard.Customer= customer;
                context.Customers.Add(customer);
                context.SaveChanges();
            }

        }
        public void CreateLoanCard()
        {
            using (var context = new Context())
            {
                LoanCard loanCard= new LoanCard();
                loanCard.PIN = new Random().Next(1000,1993);
                context.LoanCards.Add(loanCard);
                context.SaveChanges();
            }
        }


        public void LoanBook(int customerId, int bookId)
        {
            using (var context = new Context())
            {
                var customer = context.Customers.Find(customerId);

                if (customer != null)
                {
                    // Explicit Loading för LoanCard
                    context.Entry(customer)
                        .Collection(c => c.LoanCards)
                        .Load();

                    var book = context.Books.Find(bookId);

                    if (book != null)
                    {
                        if (!book.Available)
                        {
                            // Om boken redan är utlånad
                            // Åtgärder vid bok som redan är utlånad
                        }
                        else
                        {
                            // Här kan du utföra dina åtgärder för att låna ut boken
                            book.BorrowingDate = DateTime.Now;
                            book.ReturnTime = DateTime.Now.AddDays(14);
                            book.Available = false;

                            // Här kan du associera lånekortet för kunden med boken
                            // ... antag att loanCard är det önskade LoanCard-objektet
                            // book.Loans = loanCard;

                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        // Hantera scenarion där boken inte hittas i databasen
                    }
                }
                else
                {
                    // Hantera scenarion där kunden inte hittas i databasen
                }
            }
        }


        public void ReturnBook(int bookid)
        {
            using (var context = new Context())
            {
                var book = context.Books.Include(p => p.Loans).FirstOrDefault(p => p.BookId == bookid);
                book.Loans = null;
                book.BorrowingDate = null;
                book.ReturnTime = null;
                book.Available = true;
                context.SaveChanges();

            }

        }

        public void RemoveAuther(int id)
        {
            using (var context = new Context())
            {
                var auther = context.Authors.Find(id);
                context.Authors.Remove(auther);
                context.SaveChanges() ;
            }

        }

        public void RemoveBook(int id)
        {
            using (var context = new Context())
            {
                var book = context.Books.Find(id);
                context.Books.Remove(book);
                context.SaveChanges();
            }

        }

        public void RemoveCustomer(int id)
        {
            using (var context = new Context())
            {
                var costemer = context.Customers.Find(id);
                context.Customers.Remove(costemer);
                var LoanCard = context.LoanCards.Include(p => p.Customer ).SingleOrDefault(p => p.Customer.Id==id);



                context.SaveChanges();
            }

        }



    }


}

