﻿// <auto-generated />
using System;
using BMDb.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BMDb.API.Migrations.Movie
{
    [DbContext(typeof(MovieContext))]
    [Migration("20231122110629_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BMDb.API.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plot")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("07600a9e-be26-4c7b-b5f4-bb2759cbe032"),
                            Director = "Frank Darabont",
                            Genre = "Drama",
                            ImdbId = "tt0111161",
                            Plot = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg",
                            Title = "The Shawshank Redemption",
                            Year = "1994"
                        },
                        new
                        {
                            Id = new Guid("a506a4c3-9413-44b1-9e5b-9f9120dc7b49"),
                            Director = "Francis Ford Coppola",
                            Genre = "Crime, Drama",
                            ImdbId = "tt0068646",
                            Plot = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                            Title = "The Godfather",
                            Year = "1972"
                        },
                        new
                        {
                            Id = new Guid("126e0de9-9f65-473f-9720-2d25a2818bf6"),
                            Director = "Christopher Nolan",
                            Genre = "Action, Crime, Drama",
                            ImdbId = "tt0468569",
                            Plot = "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg",
                            Title = "The Dark Knight",
                            Year = "2008"
                        },
                        new
                        {
                            Id = new Guid("515db871-0fc0-4715-9f2f-4d43116e0c45"),
                            Director = "Christopher Nolan",
                            Genre = "Action, Adventure",
                            ImdbId = "tt1345836",
                            Plot = "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg",
                            Title = "The Dark Knight Rises",
                            Year = "2012"
                        },
                        new
                        {
                            Id = new Guid("5f51426b-510b-4f71-b368-b18e5ef79381"),
                            Director = "Francis Ford Coppola",
                            Genre = "Crime, Drama",
                            ImdbId = "tt0071562",
                            Plot = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                            Title = "The Godfather: Part II",
                            Year = "1974"
                        },
                        new
                        {
                            Id = new Guid("a16e0a92-6b7b-41a5-91cd-afd612714832"),
                            Director = "Quentin Tarantino",
                            Genre = "Crime, Drama",
                            ImdbId = "tt0110912",
                            Plot = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                            Title = "Pulp Fiction",
                            Year = "1994"
                        },
                        new
                        {
                            Id = new Guid("91db7322-3f0d-4ba3-9691-c11aab05757a"),
                            Director = "Steven Spielberg",
                            Genre = "Biography, Drama, History",
                            ImdbId = "tt0108052",
                            Plot = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
                            Title = "Schindler's List",
                            Year = "1993"
                        },
                        new
                        {
                            Id = new Guid("2a7c0fef-6cd3-4810-9346-5b3745d0df32"),
                            Director = "David Fincher",
                            Genre = "Drama",
                            ImdbId = "tt0137523",
                            Plot = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                            Title = "Fight Club",
                            Year = "1999"
                        },
                        new
                        {
                            Id = new Guid("4fdfb6f1-1e8c-4d02-8906-d85b1bcfa9ee"),
                            Director = "Lana Wachowski, Lilly Wachowski",
                            Genre = "Action, Sci-Fi",
                            ImdbId = "tt0133093",
                            Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
                            Title = "The Matrix",
                            Year = "1999"
                        },
                        new
                        {
                            Id = new Guid("45d8834b-92c3-4ea3-9283-e8320253bc84"),
                            Director = "Martin Scorsese",
                            Genre = "Biography, Crime, Drama",
                            ImdbId = "tt0099685",
                            Plot = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                            Title = "Goodfellas",
                            Year = "1990"
                        },
                        new
                        {
                            Id = new Guid("e3f704a5-1503-4785-aca1-a6c15ef68ce4"),
                            Director = "Sam Raimi",
                            Genre = "Action, Adventure, Sci-Fi",
                            ImdbId = "tt0145487",
                            Plot = "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg",
                            Title = "Spider Man",
                            Year = "2002"
                        },
                        new
                        {
                            Id = new Guid("6c175309-4c48-48a2-abaa-0874ff3a04d7"),
                            Director = "Sam Raimi",
                            Genre = "Action, Adventure, Sci-Fi",
                            ImdbId = "tt0316654",
                            Plot = "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BMzY2ODk4NmUtOTVmNi00ZTdkLTlmOWYtMmE2OWVhNTU2OTVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",
                            Title = "Spider Man 2",
                            Year = "2004"
                        },
                        new
                        {
                            Id = new Guid("6450e1f8-052c-4a5e-afba-5cf6479039bf"),
                            Director = "Sam Raimi",
                            Genre = "Action, Adventure, Sci-Fi",
                            ImdbId = "tt0413300",
                            Plot = "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg",
                            Title = "Spider Man 3",
                            Year = "2007"
                        },
                        new
                        {
                            Id = new Guid("e7665095-c2f2-4ed9-87eb-34eaf118c715"),
                            Director = "Steven Lisberger",
                            Genre = "Action, Adventure, Sci-Fi",
                            ImdbId = "tt0084827",
                            Plot = "A computer hacker is abducted into the digital world and forced to participate in gladiatorial games where his only chance of escape is with the help of a heroic security program.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_SX300.jpg",
                            Title = "Tron",
                            Year = "1982"
                        },
                        new
                        {
                            Id = new Guid("fb5f60dd-e086-4728-be0f-2e47476ac928"),
                            Director = "Joseph Kosinski",
                            Genre = "Action, Adventure, Sci-Fi",
                            ImdbId = "tt1104001",
                            Plot = "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_SX300.jpg",
                            Title = "Tron: Legacy",
                            Year = "2010"
                        },
                        new
                        {
                            Id = new Guid("f6f0ad30-be1f-4784-978b-a620709c4cb1"),
                            Director = "David Fincher",
                            Genre = "Biography, Drama",
                            ImdbId = "tt1285016",
                            Plot = "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.",
                            Poster = "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg",
                            Title = "The Social Network",
                            Year = "2010"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
