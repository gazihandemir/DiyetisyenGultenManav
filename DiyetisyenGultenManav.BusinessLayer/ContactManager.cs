using DiyetisyenGultenManav.BusinessLayer.Abstract;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class ContactManager : ManagerBase<Contact>
    {
        public BusinessLayerResult<Contact> GetContactById(int? id)
        {
            BusinessLayerResult<Contact> res = new BusinessLayerResult<Contact>();
            res.Result = Find(x => x.ID == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.ContactIsNotFound, "Blog Yazısı Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Contact> GetRemoveById(int? id)
        {
            BusinessLayerResult<Contact> res = new BusinessLayerResult<Contact>();
            Contact db_contact = Find(x => x.ID == id);
            if (db_contact != null)
            {
                if (Delete(db_contact) == 0)
                {
                    res.AddError(ErrorMessageCode.ContactCouldNotRemove, "Blog Yazısı Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.ContactIsNotFound, "Kullanıcı Bulunamadı.");
            }
            return res;
        }
    }
}
