using biblioteca.dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;
using System.Dynamic;
using System.Xml.Serialization;

namespace biblioteca.web.Pages.Books
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
                Book.name = Request.Form["name"];
                Book.author = Request.Form["author"];

                int pages;

                if (Int32.TryParse(Request.Form["pages"].ToString(), out pages))
                {
                    Book.pages = pages;
                }

                Book.genre = Request.Form["genre"];
                Book.year = Request.Form["year"];

                //backend validation 
                if (Book.name.Length == 0
                    || Book.author.Length == 0
                    || Book.genre.Length == 0
                    || Book.pages == 0
                    || Book.year.Length == 0
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