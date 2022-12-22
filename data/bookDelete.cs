using Appbooks.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appbooks.data
{
    public static class BookDelete
    {
        public static void deleteBookbyId(int bookid)
        {
            try
            {
                string connectionString = DataAccessAdo.getConnectionString();

                StoredProcedureCollection spCollection = new();

                StoredProcedure storedProcedureDelete = new() { StoredProcedureName = "spBooksDelete" };
                storedProcedureDelete.SetParam("bookId", System.Data.SqlDbType.Int, bookid.ToString());

                spCollection.Add(storedProcedureDelete);

                StoredProcedure.ExecuteSps(spCollection, connectionString);
            }
            catch (Exception ex)
            {
                Console.Write("Exception: " + ex.ToString());
            }
        }
    }
}