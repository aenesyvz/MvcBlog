using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfMailDal : Repository<SubscribeMail>, IMailDal
    {
    }
}
