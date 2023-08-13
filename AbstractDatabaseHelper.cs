using MySql.Data.MySqlClient;
using SoundSculptMaui;
using System;
using System.Collections.Generic;
using System.Data;

namespace SoundSculptMaui
{
    // Abstract class providing common database functionality
    public abstract class AbstractDatabaseHelper : IDatabaseHelper
    {
        public string connectionString = "server=localhost;user=root;database=events;password=";

        // Method to retrieve a list of all available genres from the database
        public List<string> GetGenres()
        {
            List<string> genres = new List<string>();

            try
            {
                // Create a database connection
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Open the connection

                    string query = "SELECT DISTINCT genre FROM concert"; // SQL query

                    // Execute the query and read results using a reader
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(reader.GetString("genre")); // Add genres to the list
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here (e.g., log the error, display a message)
                Console.WriteLine($"Exception in GetGenres: {ex.Message}");
            }

            return genres; // Return the list of genres
        }
    }
}
