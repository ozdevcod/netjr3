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
    public static class BookCreate
    {
        public static void CreateBooks(Book book)
        {
            try
            {
                string connectionString = DataAccessAdo.getConnectionString();

                StoredProcedureCollection spCollection = new();

                StoredProcedure storedProcedureCreate = new() { StoredProcedureName = "spBooksCreate" };

                storedProcedureCreate.SetParam("name", System.Data.SqlDbType.VarChar, book.Name);
                storedProcedureCreate.SetParam("author", System.Data.SqlDbType.VarChar, book.Author);
                storedProcedureCreate.SetParam("pages", System.Data.SqlDbType.Int, book.Pages.ToString());
                storedProcedureCreate.SetParam("genre", System.Data.SqlDbType.VarChar, book.Genre);
                storedProcedureCreate.SetParam("year", System.Data.SqlDbType.VarChar, book.Year);

                spCollection.Add(storedProcedureCreate);

                StoredProcedure.ExecuteSps(spCollection, connectionString);

            }
            catch (Exception ex)
            {
                Console.Write("Exception: " + ex.ToString());
            }
        }
    }
}