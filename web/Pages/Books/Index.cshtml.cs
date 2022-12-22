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
        public Book EditableBook { get; set; } = default!;
        public String PostType { get; set; }

        public void OnGet()
        {
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

        public void OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                BooksList = new();

                return;
            }

            EditableBook = new Book();

            if (Int32.TryParse(Request.Form["pages"].ToString(), out int iPages))
            {
                EditableBook.Pages = iPages;
            }

            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out int iId))
            {
                EditableBook.Id = iId;
            }

            EditableBook.Name = Request.Form["name"];
            EditableBook.Author = Request.Form["author"];
            EditableBook.Genre = Request.Form["genre"];
            EditableBook.Year = Request.Form["year"];

            if (EditableBook.Name.Length == 0
                || EditableBook.Author.Length == 0
                || EditableBook.Genre.Length == 0
                || EditableBook.Pages == 0
                || EditableBook.Year.Length == 0
                )
            {
                return;
            }

            updateBookInfo(EditableBook);
            BooksList = BookRead.getBooksbyId(null);
        }

        public void updateBookInfo(Book book)
        {
            BookUpdate.UpdateBook(book);
        }

        public PartialViewResult OnGetBookDetailsUpdate(int? id)
        {
            EditableBook = new();

            var bookList = BookRead.getBooksbyId(id);

            EditableBook = bookList.First();

            return Partial("_ModalUpdateBookPartial", EditableBook);
        }

        public PartialViewResult OnGetBookDetailsDelete(int? id)
        {
            EditableBook = new();

            var bookList = BookRead.getBooksbyId(id);

            EditableBook = bookList.First();

            return Partial("_ModalDeleteBookPartial", EditableBook);
        }
    }
}