﻿using BooksProAPI.Data.Models;
using BooksProAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksProAPI.Data.Services
{
    public class AuthorsService
    {
        public AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }


        public void AddAuthor(AuthorVM authorVM)
        {
            var _author = new Author()
            {
                FullName = authorVM.FullName,
                
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
