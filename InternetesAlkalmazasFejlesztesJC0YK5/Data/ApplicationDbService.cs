using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetesAlkalmazasFejlesztesJC0YK5.Data
{
    public class ApplicationDbService
    {
        private readonly ApplicationDbContext _db;

        public ApplicationDbService(ApplicationDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public List<Part> GetAllParts()
        {
            var partList = _db.Parts.ToList();
            return partList;
        }
        public Part GetPartById(int id)
        {
            return _db.Parts.FirstOrDefault(x => x.Id == id);
        }
        public void AddOrUpdatePart(Part part)
        {
            if (part.Id == 0)
            {
                _db.Parts.Add(part);
            }
            else
            {
                _db.Parts.Update(part);
            }
            _db.SaveChanges();
        }
        public void DeletePart(int id)
        {
            var part = _db.Parts.FirstOrDefault(x => x.Id == id);
            _db.Parts.Remove(part);
            _db.SaveChanges();
        }


        public List<Product> GetAllProducts()
        {
            var productList = _db.Products.ToList();
            return productList;
        }
        public Product GetProductById(int id)
        {
            return _db.Products.FirstOrDefault(x => x.Id == id);
        }
        public void AddOrUpdateProduct(Product product)
        {
            if (product.Id == 0)
            {
                _db.Products.Add(product);
            }
            else
            {
                _db.Products.Update(product);
            }
            _db.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        //Part Product connection table
        public List<ProductPart> GetPartsOfTheProduct(int productId)
        {
            return _db.ProductParts.Where(x => x.TermekId == productId).ToList();
        }

        public void AddOrUpdateProductParts(ProductPart productParts)
        {
            if (_db.ProductParts.Where(x=>x.AlkatreszId == productParts.AlkatreszId && x.TermekId == productParts.TermekId).Count() > 0)
            {
                _db.ProductParts.Add(productParts);
            }
            else
            {
                _db.ProductParts.Update(productParts);
            }
            _db.SaveChanges();
        }
    }
}
