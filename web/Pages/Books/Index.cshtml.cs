using biblioteca.dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using biblioteca.data;

namespace biblioteca.web.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<Book> BooksList { get; set; }

        public void OnGet()
        {
            BooksList = BookRead.getBooksbyId(null);
        }
    }
}