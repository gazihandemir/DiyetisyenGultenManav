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
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.ContactIsNotFound, "Blog Yazısı Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Contact> GetRemoveById(int? id)
        {
            BusinessLayerResult<Contact> res = new BusinessLayerResult<Contact>();
            Contact db_contact = Find(x => x.Id == id);
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
        public BusinessLayerResult<Contact> UpdateContact(Contact data)
        {
            BusinessLayerResult<Contact> res = new BusinessLayerResult<Contact>();
            Contact db_contact = Find(x => x.Id == data.Id);
            /*       if (true)
                   {
                   }
            */
            res.Result = Find(x => x.Id == data.Id);
            res.Result.Id = data.Id;
            res.Result.IsimSoyisim = data.IsimSoyisim;
            res.Result.TelefonNumarasi = data.TelefonNumarasi;
            res.Result.Email = data.Email;
            res.Result.Konu = data.Konu;
            res.Result.Mesaj = data.Mesaj;
            res.Result.Zaman = db_contact.Zaman;
            if (base.Update(res.Result) == 0) // Blog yazısı güncelleniyor.
            {
                res.AddError(ErrorMessageCode.ContactCouldNotUpdated, "Contact Güncellenemedi.");
            }
            return res;

        }
        public BusinessLayerResult<Contact> CreateContact(Contact data)
        {
            BusinessLayerResult<Contact> res = new BusinessLayerResult<Contact>();
            Contact db_contact = Find(x => x.Id == data.Id);
            res.Result = data;
            res.Result.Zaman = DateTime.Now;
            if (db_contact != null)
            {
                if (db_contact.Mesaj == data.Mesaj)
                {
                    res.AddError(ErrorMessageCode.ContactMesajAlreadyExists, "İletişim Mesajı 1 kez gönderilebilir.");
                }
            }
            else
            {
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.ContactIsNotInserted, "Contact eklenemedi");
                }
            }
            return res;
        }
    }
}
