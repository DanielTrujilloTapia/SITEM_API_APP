using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Cat_PlantasRepository: IPlantasRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Cat_PlantasRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeletePlantas(cat_plantas cat_Plantas)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM cat_plantas WHERE id_planta = @Id_planta";

            var result = await db.ExecuteAsync(sql, new { Id_planta = cat_Plantas.Id_planta });

            return result > 0;
        }

        public async Task<IEnumerable<cat_plantas>> GetAllPlantas()
        {
            var db = dbConnection();

            var sql = @"SELECT id_planta, nom_planta, descripcion_planta, ubicacion FROM cat_plantas";

            return await db.QueryAsync<cat_plantas>(sql, new { });
        }

        public async Task<cat_plantas> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_planta, nom_planta, descripcion_planta, ubicacion FROM cat_plantas WHERE id_planta = @Id_planta";

            return await db.QueryFirstOrDefaultAsync<cat_plantas>(sql, new { Id_planta = id });

        }

        public async Task<bool> InsertPlantas(cat_plantas cat_Plantas)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO cat_plantas(nom_planta, descripcion_planta, ubicacion) VALUES (@Nom_planta, @Descripcion_planta, @Ubicacion)";

            var result = await db.ExecuteAsync(sql, new
            { cat_Plantas.Nom_planta, cat_Plantas.Descripcion_planta, cat_Plantas.Ubicacion});

            return result > 0;
        }

        public async Task<bool> UpdatePlantas(cat_plantas cat_Plantas)
        {
            var db = dbConnection();

            var sql = @"UPDATE cat_plantas SET 
                    nom_planta = @Nom_planta, 
                    descripcion_planta = @Descripcion_planta,
                    ubicacion = @Ubicacion
                    WHERE id_planta = @Id_planta";

            var result = await db.ExecuteAsync(sql, new
            {
                cat_Plantas.Nom_planta,
                cat_Plantas.Descripcion_planta,
                cat_Plantas.Ubicacion,
                cat_Plantas.Id_planta
            });

            return result > 0;
        }
    }
}
