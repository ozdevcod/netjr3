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

        public void OnGet()
        {
            BooksList = BookRead.getBooksbyId(null);
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            EditableBook = new Book();

            int iPages;
            if (Int32.TryParse(Request.Form["pages"].ToString(), out iPages))
            {
                EditableBook.Pages = iPages;
            }

            int iId;
            if (Int32.TryParse(Request.Form["idHidden"].ToString(), out iId))
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
        public PartialViewResult OnGetBookDetails(int? id)
        {
            Book book = new() { Id = 0, Name = "" };

            if (id == null)
            {
                return Partial("_updateBookPartial", book);
            }

            var bookList = BookRead.getBooksbyId(id);

            if (bookList == null)
            {
                return Partial("_updateBookPartial", book);
            }

            book = bookList.First();

            return Partial("_updateBookPartial", book);
        }
    }
}