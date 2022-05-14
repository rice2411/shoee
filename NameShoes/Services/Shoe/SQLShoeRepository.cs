using Microsoft.EntityFrameworkCore;
using NameShoes.Models;
using NameShoes.Models.Context;

namespace NameShoes.Services
{
    public class SQLShoeRepository : IShoeRepository
    {
        private readonly AppDbContext context;

        public SQLShoeRepository(AppDbContext context)
        {
            this.context = context;

        }
        public Shoe Create(Shoe request)
        {
            context.Shoe.Add(request);
            context.SaveChanges();
            return request;
        }

        public bool Delete(int id)
        {
            var delShoe = context.Shoe.Find(id);
            if (delShoe != null)
            {
                context.Shoe.Remove(delShoe);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Shoe Edit(Shoe request)
        {
            var editEmp = context.Shoe.Attach(request);
            editEmp.State = EntityState.Modified;
            context.SaveChanges();
            return request;
        }

        public Shoe Get(int id)
        {

            return context.Shoe.Find(id);
        }

        public System.Collections.Generic.IEnumerable<Shoe> GetList()
        {
            
            return context.Shoe;
        }
    }
}
