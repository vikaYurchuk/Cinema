using Cinema.Entities;
using Cinema.Models;

namespace Cinema.Interfaces;

public interface IFavoriteService
{
    List<int> GetIds();
    List<Film> GetAll();
    void Add(int id);
    void Remove(int id);
    void Clear();
    int GetCount();
}