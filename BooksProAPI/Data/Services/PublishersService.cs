using BooksProAPI.Data.Models;
using BooksProAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public void AddPubliher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
                
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
