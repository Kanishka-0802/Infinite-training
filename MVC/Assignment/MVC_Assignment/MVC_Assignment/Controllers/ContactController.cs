using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_Assignment.Models;
using MVC_Assignment.Repositories;

namespace MVC_Assignment.Controllers
{
    public class ContactsController : Controller

    {

        private IContactRepository repository = new ContactRepository();

        // GET: Contacts

        public async Task<ActionResult> Index()

        {

            var contacts = await repository.GetAllAsync();

            return View(contacts);

        }

        // GET: Contacts/Create

        public ActionResult Create()

        {

            return View();

        }

        // POST: Contacts/Create

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Contact contact)

        {

            if (ModelState.IsValid)

            {

                await repository.CreateAsync(contact);

                return RedirectToAction("Index");

            }

            return View(contact);

        }

        // GET: Contacts/Delete/5

        public async Task<ActionResult> Delete(long id)

        {

            await repository.DeleteAsync(id);

            return RedirectToAction("Index");

        }

    }

}
