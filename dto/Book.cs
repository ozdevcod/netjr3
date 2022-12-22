namespace Appbooks.dto
{
    public class Book
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Author { get; set; }

        public int Pages { get; set; }

        public string? Genre { get; set; }

        public string? Year { get; set; }

        public DateTime CreationDate { get; set; }

    }
}