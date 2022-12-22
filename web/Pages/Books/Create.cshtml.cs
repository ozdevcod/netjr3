using Appbooks.dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;
using System.Dynamic;
using System.Xml.Serialization;

namespace Appbooks.web.Pages.Books
{
    public class CreateModel : PageModel
    {
        public Book Book { get; set; }

        public void OnGet()
        {
            Book = new Book();
        }

        public void OnPost()
        {

            Book = new()
            {
                Name = Request.Form["name"],
                Author = Request.Form["author"]
            };

            if (Int32.TryParse(Request.Form["pages"].ToString(), out int pages))
            {
                Book.Pages = pages;
            }

            Book.Genre = Request.Form["genre"];
            Book.Year = Request.Form["year"];

            if (Book.Name.Length == 0
                || Book.Author.Length == 0
                || Book.Genre.Length == 0
                || Book.Pages == 0
                || Book.Year.Length == 0
                )
            {
                return;
            }

            CreateBook();
        }

        public void CreateBook()
        {
            data.BookCreate.CreateBooks(Book);
        }
    }
}