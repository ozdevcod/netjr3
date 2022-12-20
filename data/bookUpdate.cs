using biblioteca.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca.data
{
    public static class BookUpdate
    {
        public static void UpdateBook(Book book)
        {
            string connectionString = DataAccessAdo.getConnectionString();

            StoredProcedureCollection spCollection = new();

            StoredProcedure storedProcedureUpdate = new() { StoredProcedureName = "spBooksUpdate" };

            storedProcedureUpdate.SetParam("name", System.Data.SqlDbType.VarChar, book.name);
            storedProcedureUpdate.SetParam("author", System.Data.SqlDbType.VarChar, book.author);
            storedProcedureUpdate.SetParam("pages", System.Data.SqlDbType.Int, book.pages.ToString());
            storedProcedureUpdate.SetParam("genre", System.Data.SqlDbType.VarChar, book.genre);
            storedProcedureUpdate.SetParam("year", System.Data.SqlDbType.VarChar, book.year);
            storedProcedureUpdate.SetParam("bookId", System.Data.SqlDbType.Int, book.id.ToString());

            spCollection.Add(storedProcedureUpdate);

            StoredProcedure.ExecuteSps(spCollection, connectionString);
        }
    }
}