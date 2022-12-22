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

        public string errorMessage { get; set; }
        public string successMessage { get; set; }

        public void OnGet()
        {
            errorMessage = string.Empty;
            successMessage = string.Empty;
            Book = new Book();
        }

        public void OnPost()
        {
            try
            {
                Book = new Book();
                Book.Name = Request.Form["name"];
                Book.Author = Request.Form["author"];

                int pages;

                if (Int32.TryParse(Request.Form["pages"].ToString(), out pages))
                {
                    Book.Pages = pages;
                }

                Book.Genre = Request.Form["genre"];
                Book.Year = Request.Form["year"];

                //backend validation 
                if (Book.Name.Length == 0
                    || Book.Author.Length == 0
                    || Book.Genre.Length == 0
                    || Book.Pages == 0
                    || Book.Year.Length == 0
                    )
                {
                    errorMessage = "all fields are required";
                    return;
                }

                CreateBook();

                successMessage = "book created correctly";

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        public void CreateBook()
        {
            data.BookCreate.CreateBooks(Book);
        }
    }
}