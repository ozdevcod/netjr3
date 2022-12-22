using Appbooks.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Appbooks.data
{
    public static class BookUpdate
    {
        public static void UpdateBook(Book book)
        {
            string connectionString = DataAccessAdo.getConnectionString();

            StoredProcedureCollection spCollection = new();

            StoredProcedure storedProcedureUpdate = new() { StoredProcedureName = "spBooksUpdate" };

            storedProcedureUpdate.SetParam("name", System.Data.SqlDbType.VarChar, book.Name);
            storedProcedureUpdate.SetParam("author", System.Data.SqlDbType.VarChar, book.Author);
            storedProcedureUpdate.SetParam("pages", System.Data.SqlDbType.Int, book.Pages.ToString());
            storedProcedureUpdate.SetParam("genre", System.Data.SqlDbType.VarChar, book.Genre);
            storedProcedureUpdate.SetParam("year", System.Data.SqlDbType.VarChar, book.Year);
            storedProcedureUpdate.SetParam("bookId", System.Data.SqlDbType.Int, book.Id.ToString());

            spCollection.Add(storedProcedureUpdate);

            StoredProcedure.ExecuteSps(spCollection, connectionString);
        }
    }
}