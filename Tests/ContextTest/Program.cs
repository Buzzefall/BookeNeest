﻿using BookeNeest.Domain.Models;
using BookeNeest.Data.DB;
using BookeNeest.Data.DB.Context;

namespace ContextTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BookeNeestDbContext dbContext = new BookeNeestDbContext();

            //dbContext.Database.Delete();
            //dbContext.Database.

            //UserManager<User> manager = new UserManager<User>(new UserStore<User>(dbContext));

            //using (UnitOfWork Unit = new UnitOfWork())
            //{

            //    var randomizer = new Random();
            //    Book book1 = new Book { Id = Guid.NewGuid(), Name = "[Book 1] " + Guid.NewGuid().ToString(), ISBN = Guid.NewGuid().ToString(), Rating = randomizer.Next(10) + 1};
            //    Book book2 = new Book { Id = Guid.NewGuid(), Name = "[Book 2] " + Guid.NewGuid().ToString(), ISBN = Guid.NewGuid().ToString(), Rating = randomizer.Next(10) + 1};
            //    Book book3 = new Book { Id = Guid.NewGuid(), Name = "[Book 3] " + Guid.NewGuid().ToString(), ISBN = Guid.NewGuid().ToString(), Rating = randomizer.Next(10) + 1};

            //    Unit.BookRepository.Add(book1);
            //    Unit.BookRepository.Add(book2);
            //    Unit.BookRepository.Add(book3);

            //    Unit.Commit();
            //    //Unit.Discard();

            //    var books = dbContext.Books;

            //    foreach (var book in books)
            //    {
            //        Console.WriteLine("Book ID: " + book.Id);
            //        Console.WriteLine("Name: " + book.Name);
            //        Console.WriteLine("ISBN: " + book.ISBN);
            //        Console.WriteLine("Rating: " + book.Rating);
            //        Console.WriteLine("-----------------------------------------------\n");
            //    }
            //}
        }
    }
}
