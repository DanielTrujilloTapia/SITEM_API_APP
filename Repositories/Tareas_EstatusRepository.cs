using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Tareas_EstatusRepository: IEstatusRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Tareas_EstatusRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteEstatus(tareas_estatus tareas_Estatus)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM tareas_estatus WHERE id_estatus = @Id_estatus";

            var result = await db.ExecuteAsync(sql, new { Id_estatus = tareas_Estatus.Id_estatus });

            return result > 0;
        }

        public async Task<IEnumerable<tareas_estatus>> GetAllEstatus()
        {
            var db = dbConnection();

            var sql = @"SELECT id_estatus, nom_estatus, descripcion_estatus FROM tareas_estatus";

            return await db.QueryAsync<tareas_estatus>(sql, new { });
        }

        public async Task<tareas_estatus> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_estatus, nom_estatus, descripcion_estatus FROM tareas_estatus WHERE id_estatus = @Id_estatus";

            return await db.QueryFirstOrDefaultAsync<tareas_estatus>(sql, new { Id_estatus = id });

        }

        public async Task<bool> InsertEstatus(tareas_estatus tareas_Estatus)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO tareas_estatus(id_estatus, nom_estatus, descripcion_estatus) VALUES (@Id_estatus, @Nom_estatus, @Descripcion_estatus)";

            var result = await db.ExecuteAsync(sql, new
            { tareas_Estatus.Id_estatus, tareas_Estatus.Nom_estatus, tareas_Estatus.Descripcion_estatus});

            return result > 0;
        }

        public async Task<bool> UpdateEstatus(tareas_estatus tareas_Estatus)
        {
            var db = dbConnection();

            var sql = @"UPDATE tareas_estatus SET 
                    nom_estatus = @Nom_estatus, 
                    descripcion_estatus = @Descripcion_estatus
                    WHERE id_estatus = @Id_estatus";

            var result = await db.ExecuteAsync(sql, new
            {
                tareas_Estatus.Nom_estatus,
                tareas_Estatus.Descripcion_estatus,
                tareas_Estatus.Id_estatus
            });

            return result > 0;
        }
    }
}
