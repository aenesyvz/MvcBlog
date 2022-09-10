using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : Repository<Comment>, ICommentDal
    {
    }
}
