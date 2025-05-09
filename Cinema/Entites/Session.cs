namespace Cinema.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public string Hall { get; set; } 
        public decimal Price { get; set; }
    }
}
