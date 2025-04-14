namespace BMDb.Infrastructure.Data;

public static class InitData
{
    public static IReadOnlyList<Movie> Movies
        => new List<Movie>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Shawshank Redemption",
                Year = "1994",
                Director = "Frank Darabont",
                Genre = "Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg",
                Trailer = "https://bmdb.blob.core.windows.net/test/videoplayback.mp4",
                Plot =
                    "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                ImdbId = "tt0111161"
            },

            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Godfather",
                Year = "1972",
                Director = "Francis Ford Coppola",
                Genre = "Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                Plot =
                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                ImdbId = "tt0068646"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Dark Knight",
                Year = "2008",
                Director = "Christopher Nolan",
                Genre = "Action, Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg",
                Plot =
                    "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.",
                ImdbId = "tt0468569"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Dark Knight Rises",
                Year = "2012",
                Director = "Christopher Nolan",
                Genre = "Action, Adventure",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg",
                Plot =
                    "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.",
                ImdbId = "tt1345836"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Godfather: Part II",
                Year = "1974",
                Director = "Francis Ford Coppola",
                Genre = "Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                Plot =
                    "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                ImdbId = "tt0071562"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pulp Fiction",
                Year = "1994",
                Director = "Quentin Tarantino",
                Genre = "Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                Plot =
                    "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                ImdbId = "tt0110912"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Schindler's List",
                Year = "1993",
                Director = "Steven Spielberg",
                Genre = "Biography, Drama, History",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
                Plot =
                    "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                ImdbId = "tt0108052"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Fight Club",
                Year = "1999",
                Director = "David Fincher",
                Genre = "Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                Plot =
                    "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                ImdbId = "tt0137523"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Matrix",
                Year = "1999",
                Director = "Lana Wachowski, Lilly Wachowski",
                Genre = "Action, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
                Plot =
                    "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                ImdbId = "tt0133093"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Goodfellas",
                Year = "1990",
                Director = "Martin Scorsese",
                Genre = "Biography, Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                Plot =
                    "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
                ImdbId = "tt0099685"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Spider Man",
                Year = "2002",
                Director = "Sam Raimi",
                Genre = "Action, Adventure, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg",
                Plot =
                    "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.",
                ImdbId = "tt0145487"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Spider Man 2",
                Year = "2004",
                Director = "Sam Raimi",
                Genre = "Action, Adventure, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMzY2ODk4NmUtOTVmNi00ZTdkLTlmOWYtMmE2OWVhNTU2OTVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",
                Plot =
                    "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.",
                ImdbId = "tt0316654"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Spider Man 3",
                Year = "2007",
                Director = "Sam Raimi",
                Genre = "Action, Adventure, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg",
                Plot =
                    "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.",
                ImdbId = "tt0413300"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tron",
                Year = "1982",
                Director = "Steven Lisberger",
                Genre = "Action, Adventure, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_SX300.jpg",
                Plot =
                    "A computer hacker is abducted into the digital world and forced to participate in gladiatorial games where his only chance of escape is with the help of a heroic security program.",
                ImdbId = "tt0084827"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tron: Legacy",
                Year = "2010",
                Director = "Joseph Kosinski",
                Genre = "Action, Adventure, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_SX300.jpg",
                Plot =
                    "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.",
                ImdbId = "tt1104001"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Social Network",
                Year = "2010",
                Director = "David Fincher",
                Genre = "Biography, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg",
                Plot =
                    "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.",
                ImdbId = "tt1285016"
            }
        };
}