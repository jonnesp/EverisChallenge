using EverisChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Interfaces
{
    public interface IBookDb
    {
        public Task<List<Book>> GetAsync();

        public Task<Book> GetAsync(string id);

        public Task CreateAsync(Book book);

        public Task UpdateAsync(string id, Book book);

        public Task RemoveAsync(string id);
    }
}
