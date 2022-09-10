using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {
        Repository<Author> repository = new Repository<Author>();
        Repository<Blog> repositoryBlog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repository.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repositoryBlog.List(x => x.AuthorId == id);
        }
        public void EditAuthor(Author p)
        {
            Author author = repository.Find(x => x.AuthorId == p.AuthorId);
            author.AuthorName = p.AuthorName;
            author.AuthorTitle = p.AuthorTitle;
            author.AboutShort = p.AboutShort;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.Mail = p.Mail;
            author.PhoneNumber = p.PhoneNumber;
            author.Password = p.Password;
            repository.Update(author);
        }
    }
}
