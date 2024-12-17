using Bibliotekssystem.Models;
using System;
using Microsoft.EntityFrameworkCore;

public class Seed
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            if(!context.Authors.Any())
            {
                var author1 = new Author
                {
                    FirstName = "AK",
                    LastName = "47",
                    BirthYear = new DateTime(1989,7,10),
                    Biography = "Best gun"
                };

                var author2 = new Author()
                {
                    FirstName = "in",
                    LastName = "cline",
                    BirthYear = new DateTime (1999, 12, 17),
                    Biography = "Who"
                };
                context.Authors.Add(author1);
                context.Authors.Add(author2);
                context.SaveChanges();
                Console.WriteLine("Seed data for authors added successfully.");
            }
            else
            {
                Console.WriteLine("Authors already exist in the database.");
            }

            if(!context.Books.Any())
            {
                var book1 = new Book
                {
                    Title = "The water",
                    ReleaseDate = new DateTime(2011,1,1),
                    Summary = "Biggest waterfall in the world .",
                    Publisher = "Niagara falls",
                    IsAvailable = true
                };

                var book2 = new Book
                {
                    Title = "The City of Dreams",
                    ReleaseDate = new DateTime(2018, 11, 5),
                    Summary = "Las Vegas' tells the story of a young woman from a rural town who moves to Kathmandu with dreams of success. The novel captures the struggles of adapting to a fast-paced urban life, while navigating love, ambition, and cultural challenges.",
                    Publisher = "Mesut",
                    IsAvailable = true
                };
                
                context.Books.Add(book1);
                context.Books.Add(book2);
                context.SaveChanges();
                Console.WriteLine("Books have been added successfully.");
            }

            if (!context.BookAuthors.Any())
            {
                var book1 = context.Books.First(b => b.Title == "The water");
                var author1 = context.Authors.First(a => a.FirstName == "AK" && a.LastName == "47");
 
                var book2 = context.Books.First(b => b.Title == "The City of Dreams");
                var author2 = context.Authors.First(a => a.FirstName == "in" && a.LastName == "cline");
 
                context.BookAuthors.Add(new BookAuthor { BookID = book1.Id, AuthorId = author1.Id });
                context.BookAuthors.Add(new BookAuthor { BookID = book2.Id, AuthorId = author2.Id });
 
                context.SaveChanges();
                Console.WriteLine("Book-author relationships have been added successfully.");
            }
 
        }
    }
}