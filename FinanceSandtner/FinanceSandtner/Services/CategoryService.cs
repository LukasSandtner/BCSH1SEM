using System.Collections.Generic;
using System.Linq;
using FinanceSandtner.Models;
using LiteDB;

namespace FinanceSandtner.Services
{
    public class CategoryService
    {
        private readonly DatabaseService _db = DatabaseService.Instance;

        public void Add(Category category) => _db.Category.Insert(category);

        public List<Category> GetAll() => _db.Category.FindAll().ToList();

        public void Update(Category category) => _db.Category.Update(category);

        public void Delete(ObjectId id) => _db.Category.Delete(id);
    }
}