using biblioteca.data;
using biblioteca.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.web.Pages.Books
{
    public class UpdateModel : PageModel
    {
        public string errorMessage { get; set; }
        public string successMessage { get; set; }

        public Book Book { get; set; }

        public List<Book> BooksList { get; set; }

        public void OnGet()
        {
            Book = new Book();
            string sBookId = Request.Query["id"].ToString();
            int iBookId;
            bool isSuccess = int.TryParse(sBookId, out iBookId);

            if (isSuccess)
            {
                getBookInfo(iBookId);
            }
        }

        public void OnPost()
        {
            Book = new Book();

            int iPages;
            if (Int32.TryParse(Request.Form["pages"].ToString(), out iPages))
            {
                Book.pages = iPages;
            }

            int iId;
            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out iId))
            {
                Book.id = iId;
            }

            Book.name = Request.Form["name"];
            Book.author = Request.Form["author"];
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

            updateBookInfo(Book);

            successMessage = "book updated correctly";

        }

        public void getBookInfo(int bookId)
        {
            Book.id = bookId;

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