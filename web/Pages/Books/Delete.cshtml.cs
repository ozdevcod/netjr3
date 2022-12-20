using biblioteca.data;
using biblioteca.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.web.Pages.Books
{
    public class DeleteModel : PageModel
    {
        public string errorMessage { get; set; }
        public string successMessage { get; set; }

        public List<Book> BooksList { get; set; }

        public Book Book { get; set; }

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
            int iId;

            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out iId))
            {
                deleteBookInfo(iId);
            }

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

        public void deleteBookInfo(int id)
        {
            data.BookDelete.deleteBookbyId(id);
            successMessage = "book deleted correctly";
            Book = new Book();
        }


    }
}