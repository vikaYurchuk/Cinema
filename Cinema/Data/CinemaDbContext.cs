using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using Cinema.Entities;
using Microsoft.AspNetCore.Identity;
using static System.Net.WebRequestMethods;


namespace Cinema.Data;

public class CinemaDbContext : IdentityDbContext<User>
{
    public DbSet<Film> FilmTeams4 { get; set; }
    public DbSet<Actor> CinemaActors4 { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public CinemaDbContext() { }
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
    {
        //this.Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            var str = "workstation id=cinemadata.mssql.somee.com;packet size=4096;user id=vika453_SQLLogin_1;pwd=eiswy8cn41;data source=cinemadata.mssql.somee.com;persist security info=False;initial catalog=cinemadata;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(str);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(x => new { x.LoginProvider, x.ProviderKey });

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(x => new { x.UserId, x.RoleId });

        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        modelBuilder.Entity<Session>()
        .Property(s => s.Price)
        .HasPrecision(10, 2);



        modelBuilder.Entity<Film>().HasData(
            new Film
            {
                Id = 1,
                Name = "The Shawshank Redemption",
                Cover= "https://www.musiconvinyl.com/cdn/shop/files/MOVATM091_Sleeve.webp?v=1713507987&width=1445",
                Year = 1994,
                Genre = "Drama",
                Duration = 142,

            },
            new Film
            {
                Id = 2,
                Name = "The Godfather",
                Cover = "https://www.northjersey.com/gcdn/presto/2022/03/22/PNJM/0d896a12-005e-4d8f-b29f-19595efd5c6f-The_Godfather_50th.jpg?width=600&height=904&fit=crop&format=pjpg&auto=webp",
                Year = 1972,
                Genre = "Crime, Drama",
                Duration = 175
            },
            new Film
            {
                Id = 3,
                Name = "The Dark Knight",
                Cover= "https://m.media-amazon.com/images/S/pv-target-images/e9a43e647b2ca70e75a3c0af046c4dfdcd712380889779cbdc2c57d94ab63902.jpg",
                Year = 2008,
                Genre = "Action, Crime, Drama",
                Duration = 152
            },
            new Film
            {
                Id = 4,
                Name = "Forrest Gump",
                Cover= "https://upload.wikimedia.org/wikipedia/ru/d/de/%D0%A4%D0%BE%D1%80%D1%80%D0%B5%D1%81%D1%82_%D0%93%D0%B0%D0%BC%D0%BF.jpg",
                Year = 1994,
                Genre = "Drama, Romance",
                Duration = 142
            },
            new Film
            {
                Id = 5,
                Name = "Inception",
                Cover= "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg",
                Year = 2010,
                Genre = "Action, Adventure, Sci-Fi",
                Duration = 148
            },
            new Film
            {
                Id = 6,
                Name = "The Matrix",
                Cover= "https://i.scdn.co/image/ab67616d0000b273cb10bbc00c7732aec1b81fb2",
                Year = 1999,
                Genre = "Action, Sci-Fi",
                Duration = 136
            },
            new Film
            {
                Id = 7,
                Name = "The Empire Strikes Back",
                Cover= "https://upload.wikimedia.org/wikipedia/en/3/3f/The_Empire_Strikes_Back_%281980_film%29.jpg",
                Year = 1980,
                Genre = "Action, Adventure, Fantasy",
                Duration = 124
            },
            new Film
            {
                Id = 8,
                Name = "Pulp Fiction",
                Cover = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg",
                Year = 1994,
                Genre = "Crime, Drama",
                Duration = 154
            },
             new Film {
                 Id = 9,
                 Name = "Titanic",
                 Year = 1997,
                 Genre = "Drama, Romance",
                 Duration = 195,
                 Cover = "https://upload.wikimedia.org/wikipedia/en/1/18/Titanic_%281997_film%29_poster.png"
             },
              new Film
              { Id = 10, 
                  Name = "Avatar",
                  Year = 2009,
                  Genre = "Sci-Fi, Adventure",
                  Duration = 162,
                  Cover = "https://lumiere-a.akamaihd.net/v1/images/avatar_800x1200_208c9665.jpeg?region=0%2C0%2C800%2C1200"
              },
                new Film
                { Id = 11,
                    Name = "Joker",
                    Year = 2019,
                    Genre = "Drama, Thriller",
                    Duration = 122,
                    Cover = "https://m.media-amazon.com/images/M/MV5BNzY3OWQ5NDktNWQ2OC00ZjdlLThkMmItMDhhNDk3NTFiZGU4XkEyXkFqcGc@._V1_.jpg"
                },
                new Film
                { Id = 12,
                    Name = "Avengers: Endgame",
                    Year = 2019,
                    Genre = "Action, Sci-Fi",
                    Duration = 181,
                    Cover = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg"
                }

        );
        modelBuilder.Entity<Film>().ToTable("FilmTeams4");
        modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    FilmId = 1,
                    StartTime = new DateTime(2025, 5, 10, 19, 0, 0),
                    Hall = "Main Hall",
                    Price = 150.00m
                },
                new Session
                {
                    Id = 2,
                    FilmId = 7,
                    StartTime = new DateTime(2025, 5, 11, 21, 30, 0),
                    Hall = "VIP Hall",
                    Price = 200.00m
                },
                new Session
                {
                    Id = 3,
                    FilmId = 8,
                    StartTime = new DateTime(2025, 5, 12, 17, 0, 0),
                    Hall = "Hall 2",
                    Price = 140.00m
                },
                new Session
                {
                    Id = 4,
                    FilmId = 9,
                    StartTime = new DateTime(2025, 5, 12, 20, 0, 0),
                    Hall = "Hall 3",
                    Price = 180.00m
                },
                new Session
                {
                    Id = 5,
                    FilmId = 10,
                    StartTime = new DateTime(2025, 5, 13, 18, 30, 0),
                    Hall = "IMAX",
                    Price = 220.00m
                },
                new Session
                {
                    Id = 6,
                    FilmId = 11,
                    StartTime = new DateTime(2025, 5, 13, 21, 0, 0),
                    Hall = "Hall 1",
                    Price = 160.00m
                },
                new Session
                {
                    Id = 7,
                    FilmId = 12,
                    StartTime = new DateTime(2025, 5, 14, 16, 45, 0),
                    Hall = "Main Hall",
                    Price = 210.00m
                },
                new Session
                {
                    Id = 8,
                    FilmId = 1,
                    StartTime = new DateTime(2025, 5, 15, 19, 15, 0),
                    Hall = "VIP Hall",
                    Price = 170.00m
                }
            );


        modelBuilder.Entity<Actor>().HasData(
           new Actor { Id = 1, FirstName = "Tim", LastName = "Robbins", FilmId = 1 },
           new Actor { Id = 2, FirstName = "Morgan", LastName = "Freeman", FilmId = 1 },
           new Actor { Id = 3, FirstName = "Marlon", LastName = "Brando", FilmId = 2 },
           new Actor { Id = 4, FirstName = "Al", LastName = "Pacino", FilmId = 2 },
           new Actor { Id = 5, FirstName = "Christian", LastName = "Bale", FilmId = 3 },
           new Actor { Id = 6, FirstName = "Heath", LastName = "Ledger", FilmId = 3 },
           new Actor { Id = 7, FirstName = "Tom", LastName = "Hanks", FilmId = 4 },
           new Actor { Id = 8, FirstName = "Robin", LastName = "Wright", FilmId = 4 },
           new Actor { Id = 9, FirstName = "Leonardo", LastName = "DiCaprio", FilmId = 5 },
           new Actor { Id = 10, FirstName = "Joseph", LastName = "Gordon-Levitt", FilmId = 5 },
           new Actor { Id = 11, FirstName = "Keanu", LastName = "Reeves", FilmId = 6 },
           new Actor { Id = 12, FirstName = "Laurence", LastName = "Fishburne", FilmId = 6 },
           new Actor { Id = 13, FirstName = "Harrison", LastName = "Ford", FilmId = 7 },
           new Actor { Id = 14, FirstName = "Mark", LastName = "Hamill", FilmId = 7 },
            new Actor { Id =15, FirstName = "Markus", LastName = "Hamillian", FilmId = 7 }

        );

    }
}