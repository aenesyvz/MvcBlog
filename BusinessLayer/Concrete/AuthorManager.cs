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
    public class AuthorManager : IAuthorService
    {
        Repository<Author> repository = new Repository<Author>();
        IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
       

        public List<Author> GetList()
        {
            return _authorDal.List();
        }

        public void Add(Author author)
        {
            _authorDal.Insert(author);
        }

        public Author GetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public void Delete(Author author)
        {
            _authorDal.Delete(author);
        }

        public void Update(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
