using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetSakila
{
    internal class ActorRepository
    {
        private readonly DatabaseService _databaseService;

        public ActorRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<string> GetAllFilmsByActor(string firstName, string lastName)
        {
            string query = @"
                    SELECT 
                    actor.first_name, 
                    actor.last_name, 
                    film.title
                FROM film
                INNER JOIN film_actor ON film.film_id = film_actor.film_id
                INNER JOIN actor ON film_actor.actor_id = actor.actor_id
                WHERE actor.first_name = @FirstName or actor.last_name = @LastName";

            SqlParameter[] parameters = new[] {
                new SqlParameter("@Firstname", firstName),
                new SqlParameter("@LastName", lastName)
            };

            var actors = new List<string>();

            using (var reader = _databaseService.ExecuteQuery(query, parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        actors.Add($"{reader["first_name"]} {reader["last_name"]} {reader["title"]}");
                    }
                }
            }

            return actors;
        }

    }
}
