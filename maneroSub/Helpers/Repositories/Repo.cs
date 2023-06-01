using maneroSub.Contexts;
using maneroSub.Models.Interfaces.Products;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;


namespace maneroSub.Helpers.Repositories
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public Repo(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        //hämtar tillbaka en produkt i listan, sätter upp för att skriva ett LAMBDA expression
        // product => product.id == name
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().SingleOrDefaultAsync(expression);
                return entity!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        // hämtar in alla produkter i listan
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<TEntity>().ToListAsync();
                return entities!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
/*
 
 
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        if(entities.Any())
            return entities;
    }
    return null!;
 
 */