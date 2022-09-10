using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryService
    {
      

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }
      
        public void CategoryStatusTrueBL(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryId == id);
            category.CategoryStatus = true;
            _categoryDal.Update(category);

        }
        public void CategoryStatusFalseBL(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryId == id);
            category.CategoryStatus = false;
            _categoryDal.Update(category);

        }
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void Add(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
