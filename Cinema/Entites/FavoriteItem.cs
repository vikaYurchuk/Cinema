namespace Cinema.Entities
{
    public class FavoriteItem
    {
        public string UserId { get; set; }
        public Film? User { get; set; }
        public int FilmId { get; set; }
        public Film? Film { get; set; }
    }
}
