using bibloitek.Data;
using Microsoft.EntityFrameworkCore;

namespace bibloitek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


          DataAccess dataAccess = new DataAccess();
           dataAccess.Seed();

         // dataAccess.LoanBook(1, 2);


        }
    }
}