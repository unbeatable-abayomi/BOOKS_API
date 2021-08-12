﻿using BooksProAPI.Data.Models;
using BooksProAPI.Data.ViewModels;
using BooksProAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BooksProAPI.Data.Services
{
    public class PublishersService
    {
        public AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }


        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("Name starts with number", publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
                
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }
        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);
     

        
        public PublisherWithBooksAndAuthorVM GetPublishersData(int publisherId)
        {
            var _publishaData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()

                }).ToList()
            }).FirstOrDefault();

            return _publishaData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} does not exist");
            }
        }



        private bool StringStartsWithNumber(string name)
        {
            if (Regex.IsMatch(name, @"^\d")) return true;
            return false;
        }


        //or

        //private bool StringStartsWithNumber(string name)
        //{
        //    return (Regex.IsMatch(name, @"^\d"));

        //}

        //or
        //private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));




    }
}
