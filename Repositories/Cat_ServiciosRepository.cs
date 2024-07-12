using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Cat_ServiciosRepository: IServiciosRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Cat_ServiciosRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteServicios(cat_servicios cat_Servicios)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM cat_servicios WHERE id_servicio = @Id_servicio";

            var result = await db.ExecuteAsync(sql, new { Id_servicio = cat_Servicios.Id_servicio});

            return result > 0;
        }

        public async Task<IEnumerable<cat_servicios>> GetAllServicios()
        {
            var db = dbConnection();

            var sql = @"SELECT id_servicio, nom_servicio, descripcion_servicio FROM cat_servicios";

            return await db.QueryAsync<cat_servicios>(sql, new { });
        }

        public async Task<cat_servicios> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_servicio, nom_servicio, descripcion_servicio FROM cat_servicios WHERE id_servicio = @Id_servicio";

            return await db.QueryFirstOrDefaultAsync<cat_servicios>(sql, new { Id_servicio = id });

        }

        public async Task<bool> InsertServicios(cat_servicios cat_Servicios)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO cat_servicios(nom_servicio, descripcion_servicio) VALUES (@Nom_servicio, @Descripcion_servicio)";

            var result = await db.ExecuteAsync(sql, new
            { cat_Servicios.Nom_servicio, cat_Servicios.Descripcion_servicio});

            return result > 0;
        }

        public async Task<bool> UpdateServicios(cat_servicios cat_Servicios)
        {
            var db = dbConnection();

            var sql = @"UPDATE cat_servicios SET 
                    nom_servicio = @Nom_servicio, 
                    descripcion_servicio = @Descripcion_servicio
                    WHERE id_servicio = @Id_servicio";

            var result = await db.ExecuteAsync(sql, new
            {
                cat_Servicios.Nom_servicio,
                cat_Servicios.Descripcion_servicio,
                cat_Servicios.Id_servicio
            });

            return result > 0;
        }
    }
}
