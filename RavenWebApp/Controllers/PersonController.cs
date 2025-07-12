using Microsoft.AspNetCore.Mvc;
using RavenWebApp.Models;
using System.Diagnostics;
using RavenDbAccessLayer;
using RavenDbAccessLayer.Models;
using System.Net;
using System;

namespace RavenWebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _personService = new PersonService();

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var people = _personService.GetAllPeople();
            return View(people);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _personService.AddPerson(person);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var decodedId = WebUtility.UrlDecode(id);
            if (string.IsNullOrEmpty(decodedId)) return NotFound();

            var person = _personService.GetPersonById(decodedId);
            if (person == null) return NotFound();

            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (person == null || string.IsNullOrEmpty(person.Id))
                return BadRequest();
            person.Id = WebUtility.UrlDecode(person.Id);
            _personService.UpdatePerson(person);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            id = WebUtility.UrlDecode(id);
            _personService.DeletePerson(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
