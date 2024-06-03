using WebApiContactBookList.Models;
using WebApiContactBookList.Service.IService;

namespace WebApiContactBookList.Service
{
    public class ContactService:IContactService
    {
        private static List<ContactModel> ContactBook = new List<ContactModel>();

        public ContactModel Create(ContactModel item)
        {
            ContactBook.Add(item);
            return item;
        }

        public ContactModel Delete(int id)
        {
            var item = ContactBook.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return null;

            ContactBook.Remove(item);
            return item;
        }

        public ContactModel Edit(int id, ContactModel updatedData)
        {
            var item = ContactBook.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return null;

            item.FirstName = updatedData.FirstName;
            item.LastName = updatedData.LastName;
            item.EmailAddress1 = updatedData.EmailAddress1;
            item.EmailAddress2 = updatedData.EmailAddress2;
            item.PhoneNumber1 = updatedData.PhoneNumber1;
            item.PhoneNumber2 = updatedData.PhoneNumber2;

            return item;
        }

        public List<ContactModel> GetAll()
        {
            return ContactBook;
        }

        public ContactModel GetById(int id)
        {
            return ContactBook.FirstOrDefault(x => x.Id == id);
        }
    }
}
