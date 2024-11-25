using Microsoft.Data.SqlClient;

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
                WITH ExactMatch AS (
                SELECT actor.first_name, actor.last_name, film.title
                FROM film
                    INNER JOIN film_actor ON film.film_id = film_actor.film_id
                    INNER JOIN actor ON film_actor.actor_id = actor.actor_id
                WHERE actor.first_name = @FirstName AND actor.last_name = @LastName
                ),
                Fallback AS (
                SELECT actor.first_name, actor.last_name, film.title
                FROM film
                    INNER JOIN film_actor ON film.film_id = film_actor.film_id
                    INNER JOIN actor ON film_actor.actor_id = actor.actor_id
                WHERE actor.first_name = @FirstName OR actor.last_name = @LastName)

                SELECT *
                FROM ExactMatch
                UNION ALL
                SELECT *
                FROM Fallback
                WHERE NOT EXISTS (SELECT 1 FROM ExactMatch)";

            SqlParameter[] parameters = new[] {
                new SqlParameter("@Firstname", firstName),
                new SqlParameter("@LastName", lastName)
            };

            var actorFilms = new List<string>();

            using (var reader = _databaseService.ExecuteQuery(query, parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        actorFilms.Add($"{reader["first_name"]} {reader["last_name"]} - {reader["title"]}");
                    }
                }
            }

            return actorFilms;
        }

    }
}
