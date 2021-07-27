﻿using BooksProAPI.Data.Models;
using BooksProAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksProAPI.Data.Services
{
    public class BooksService
    {
        // private readonly AppDbContext _context;
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
               // Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,


            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }

        //public List<Book> GetBooks() => _context.Books.ToList();


        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault( n => n.Id == bookId);

        public Book UpdateBookById (int bookId,BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate : null;
                _book.Genre = book.Genre;
               // _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;
                _context.SaveChanges();
            }

            return _book;
        }


        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
