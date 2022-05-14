using NameShoes.Models;
using System.Collections.Generic;

namespace NameShoes.Services
{
    public interface IColorRepository
    {
        IEnumerable<Color> GetList();
        Color Get(string id);
        Color Create(Color request);
        Color Edit(Color request);
        bool Delete(string id);
    }
}
