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
        //Part database handling
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
            var pp = _db.ProductParts.FirstOrDefault(x => x.AlkatreszId == part.Id);
            if (pp != null)
            {
                RecalculateProduct(pp.TermekId);
            }
        }
        public bool DeletePart(int id)
        {
            var part = _db.Parts.FirstOrDefault(x => x.Id == id);
            if (_db.ProductParts.Where(x => x.AlkatreszId == id).Count() == 0)
            {
                _db.Parts.Remove(part);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Product database handling
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
        public bool DeleteProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if(_db.ProductParts.Where(x => x.TermekId == id).Count() == 0)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Part Product database handling
        public List<ProductPart> GetAllPartProduct()
        {
            return _db.ProductParts.ToList();
        }
        public List<ProductPart> GetPartsOfTheProduct(int productId)
        {
            return _db.ProductParts.Where(x => x.TermekId == productId).ToList();
        }

        public void AddOrUpdateProductParts(ProductPart productPart)
        {
            if (_db.ProductParts.Where(x=>x.AlkatreszId == productPart.AlkatreszId && x.TermekId == productPart.TermekId).Count() == 0)
            {
                _db.ProductParts.Add(productPart);
            }
            else
            {
                _db.ProductParts.Update(productPart);
            }
            _db.SaveChanges();
            RecalculateProduct(productPart.TermekId);
        }

        public void DeleteProductPart(ProductPart productPart)
        {
            _db.ProductParts.Remove(productPart);
            _db.SaveChanges();
            RecalculateProduct(productPart.TermekId);
        }

        private void RecalculateProduct(int productId)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == productId);
            var parts = _db.Parts.ToList();
            var productParts = _db.ProductParts.Where(x => x.TermekId == productId);
            int suly = 0;
            int ar = 0;
            foreach (var pp in productParts)
            {
                suly += pp.Mennyiseg * parts.FirstOrDefault(x => x.Id == pp.AlkatreszId).SulyGrammban;
                ar += pp.Mennyiseg * parts.FirstOrDefault(x => x.Id == pp.AlkatreszId).Ar;
            }
            product.SulyGrammban = suly;
            product.Ar = (int)(ar * 1.1);
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}
