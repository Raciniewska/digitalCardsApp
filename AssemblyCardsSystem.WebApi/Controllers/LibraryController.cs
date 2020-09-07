using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssemblyCardsSystem.WebApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AssemblyCardsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]

    public class LibraryController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;

        private static List<CardsResource> _libraryCards = new List<CardsResource>();

        private readonly List<LibraryResource> _libraryBooks = new List<LibraryResource>()
        {
            new LibraryResource()
            {
                Id = 1,
                Book = new Book()
                {
                     Title = "Miecz Przeznaczenia",
                     Author = "Andrzej Sapkowski",
                     ISBN = "9788375780642",
                     ReleaseDate = new DateTime(2014,1,01)
                     
                }
            },
            new LibraryResource()
            {
                Id = 2,
                Book = new Book()
                {
                    Title = "Malowany Czlowiek. Ksiega 1",
                    Author = "Peter V. Brett",
                    ISBN = "9788375781111",
                    ReleaseDate = new DateTime(2008,11,28)
                     
                }
            },
            new LibraryResource()
            {
                Id = 10,
                Book = new Book()
                {
                    Title = "Mikolajek",
                    Author = "Rene Goscinny, Jean-Jacques Sempe",
                    ISBN = "9788375780642",
                    ReleaseDate = new DateTime(2014,09,13)
                     
                }
            },
            new LibraryResource()
            {
                Id = 3,
                Book = new Book()
                {
                    Title = "Droga Cienia",
                    Author = "Brent Weeks",
                    ISBN = "9788375780281",
                    ReleaseDate = new DateTime(2017,5,31)
                     
                }
            },
            new LibraryResource()
            {
                Id = 4,
                Book = new Book()
                {
                    Title = "Praktyczny przewodnik. USA",
                    Author = "Monika Gruszczynska",
                    ISBN = "9788555780621",
                    ReleaseDate = new DateTime(2018,2,28)
                     
                }
            },
            new LibraryResource()
            {
                Id = 5,
                Book = new Book()
                {
                    Title = "Mikolajek",
                    Author = "Rene Goscinny, Jean-Jacques Sempe",
                    ISBN = "9788375780642",
                    ReleaseDate = new DateTime(2014,9,13)
                     
                }
            },
            new LibraryResource()
            {
                Id = 6,
                Book = new Book()
                {
                    Title = "Malowany Czlowiek. Ksiega 2",
                    Author = "Peter V. Brett",
                    ISBN = "9788375781221",
                    ReleaseDate = new DateTime(2009,1,28)
                     
                }
            }
        };

        public LibraryController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        
        [HttpGet("rented")]
        public IEnumerable<LibraryResource> GetRented()
        {
            return _libraryBooks;
        }
        
        [HttpGet("rent/{id}")]
        public async Task<ActionResult> Rent(int id)
        {
            var rentedBook = _libraryBooks.SingleOrDefault(r => r.Id == id);
            if (rentedBook == null)
            {
                return NotFound($"Book with id: {id} does not exist");
            }
            
            await _publishEndpoint.Publish<BookRented>(new {Id = id, Title = rentedBook.Book.Title});
            return Ok();
        }

        [HttpGet("Delete/{id}")]
        public void Delete(string id)
        {
            var cardToDelete = _libraryCards.SingleOrDefault(r => r.Id == id);
            if (cardToDelete == null)
            {
                return;
            }
            _libraryCards.Remove(cardToDelete);
            return;
        }

        [HttpGet("Edit/{id}")]
        public CardsResource Edit(string id)
        {
            var cardToEdit = _libraryCards.SingleOrDefault(r => r.Id == id);
            return cardToEdit;
        }

        [HttpGet("Edited/{id}/{sort}/{KNNR}/{employeeID}/{employeeFN}/{employeeLN}")]
        public CardsResource Edited(string id,string employeeLN, string employeeFN, string employeeID, string knnr, string sort)
        {

            var cardToEdit = _libraryCards.SingleOrDefault(r => r.Id == id);
            cardToEdit.AssemblyCard.EmployeeFN = employeeFN;
            cardToEdit.AssemblyCard.EmployeeLN = employeeLN;
            cardToEdit.AssemblyCard.EmployeeID = employeeID;
            cardToEdit.AssemblyCard.KNNR = knnr;
            cardToEdit.AssemblyCard.Sort = sort;
            return cardToEdit;
        }

        [HttpGet("Create/{employeeLN}/{employeeFN}/{employeeID}/{knnr}/{sort}/{prnr}")]
        public void Create(string employeeLN, string employeeFN, string employeeID, string knnr, string sort, string prnr)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();

            _libraryCards.Add(new CardsResource
            {
                Id = str,
                AssemblyCard = new AssemblyCard
                {
                    EmployeeFN = employeeFN,
                    EmployeeLN = employeeLN,
                    EmployeeID = employeeID,
                    KNNR = knnr,
                    Sort = sort,
                    PrNr = prnr,
                }
            });
            return;
        }

        [HttpGet("created")]
        public IEnumerable<CardsResource> GetCreated()
        {

                return _libraryCards;
        }
    }
}