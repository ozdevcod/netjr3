using Appbooks.dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Appbooks.data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Appbooks.web.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<Book> BooksList { get; set; }
        public Book IndexBook { get; set; } = default!;

        public void OnGet()
        {
            BooksList = BookRead.getBooksbyId(null);
        }

        public void OnPostCreate()
        {
            IndexBook = new()
            {
                Name = Request.Form["name"],
                Author = Request.Form["author"]
            };

            if (Int32.TryParse(Request.Form["pages"].ToString(), out int pages))
            {
                IndexBook.Pages = pages;
            }

            IndexBook.Genre = Request.Form["genre"];
            IndexBook.Year = Request.Form["year"];

            if (IndexBook.Name.Length == 0
                || IndexBook.Author.Length == 0
                || IndexBook.Genre.Length == 0
                || IndexBook.Pages == 0
                || IndexBook.Year.Length == 0
                )
            {
                return;
            }

            data.BookCreate.CreateBooks(IndexBook);
            BooksList = BookRead.getBooksbyId(null);
        }

        public void OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                BooksList = new();

                return;
            }

            IndexBook = new Book();

            if (Int32.TryParse(Request.Form["pages"].ToString(), out int iPages))
            {
                IndexBook.Pages = iPages;
            }

            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out int iId))
            {
                IndexBook.Id = iId;
            }

            IndexBook.Name = Request.Form["name"];
            IndexBook.Author = Request.Form["author"];
            IndexBook.Genre = Request.Form["genre"];
            IndexBook.Year = Request.Form["year"];

            if (IndexBook.Name.Length == 0
                || IndexBook.Author.Length == 0
                || IndexBook.Genre.Length == 0
                || IndexBook.Pages == 0
                || IndexBook.Year.Length == 0
                )
            {
                return;
            }

            UpdateBookInfo(IndexBook);
            BooksList = BookRead.getBooksbyId(null);
        }

        public void OnPostDelete()
        {
            if (!ModelState.IsValid)
            {
                BooksList = new();
                return;
            }

            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out int iId))
            {
                data.BookDelete.deleteBookbyId(iId);
            }
            BooksList = BookRead.getBooksbyId(null);
        }

        public void UpdateBookInfo(Book book)
        {
            BookUpdate.UpdateBook(book);
        }

        public PartialViewResult OnGetBookCreate()
        {
            IndexBook = new();
            return Partial("_ModalCreateBookPartial", IndexBook);
        }

        public PartialViewResult OnGetBookUpdate(int? id)
        {
            IndexBook = new();

            var bookList = BookRead.getBooksbyId(id);

            IndexBook = bookList.First();

            return Partial("_ModalUpdateBookPartial", IndexBook);
        }

        public PartialViewResult OnGetBookDelete(int? id)
        {
            IndexBook = new();

            var bookList = BookRead.getBooksbyId(id);

            IndexBook = bookList.First();

            return Partial("_ModalDeleteBookPartial", IndexBook);
        }
        public PartialViewResult OnGetBookDeleteConfirmation(int? id)
        {
            IndexBook = new();

            var bookList = BookRead.getBooksbyId(id);

            IndexBook = bookList.First();

            return Partial("_ModalDeleteBookConfirmationPartial", IndexBook);
        }
    }
}