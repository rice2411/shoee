

using NameShoes.Models;
using NameShoes.Models.Context;
using NameShoes.Services;

namespace NameColors.Services
{
    public class SQLColorRepository : IColorRepository
    {
        private readonly AppDbContext context;

        public SQLColorRepository(AppDbContext context)
        {
            this.context = context;

        }
        public Color Create(Color request)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Color Edit(Color request)
        {
            throw new System.NotImplementedException();
        }

        public Color Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Color> GetList()
        {
            
            return context.Color;
        }
    }
}
