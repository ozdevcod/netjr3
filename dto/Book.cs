namespace biblioteca.dto
{
    public class Book
    {
        public int id { get; set; }

        public string? name { get; set; }

        public string? author { get; set; }

        public int pages { get; set; }

        public string? genre { get; set; }

        public string? year { get; set; }

        public DateTime publicationDate { get; set; }

    }
}