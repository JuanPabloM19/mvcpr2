using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Titulo = "When Harry Met Sally",
                    Fechadelanzamiento = DateTime.Parse("1989-2-12"),
                    Genero = "Romantic Comedy",
                    Precio = 7.99M
                },
                new Movie
                {
                    Titulo = "Ghostbusters ",
                    Fechadelanzamiento = DateTime.Parse("1984-3-13"),
                    Genero = "Comedy",
                    Precio = 8.99M
                },
                new Movie
                {
                    Titulo = "Ghostbusters 2",
                    Fechadelanzamiento = DateTime.Parse("1986-2-23"),
                    Genero = "Comedy",
                    Precio = 9.99M
                },
                new Movie
                {
                    Titulo = "Rio Bravo",
                    Fechadelanzamiento = DateTime.Parse("1959-4-15"),
                    Genero = "Western",
                    Precio = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}