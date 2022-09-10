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
    public class SubscribeMailManager: IMailService
    {
       
        IMailDal _mailDal;
        public SubscribeMailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void Add(SubscribeMail entity)
        {
            _mailDal.Insert(entity);
        }

        
        public void Delete(SubscribeMail entity)
        {
            _mailDal.Delete(entity);
        }

        public SubscribeMail GetById(int id)
        {
            return _mailDal.GetById(id);
        }

        public List<SubscribeMail> GetList()
        {
            return _mailDal.List();
        }

        public void Update(SubscribeMail entity)
        {
            _mailDal.Update(entity);   
        }
    }
}
