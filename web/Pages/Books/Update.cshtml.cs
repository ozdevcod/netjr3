using Appbooks.data;
using Appbooks.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appbooks.web.Pages.Books
{
    public class UpdateModel : PageModel
    {
        public Book Book { get; set; }

        public List<Book> BooksList { get; set; }

        public void OnGet()
        {
            Book = new Book();
            string sBookId = Request.Query["id"].ToString();
            bool isSuccess = int.TryParse(sBookId, out int iBookId);

            if (isSuccess)
            {
                getBookInfo(iBookId);
            }
        }

        public void OnPost()
        {
            Book = new Book();

            if (Int32.TryParse(Request.Form["pages"].ToString(), out int iPages))
            {
                Book.Pages = iPages;
            }

            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out int iId))
            {
                Book.Id = iId;
            }

            Book.Name = Request.Form["name"];
            Book.Author = Request.Form["author"];
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
                return;
            }

            updateBookInfo(Book);

        }

        public void getBookInfo(int bookId)
        {
            Book.Id = bookId;

            BooksList = BookRead.getBooksbyId(bookId);

            if (BooksList.Count == 1)
            {
                Book = BooksList.FirstOrDefault();
            }
        }

        public void updateBookInfo(Book book)
        {
            BookUpdate.UpdateBook(book);

        }
    }
}