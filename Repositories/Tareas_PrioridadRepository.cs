using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Tareas_PrioridadRepository: IPrioridadRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Tareas_PrioridadRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeletePrioridad(tareas_prioridad tareas_Prioridad)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM tareas_prioridad WHERE id_prioridad = @Id_prioridad";

            var result = await db.ExecuteAsync(sql, new { Id_prioridad = tareas_Prioridad.Id_prioridad });

            return result > 0;
        }

        public async Task<IEnumerable<tareas_prioridad>> GetAllPrioridad()
        {
            var db = dbConnection();

            var sql = @"SELECT id_prioridad, nom_prioridad, descripcion_prioridad FROM tareas_prioridad";

            return await db.QueryAsync<tareas_prioridad>(sql, new { });
        }

        public async Task<tareas_prioridad> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_prioridad, nom_prioridad, descripcion_prioridad FROM tareas_prioridad WHERE id_prioridad = @Id_prioridad";

            return await db.QueryFirstOrDefaultAsync<tareas_prioridad>(sql, new { Id_prioridad = id });

        }

        public async Task<bool> InsertPrioridad(tareas_prioridad tareas_Prioridad)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO tareas_prioridad(id_prioridad, nom_prioridad, descripcion_prioridad) VALUES (@Id_prioridad, @Nom_prioridad, @Descripcion_prioridad)";

            var result = await db.ExecuteAsync(sql, new
            { tareas_Prioridad.Id_prioridad, tareas_Prioridad.Nom_prioridad, tareas_Prioridad.Descripcion_prioridad });

            return result > 0;
        }

        public async Task<bool> UpdatePrioridad(tareas_prioridad tareas_Prioridad)
        {
            var db = dbConnection();

            var sql = @"UPDATE tareas_prioridad SET 
                    nom_prioridad = @Nom_prioridad, 
                    descripcion_prioridad = @Descripcion_prioridad
                    WHERE id_prioridad = @Id_prioridad";

            var result = await db.ExecuteAsync(sql, new
            {
                tareas_Prioridad.Nom_prioridad,
                tareas_Prioridad.Descripcion_prioridad,
                tareas_Prioridad.Id_prioridad
            });

            return result > 0;
        }
    }
}
