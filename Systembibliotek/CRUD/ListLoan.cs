using Bibliotekssystem.Models;
using System;
using Microsoft.EntityFrameworkCore;

public class ListLoan
{
    public static void Run()
    {
        
        using(var context = new AppDbContext())
        {
            var loans = context.Loans.Include(l => l.Book)
                //vi ska lista bara loan book
                .Where(l => l.IsReturned ==false)
                .ToList();
            
            if(!loans.Any()) //om de finns ingen 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("There are no loan books");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (var loan in loans)
                {
                    System.Console.WriteLine($"\nBook: {loan.Book.Title}");
                    System.Console.WriteLine($"borrower: {loan.BorrowerName}");
                    System.Console.WriteLine($"Is returned: {loan.IsReturned}");
                }

            }
            
        }
    }
}