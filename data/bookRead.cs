using Appbooks.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appbooks.data
{
    public static class BookRead
    {
        public static List<Book> getBooksbyId(int? bookid)
        {
            List<Book> BooksList = new List<Book>();

            string connectionString = DataAccessAdo.getConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string storedProcedure = "spBooksRead";

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter sqlParameterBookId = new SqlParameter()
                        {
                            ParameterName = "@bookId",
                            Value = bookid
                        };

                        cmd.Parameters.Add(sqlParameterBookId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book();

                                book.Id = reader.GetInt32(0);
                                book.Name = reader.GetString(1);
                                book.Author = reader.GetString(2);
                                book.Pages = reader.GetInt16(3);
                                book.Genre = reader.GetString(4);
                                book.Year = reader.GetString(5);
                                BooksList.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception: " + e.ToString());
            }
            return BooksList;
        }
    }
}