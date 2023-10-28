using Contract.Request.Categories;
using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class CategoryOperations
    {
        private readonly MainDbContext mainDbContext;

        public CategoryOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public List<Category> Search(string? name)
        {
            var query = mainDbContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(name)) //adam gönderdiyse.
                query = query.Where(x => x.Name == name);

            return query.ToList();
        }
        public Category GetSingle(int id)
        {
            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori Bulunamadı.");

            return category;
        }
        public void Create(string name)
        {
            #region Validations

            var currentCategory = mainDbContext.Categories.Where(x => x.Name == name).SingleOrDefault();
            if (currentCategory != null)
                throw new BusinessException(400, "Bu kategori adı kullanılıyor.");

            #endregion

            Category category = new Category();
            category.Name = name;
            mainDbContext.Categories.Add(category);

            mainDbContext.SaveChanges();
        }
        public void Update(int id, string name)
        {
            #region Validations

            var currentCategory = mainDbContext.Categories.Where(x => x.Id != id && x.Name == name).SingleOrDefault();
            if (currentCategory != null)
                throw new BusinessException(400, "Bu kategori adı kullanılıyor.");

            #endregion

            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori Bulunamadı.");

            category.Name = name;

            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori Bulunamadı.");

            mainDbContext.Categories.Remove(category);
            mainDbContext.SaveChanges();
        }
    }
}
