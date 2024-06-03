using WebApiContactBookList.Models;

namespace WebApiContactBookList.Service.IService
{
    public interface IContactService
    {
        ContactModel Create(ContactModel item);
        ContactModel Delete(int id);
        ContactModel Edit(int id, ContactModel updatedData);
        List<ContactModel> GetAll();
        ContactModel GetById(int id);

    }
}
