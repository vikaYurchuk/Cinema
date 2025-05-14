using Cinema.Extensions;
using Cinema.Interfaces;
using Cinema.Data;
using Cinema.Entities;

namespace Cinema;

public class FavouritesServiceLocal : IFavoriteService
{
    private readonly ISession _session;
    private readonly CinemaDbContext _context;
    private const string key = "favourite_list";

    public FavouritesServiceLocal(IHttpContextAccessor accessor, CinemaDbContext context)
    {
        this._session = accessor.HttpContext.Session;
        _context = context;
    }

    public List<int> GetIds()
    {
        return _session.Get<List<int>>(key) ?? new();
    }
    public List<Film> GetAll()
    {
        var ids = GetIds();
        return _context.FilmTeams4.Where(x => ids.Contains(x.Id)).ToList();
    }

    public void Add(int id)
    {
        var ids = GetIds();

        if (ids.Contains(id)) return;

        ids.Add(id);
        _session.Set(key, ids);
    }

    public void Remove(int id)
    {
        var ids = GetIds();
        ids.Remove(id);
        _session.Set(key, ids);
    }

    public void Clear()
    {
        _session.Remove(key);
    }

    public int GetCount()
    {
        return GetIds().Count;
    }

    List<Film> IFavoriteService.GetAll()
    {
        throw new NotImplementedException();
    }
}