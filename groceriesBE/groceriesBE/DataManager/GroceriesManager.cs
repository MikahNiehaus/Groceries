using groceriesBE.Repository;
using System.Collections.Generic;
using System.Linq;

namespace groceriesBE.DataManager
{
    public class GroceriesManager : IDataRepository<Groceries>
    {
            readonly GroceriesContext _groceriesContext;
            public GroceriesManager(GroceriesContext context)
            {
                _groceriesContext = context;
            }
            public IEnumerable<Groceries> GetAll()
            {
                return _groceriesContext.Groceries.ToList();
            }
            public Groceries Get(long id)
            {
                return _groceriesContext.Groceries
                      .FirstOrDefault(e => e.GroceriesId == id);
            }
            public void Add(Groceries entity)
            {
                _groceriesContext.Groceries.Add(entity);
                _groceriesContext.SaveChanges();
            }
            public void Update(Groceries groceries, Groceries entity)
            {
                groceries.Food = entity.Food;
                groceries.Amount = entity.Amount;
                groceries.Notes = entity.Notes;
                _groceriesContext.SaveChanges();
            }
            public void Delete(Groceries groceries)
            {
                _groceriesContext.Groceries.Remove(groceries);
                _groceriesContext.SaveChanges();
            }

      
    }
}
