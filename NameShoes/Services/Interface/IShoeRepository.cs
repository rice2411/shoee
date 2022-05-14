using NameShoes.Models;
using System.Collections.Generic;

namespace NameShoes.Services
{
    public interface IShoeRepository
    {
        IEnumerable<Shoe> GetList();
        Shoe Get(int id);
        Shoe Create(Shoe request);
        Shoe Edit(Shoe request);
        bool Delete(int id);
    }
}
