using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCandle.Data;
using System;
using System.Linq;


namespace MvcCandle.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCandleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCandleContext>>()))
            {
                // Look for any movies.
                if (context.Candle.Any())
                {
                    return;   // DB has been seeded
                }

                context.Candle.AddRange(
                    new Candle
                    {
                        Fragrance = "Jasmine",
                        Color = "White",
                        Shape = "Round",
                        Size = 1099,
                        Price = 17.99M,
                        Rating = "Good",
                    },

                    new Candle
                    {
                        Fragrance = "Rose",
                        Color = "Pink",
                        Shape = "Round",
                        Size = 500,
                        Price = 27.99M,
                        Rating = "Avg",
                    },

                    new Candle
                    {
                        Fragrance = "Plumeria",
                        Color = "White",
                        Shape = "Triangle",
                        Size = 500,
                        Price = 90.99M,
                        Rating = "Good",
                    },

                    new Candle
                    {
                        Fragrance = "Parijat",
                        Color = "White",
                        Shape = "Rectangle",
                        Size = 900,
                        Price = 47.99M,
                        Rating = "Great",
                    },
                    new Candle
                    {
                        Fragrance = "Gardenia",
                        Color = "Yellow",
                        Shape = "Round",
                        Size = 900,
                        Price = 18.99M,
                        Rating = "Avg",
                    },
                    new Candle
                    {
                        Fragrance = "White Butterfly Gingers",
                        Color = "Grey",
                        Shape = "Triangle",
                        Size = 799,
                        Price = 7.99M,
                        Rating = "Great",
                    },
                    new Candle
                    {
                        Fragrance = "Tuberoses",
                        Color = "Green",
                        Shape = "Round",
                        Size = 800,
                        Price = 57.99M,
                        Rating = "Good",
                    },
                    new Candle
                    {
                        Fragrance = "Sandle Wood",
                        Color = "Yellow",
                        Shape = "Round",
                        Size = 800,
                        Price = 47.99M,
                        Rating = "Great",
                    },
                    new Candle
                    {
                        Fragrance = "Carnation",
                        Color = "Pink",
                        Shape = "Triangle",
                        Size = 900,
                        Price = 97.99M,
                        Rating = "Avg",
                    }, 
                    new Candle
                    {
                        Fragrance = "Corsican Mint",
                        Color = "Light Green",
                        Shape = "Rectangle",
                        Size = 800,
                        Price = 97.99M,
                        Rating = "Great",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
