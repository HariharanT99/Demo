using DataProtection.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DataProtection.Controllers
{
    public class ProtectionController : Controller
    {
        IDataProtector _protector;

        public ProtectionController(IDataProtectionProvider dataProtectionProvider)
        {
            _protector = dataProtectionProvider.CreateProtector("IdEncript");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Id = 12;
            string encryptedId = Protect(Id.ToString());

            ViewBag.enId = encryptedId;

            ViewBag.dcId = int.Parse(UnProtect(encryptedId));

            return View();
        }

        public IActionResult Detail(string Id)
        {
            int decId = 0;
            if(Id != null)
                decId = int.Parse(UnProtect(Id));

            List<Person> people = new List<Person>();

            people.Add(new Person
            {
                Id = 12,
                Name = "Hari"
            });
            people.Add(new Person
            {
                Id = 15,
                Name = "Haran"
            });
            people.Add(new Person
            {
                Id = 16,
                Name = "Ram"
            });

            Person person1 = null;
            foreach (var person in people)
            {
                if (person.Id == decId)
                    person1 = person;
            }

            if (person1 != null)
            {
                return View(person1);
            }

            return View(person1);
        }

        private string Protect(string data)
        {
            return _protector.Protect(data);
        }

        private string UnProtect(string data)
        {
            return _protector.Unprotect(data);
        }
    }
}
