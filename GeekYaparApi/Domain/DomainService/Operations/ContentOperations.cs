using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DomainService.Operations
{
    public class ContentOperations
    {
        private readonly MainDbContext mainDbContext;

        public ContentOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public List<Content> Search(int? categoryId, string name, string description, string author)
        {
            var query = mainDbContext.Contents.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(x => x.Description.Contains(description));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(x => x.Author.Contains(author));

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId);

            return query.ToList();

        }

        public Content GetSingle(int id)
        {
            var content = mainDbContext.Contents.Where(x => x.Id == id).SingleOrDefault();
            if (content == null)
                throw new BusinessException(404, "İçerik Bulunamadı.");

            return content;
        }

        public void Create(string name, string author, string description, int categoryId)
        {
            #region Validations

            var currentContent = mainDbContext.Contents.Where(x => x.Name == name).SingleOrDefault();
            if (currentContent != null)
                throw new BusinessException(400, "Bu içerik adı kullanılıyor.");

            #endregion

            Content content = new Content();
            content.Name = name;
            content.Author = author;
            content.Description = description;
            content.CategoryId = categoryId;

            mainDbContext.Contents.Add(content);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string name, string author, string description, int categoryId)
        {
            #region Validations

            var currentContent = mainDbContext.Contents.Where(x => x.Id != id && x.Name == name).SingleOrDefault();
            if (currentContent != null)
                throw new BusinessException(400, "Bu içerik adı kullanılıyor.");

            #endregion

            var content = mainDbContext.Contents.Where(x => x.Id == id).SingleOrDefault();
            if (content == null)
                throw new BusinessException(404, "İçerik Bulunamadı.");

            content.Name = name;
            content.Author = author;
            content.Description = description;
            content.CategoryId = categoryId;

            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var content = mainDbContext.Contents.Where(x => x.Id == id).SingleOrDefault();
            if (content == null)
                throw new BusinessException(404, "İçerik Bulunamadı.");

            mainDbContext.Contents.Remove(content);
            mainDbContext.SaveChanges();
        }
    }
}
