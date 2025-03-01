
namespace Cinema.Entities;

public class Film
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cover { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }   
    public int Duration { get; set; }
    public ICollection<Actor> Actors { get; set; }



}