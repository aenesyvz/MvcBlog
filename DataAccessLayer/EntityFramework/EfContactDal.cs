using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactDal : Repository<Contact>, IContactDal
    {
    }
}
