using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieAPI.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMovies(string searchString, string movieGenre)
        {
            // Instantiate the output object that we want to return through this method
            List<Movie> output = new List<Movie>();

            // Create and enclose our SQL connection in a using statement
            using (var DBCon = new SqlConnection(SQLHelper.ConnectionString))
            {
                // Open the connection to the database
                DBCon.Open();

                // Create our query to the database - this has not been executed yet
                // This query selects all from our movie table in our database
                var movieQuery = new SqlCommand("SELECT * FROM dbo.Movie", DBCon);

                // Create a SqlDataReader to execute and read the results from our movieQuery
                using (SqlDataReader reader = movieQuery.ExecuteReader())
                {
                    // While the reader has rows to read
                    // Each loop of the while condition is a different row in the response
                    while (reader.Read())
                    {
                        // Add a new Movie object to the list of movies defined in our variable: output
                        output.Add(new Movie
                        {
                            ID = (int)reader["ID"],
                            Title = (string)reader["Title"],
                            Genre = (string)reader["Genre"],
                            Price = (decimal)reader["Price"],
                            ReleaseDate = (DateTime)reader["ReleaseDate"],
                            Rating = (string)reader["Rating"]
                        });
                    }
                }

                // IMPORTANT - Close the connection to the database once all of your queries have completed
                DBCon.Close();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                output = output.Where(s => s.Title.Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                output = output.Where(m => m.Genre == movieGenre).ToList();
            }

            return Ok(output);
        }


        [HttpGet]
        public IHttpActionResult GetGenres()
        {
            List<string> output = new List<string>();

            using (var DBCon = new SqlConnection(SQLHelper.ConnectionString))
            {
                DBCon.Open();
                // Create another query to the database - the query has not been executed yet
                // This query selects the distinct (no duplicate) genres from our Movie table and orders them alphabetically
                var genreQuery = new SqlCommand("SELECT DISTINCT Genre FROM dbo.Movie ORDER BY Genre", DBCon);

                // Create a SqlDataReader to execute and read the results from our genreQuery
                using (SqlDataReader reader = genreQuery.ExecuteReader())
                {
                    // While the reader has rows to read
                    // Each loop of the while condition is a different row in the response
                    while (reader.Read())
                    {
                        // Add each distinct genre to our list of genres
                        output.Add((string)reader["Genre"]);
                    }
                }
                DBCon.Close();
            }

            return Ok(output);
        }



        [HttpGet]
        public IHttpActionResult GetDetails(int ID)
        {
            // With this method, we want to output a single movie
            Movie output = new Movie();

            // Create and enclose our SQL connection in a using statement
            using (var DBCon = new SqlConnection(SQLHelper.ConnectionString))
            {
                // Open the connection to the database
                DBCon.Open();

                // Create a query to the database - the query has not been executed yet - @ID has not been assigned a real value
                // This query selects all columns from the Movie table where the ID is equal to whatever ID is passed in to the method
                var query = new SqlCommand("SELECT * FROM dbo.Movie WHERE ID=@Id", DBCon);

                // Give @ID our value that was passed into the method from the user
                // Parameterized queries help prevent malicious SQL Injection
                query.Parameters.Add("@Id", SqlDbType.Int).Value = ID;

                // Create a SqlDataReader to execute and read the results from our query
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    // Ensure that our query returns rows
                    if (reader.HasRows == true)
                    {
                        // Read the query response and assign it to our output
                        reader.Read();
                        output.ID = (int)reader["ID"];
                        output.Title = (string)reader["Title"];
                        output.Genre = (string)reader["Genre"];
                        output.Price = (decimal)reader["Price"];
                        output.ReleaseDate = (DateTime)reader["ReleaseDate"];
                        output.Rating = (string)reader["Rating"];
                        DBCon.Close();
                        return Ok(output);
                    }
                    else
                    {
                        DBCon.Close();
                        return BadRequest("No movie found matching ID");
                    }
                }
            }
        }





        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (movie != null)
            {
                // Create and enclose our SQL connection in a using statement
                using (var DBCon = new SqlConnection(SQLHelper.ConnectionString))
                {
                    // Open the connection to the database
                    DBCon.Open();

                    // Create query to the database - this query has not been executed yet - values with @ have not been assgned yet either
                    var query = new SqlCommand("INSERT INTO dbo.Movie (Genre, Price, ReleaseDate, Title, Rating) VALUES (@Genre, @Price, @ReleaseDate, @Title, @Rating)", DBCon);

                    // Assign values to our parameters marked with @ in our query
                    // Parameterized queries are helpful for preventing malicious SQL Injection
                    query.Parameters.Add("@Genre", SqlDbType.VarChar).Value = movie.Genre;
                    query.Parameters.Add("@Price", SqlDbType.Decimal).Value = movie.Price;
                    query.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = movie.ReleaseDate;
                    query.Parameters.Add("@Title", SqlDbType.VarChar).Value = movie.Title;
                    query.Parameters.Add("@Rating", SqlDbType.VarChar).Value = movie.Rating;

                    // Execute the query and get the number of rows that were affected
                    var numRows = query.ExecuteNonQuery();

                    // Close the connection
                    DBCon.Close();

                    // If no rows were affected, the create failed
                    if (numRows == 0)
                    {
                        return BadRequest("Unable to create movie");
                    }
                    else
                    {
                        return Ok("Movie created successfully");
                    }
                }
            }
            else
            {
                return BadRequest("Unable to create movie. Input must not be null!");
            }
        }





        [HttpDelete]
        public IHttpActionResult DeleteMovie(int ID)
        {
            // Create and enclose our SQL connection in a using statement
            using (var DBCon = new SqlConnection(SQLHelper.ConnectionString))
            {
                // Open the connection to the database
                DBCon.Open();

                // Create query to the database - this query has not been executed yet - values with @ have not been assgned yet either
                var query = new SqlCommand("DELETE FROM dbo.Movie WHERE ID=@ID", DBCon);

                // Assign values to our parameters marked with @ in our query
                // Parameterized queries are helpful for preventing malicious SQL Injection
                query.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                // Execute the query and get the number of rows that were affected
                var numRows = query.ExecuteNonQuery();

                // Close the connection
                DBCon.Close();

                // If no rows were affected, the delete failed
                if (numRows == 0)
                {
                    return BadRequest("No movie to delete at ID");
                }
                else
                {
                    return Ok("Movie successfully deleted");
                }
            }
        }





        [HttpPut]
        public IHttpActionResult UpdateMovie(Movie movie)
        {
            if (movie != null)
            {
                // Create and enclose our SQL connection in a using statement
                using (var DBCon = new SqlConnection(SQLHelper.ConnectionString))
                {
                    // Open the connection to the database
                    DBCon.Open();
                    // Create query to the database - this query has not been executed yet - values with @ have not been assgned yet either
                    var query = new SqlCommand("UPDATE dbo.Movie SET Title=@Title, Genre=@Genre, Price=@Price, ReleaseDate=@ReleaseDate, Rating=@Rating WHERE ID=@ID", DBCon);

                    // Assign values to our parameters marked with @ in our query
                    // Parameterized queries are helpful for preventing malicious SQL Injection
                    query.Parameters.Add("@ID", SqlDbType.Int).Value = movie.ID;
                    query.Parameters.Add("@Title", SqlDbType.VarChar).Value = movie.Title;
                    query.Parameters.Add("@Genre", SqlDbType.VarChar).Value = movie.Genre;
                    query.Parameters.Add("@Price", SqlDbType.Decimal).Value = movie.Price;
                    query.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = movie.ReleaseDate;
                    query.Parameters.Add("@Rating", SqlDbType.VarChar).Value = movie.Rating;

                    // Execute the query and get the number of rows that were affected
                    var numRows = query.ExecuteNonQuery();

                    // Close the connection
                    DBCon.Close();


                    // If no rows were affected, the update failed
                    if (numRows == 0)
                    {
                        return BadRequest("Failed to update movie");
                    }
                    else
                    {
                        return Ok("Successfully updated movie");
                    }
                }
            }
            else
            {
                return BadRequest("Movie to update must not be null!");
            }
        }

    }
}
