using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Monitoreo_Tarea_FallaRepository: IMonitoreo_Tarea_FallaRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Monitoreo_Tarea_FallaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteMonitoreoTareaFalla(monitoreo_tarea_falla monitoreo_Tarea_falla)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM monitoreo_tarea_falla WHERE id_monitoreo_falla = @Id_monitoreo_falla";

            var result = await db.ExecuteAsync(sql, new { Id_monitoreo_falla = monitoreo_Tarea_falla.Id_monitoreo_falla });

            return result > 0;
        }

        public async Task<IEnumerable<monitoreo_tarea_falla>> GetAllMonitoreoTareaFalla()
        {
            var db = dbConnection();

            var sql = @"SELECT id_monitoreo_falla, idtareafalla, fecha_inicio_falla, fecha_finalizacion_falla FROM monitoreo_tarea_falla";

            return await db.QueryAsync<monitoreo_tarea_falla>(sql, new { });
        }

        public async Task<monitoreo_tarea_falla> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_monitoreo_falla, idtareafalla, fecha_inicio_falla, fecha_finalizacion_falla FROM monitoreo_tarea_falla WHERE id_monitoreo_falla = @Id_monitoreo_falla";

            return await db.QueryFirstOrDefaultAsync<monitoreo_tarea_falla>(sql, new { Id_monitoreo_falla = id });

        }

        public async Task<bool> InsertMonitoreoTareaFalla(monitoreo_tarea_falla monitoreo_Tarea_falla)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO monitoreo_tarea_falla(idtareafalla, fecha_inicio_falla, fecha_finalizacion_falla) VALUES (@Idtareafalla, @Fecha_inicio_falla, @Fecha_finalizacion_falla)";

            var result = await db.ExecuteAsync(sql, new
            { monitoreo_Tarea_falla.Idtareafalla, monitoreo_Tarea_falla.Fecha_inicio_falla, monitoreo_Tarea_falla.Fecha_finalizacion_falla});

            return result > 0;
        }

        public async Task<bool> UpdateMonitoreoTareaFalla(monitoreo_tarea_falla monitoreo_Tarea_falla)
        {
            var db = dbConnection();

            var sql = @"UPDATE monitoreo_tarea_falla SET 
                    idtareafalla = @Idtareafalla, 
                    fecha_inicio_falla = @Fecha_inicio_falla,
                    fecha_finalizacion_falla = @Fecha_finalizacion_falla
                    WHERE id_monitoreo_falla = @Id_monitoreo_falla";

            var result = await db.ExecuteAsync(sql, new
            {
                monitoreo_Tarea_falla.Idtareafalla,
                monitoreo_Tarea_falla.Fecha_inicio_falla,
                monitoreo_Tarea_falla.Fecha_finalizacion_falla,
                monitoreo_Tarea_falla.Id_monitoreo_falla
            });

            return result > 0;
        }
    }
}
