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
    public class CommentManager :ICommentService
    {
        Repository<Comment> repository = new Repository<Comment>();
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        
        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x=>x.BlogId == id);
        }
        
        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.Status == true);
        }
        public void CommentStatusChangeToFalse(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentId == id);
            comment.Status = false;
            _commentDal.Update(comment);
        }
        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.Status == false);
        }
        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentId == id);
            comment.Status = true;
            _commentDal.Update(comment);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public void Add(Comment comment)
        {
            _commentDal.Insert(comment);
        }
    }
}
