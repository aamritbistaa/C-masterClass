using Microsoft.AspNetCore.Mvc;
using WebApiContactBookList.Models;
using WebApiContactBookList.Service.IService;

namespace WebApiContactBookList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _contact;
        public ContactController(IContactService contact)
        {
            _contact = contact;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _contact.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _contact.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ContactModel item)
        {
            var result = _contact.Create(item);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] ContactModel item)
        {
            var result = _contact.Edit(id, item);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contact.Delete(id);
            return Ok(result);
        }
    }
}
