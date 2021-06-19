using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDAO
    {
        private TranMinhKhoaContext db = null;
        public CategoryDAO()
        {
            db = new TranMinhKhoaContext();
        }
        //đổ category ra trang chủ
        public List<Category> ListNewCate(int number)
        {
            return db.Categories.OrderByDescending(x => x.Name).Take(number).ToList();
        }
        public bool Insert(Category entityCat)
        {

            try
            {
                db.Categories.Add(entityCat);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category Find(string ID)
        {
            return db.Categories.Find(ID);
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        public bool Update(Category entityCat)
        {
            try
            {
                var catID = Find(entityCat.CategoryID.ToString());
                if (!string.IsNullOrEmpty(entityCat.Name))
                {
                    catID.Name = entityCat.Name;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Delete(string ID)
        {
            try
            {
                Category category = db.Categories.Find(ID);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
