﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMDb.API.Migrations
{
    /// <inheritdoc />
    public partial class AzureDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0a3b8d64-3237-4dd2-ad2b-a6875c8c93dc"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("17c708d7-96c7-4ed0-a562-c43a537d2227"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1e4c3b0e-97f1-48d6-81e6-ba07f9cf415f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("26b3acfc-ae89-4680-941d-bb88866e02fb"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4594c86e-282b-453b-8b10-e09da8afc2c3"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("530cf2e6-9d6c-4459-b0c7-f3ecd1e9833c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("57023c5d-bd4d-4d6b-abca-9e8db7004752"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("57457f24-a2f8-4061-b29f-6595dca3f928"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("80c5bed1-e2d0-4175-9042-036789aec4b1"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8a3a395a-6093-40e9-a057-059390a0e134"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9621ab73-afbb-459e-aa53-2e4f6b4e38c7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("969370e9-ebf5-4c4f-9ef0-c57af64ae8bb"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a9822dac-74d7-413f-97d9-44b185db6754"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("aededa8d-5536-435b-92c0-6b77d0c8581f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b3575a58-02bf-4a57-bb09-76e95066b6ac"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("cc0a13a9-4952-4cc6-9788-da05f0b111d4"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ImdbId", "Plot", "Poster", "Title", "Trailer", "Year" },
                values: new object[,]
                {
                    { new Guid("07716b7a-0c6c-47d4-8ed1-e7f964c9b94a"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0316654", "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.", "https://m.media-amazon.com/images/M/MV5BMzY2ODk4NmUtOTVmNi00ZTdkLTlmOWYtMmE2OWVhNTU2OTVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", "Spider Man 2", null, "2004" },
                    { new Guid("25c66f55-7060-4979-ba2d-50c9c9d842f0"), "Steven Spielberg", "Biography, Drama, History", "tt0108052", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "Schindler's List", null, "1993" },
                    { new Guid("319b398a-ee37-4053-91bd-cd9cb9a84f23"), "Christopher Nolan", "Action, Crime, Drama", "tt0468569", "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg", "The Dark Knight", null, "2008" },
                    { new Guid("34b4b113-a8d3-4595-b1aa-13b520bc9da2"), "David Fincher", "Drama", "tt0137523", "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Fight Club", null, "1999" },
                    { new Guid("6d9ee6ee-a5d9-4b20-8f60-680df551885f"), "Quentin Tarantino", "Crime, Drama", "tt0110912", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Pulp Fiction", null, "1994" },
                    { new Guid("6f44aba9-d495-4ed2-86b8-818dea323117"), "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "tt0133093", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "The Matrix", null, "1999" },
                    { new Guid("7709903a-eecc-474c-b560-735916c74f87"), "Francis Ford Coppola", "Crime, Drama", "tt0068646", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather", null, "1972" },
                    { new Guid("9abc0227-7517-45ce-a3ae-b9dfc7cd9514"), "David Fincher", "Biography, Drama", "tt1285016", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg", "The Social Network", null, "2010" },
                    { new Guid("a9475b32-b711-4479-a411-aa4009f0d98c"), "Christopher Nolan", "Action, Adventure", "tt1345836", "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.", "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg", "The Dark Knight Rises", null, "2012" },
                    { new Guid("b48f7e52-1a9b-46fc-9ce6-f9d8cae81040"), "Francis Ford Coppola", "Crime, Drama", "tt0071562", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather: Part II", null, "1974" },
                    { new Guid("b8a53065-9e0a-4b4e-9ab9-90df2ccc70ea"), "Joseph Kosinski", "Action, Adventure, Sci-Fi", "tt1104001", "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.", "https://m.media-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_SX300.jpg", "Tron: Legacy", null, "2010" },
                    { new Guid("bc0f11a5-349d-4a3e-be73-630d506844b4"), "Martin Scorsese", "Biography, Crime, Drama", "tt0099685", "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Goodfellas", null, "1990" },
                    { new Guid("bf14aa88-5817-41ee-b01f-e2f2d94e7d78"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0413300", "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.", "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg", "Spider Man 3", null, "2007" },
                    { new Guid("e34e8b1a-71dc-491f-9cad-a66e7ffab252"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0145487", "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.", "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg", "Spider Man", null, "2002" },
                    { new Guid("e90d7aa0-0adf-4116-becb-abc93ac5b19f"), "Frank Darabont", "Drama", "tt0111161", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg", "The Shawshank Redemption", "https://bmdb.blob.core.windows.net/test/videoplayback.mp4", "1994" },
                    { new Guid("f8407d10-5db6-4003-a38e-5b149b6fe094"), "Steven Lisberger", "Action, Adventure, Sci-Fi", "tt0084827", "A computer hacker is abducted into the digital world and forced to participate in gladiatorial games where his only chance of escape is with the help of a heroic security program.", "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_SX300.jpg", "Tron", null, "1982" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("07716b7a-0c6c-47d4-8ed1-e7f964c9b94a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("25c66f55-7060-4979-ba2d-50c9c9d842f0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("319b398a-ee37-4053-91bd-cd9cb9a84f23"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("34b4b113-a8d3-4595-b1aa-13b520bc9da2"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("6d9ee6ee-a5d9-4b20-8f60-680df551885f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("6f44aba9-d495-4ed2-86b8-818dea323117"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7709903a-eecc-474c-b560-735916c74f87"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9abc0227-7517-45ce-a3ae-b9dfc7cd9514"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a9475b32-b711-4479-a411-aa4009f0d98c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b48f7e52-1a9b-46fc-9ce6-f9d8cae81040"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b8a53065-9e0a-4b4e-9ab9-90df2ccc70ea"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bc0f11a5-349d-4a3e-be73-630d506844b4"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bf14aa88-5817-41ee-b01f-e2f2d94e7d78"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e34e8b1a-71dc-491f-9cad-a66e7ffab252"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e90d7aa0-0adf-4116-becb-abc93ac5b19f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f8407d10-5db6-4003-a38e-5b149b6fe094"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ImdbId", "Plot", "Poster", "Title", "Trailer", "Year" },
                values: new object[,]
                {
                    { new Guid("0a3b8d64-3237-4dd2-ad2b-a6875c8c93dc"), "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "tt0133093", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "The Matrix", null, "1999" },
                    { new Guid("17c708d7-96c7-4ed0-a562-c43a537d2227"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0145487", "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.", "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg", "Spider Man", null, "2002" },
                    { new Guid("1e4c3b0e-97f1-48d6-81e6-ba07f9cf415f"), "Steven Spielberg", "Biography, Drama, History", "tt0108052", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "Schindler's List", null, "1993" },
                    { new Guid("26b3acfc-ae89-4680-941d-bb88866e02fb"), "Francis Ford Coppola", "Crime, Drama", "tt0071562", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather: Part II", null, "1974" },
                    { new Guid("4594c86e-282b-453b-8b10-e09da8afc2c3"), "Martin Scorsese", "Biography, Crime, Drama", "tt0099685", "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Goodfellas", null, "1990" },
                    { new Guid("530cf2e6-9d6c-4459-b0c7-f3ecd1e9833c"), "David Fincher", "Drama", "tt0137523", "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Fight Club", null, "1999" },
                    { new Guid("57023c5d-bd4d-4d6b-abca-9e8db7004752"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0413300", "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.", "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg", "Spider Man 3", null, "2007" },
                    { new Guid("57457f24-a2f8-4061-b29f-6595dca3f928"), "Christopher Nolan", "Action, Crime, Drama", "tt0468569", "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg", "The Dark Knight", null, "2008" },
                    { new Guid("80c5bed1-e2d0-4175-9042-036789aec4b1"), "Steven Lisberger", "Action, Adventure, Sci-Fi", "tt0084827", "A computer hacker is abducted into the digital world and forced to participate in gladiatorial games where his only chance of escape is with the help of a heroic security program.", "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_SX300.jpg", "Tron", null, "1982" },
                    { new Guid("8a3a395a-6093-40e9-a057-059390a0e134"), "Quentin Tarantino", "Crime, Drama", "tt0110912", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Pulp Fiction", null, "1994" },
                    { new Guid("9621ab73-afbb-459e-aa53-2e4f6b4e38c7"), "Frank Darabont", "Drama", "tt0111161", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg", "The Shawshank Redemption", "https://bmdb.blob.core.windows.net/test/videoplayback.mp4", "1994" },
                    { new Guid("969370e9-ebf5-4c4f-9ef0-c57af64ae8bb"), "David Fincher", "Biography, Drama", "tt1285016", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg", "The Social Network", null, "2010" },
                    { new Guid("a9822dac-74d7-413f-97d9-44b185db6754"), "Joseph Kosinski", "Action, Adventure, Sci-Fi", "tt1104001", "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.", "https://m.media-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_SX300.jpg", "Tron: Legacy", null, "2010" },
                    { new Guid("aededa8d-5536-435b-92c0-6b77d0c8581f"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0316654", "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.", "https://m.media-amazon.com/images/M/MV5BMzY2ODk4NmUtOTVmNi00ZTdkLTlmOWYtMmE2OWVhNTU2OTVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", "Spider Man 2", null, "2004" },
                    { new Guid("b3575a58-02bf-4a57-bb09-76e95066b6ac"), "Francis Ford Coppola", "Crime, Drama", "tt0068646", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather", null, "1972" },
                    { new Guid("cc0a13a9-4952-4cc6-9788-da05f0b111d4"), "Christopher Nolan", "Action, Adventure", "tt1345836", "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.", "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg", "The Dark Knight Rises", null, "2012" }
                });
        }
    }
}
