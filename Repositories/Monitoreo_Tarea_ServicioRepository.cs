using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Monitoreo_Tarea_ServicioRepository: IMonitoreoTareaServicioRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Monitoreo_Tarea_ServicioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteMonitoreoTareaServicio(monitoreo_tarea_servicio monitoreo_Tarea_servicio)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM monitoreo_tarea_servicio WHERE id_monitoreo_servicio = @Id_monitoreo_servicio";

            var result = await db.ExecuteAsync(sql, new { Id_monitoreo_servicio = monitoreo_Tarea_servicio.Id_monitoreo_servicio });

            return result > 0;
        }

        public async Task<IEnumerable<monitoreo_tarea_servicio>> GetAllMonitoreoTareaServicio()
        {
            var db = dbConnection();

            var sql = @"SELECT id_monitoreo_servicio, idtareaservicio, fecha_inicio_servicio, fecha_finalizacion_servicio FROM monitoreo_tarea_servicio";

            return await db.QueryAsync<monitoreo_tarea_servicio>(sql, new { });
        }

        public async Task<monitoreo_tarea_servicio> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_monitoreo_servicio, idtareaservicio, fecha_inicio_servicio, fecha_finalizacion_servicio FROM monitoreo_tarea_servicio WHERE id_monitoreo_servicio = @Id_monitoreo_servicio";

            return await db.QueryFirstOrDefaultAsync<monitoreo_tarea_servicio>(sql, new { Id_monitoreo_servicio = id });

        }

        public async Task<bool> InsertMonitoreoTareaServicio(monitoreo_tarea_servicio monitoreo_Tarea_servicio)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO monitoreo_tarea_servicio(idtareaservicio, fecha_inicio_servicio, fecha_finalizacion_servicio) VALUES (@Idtareaservicio, @Fecha_inicio_servicio, @Fecha_finalizacion_servicio)";

            var result = await db.ExecuteAsync(sql, new
            { monitoreo_Tarea_servicio.Idtareaservicio, monitoreo_Tarea_servicio.Fecha_inicio_servicio, monitoreo_Tarea_servicio.Fecha_finalizacion_servicio});

            return result > 0;
        }

        public async Task<bool> UpdateMonitoreoTareaServicio(monitoreo_tarea_servicio monitoreo_Tarea_servicio)
        {
            var db = dbConnection();

            var sql = @"UPDATE monitoreo_tarea_servicio SET 
                    idtareaservicio = @Idtareaservicio, 
                    fecha_inicio_servicio = @Fecha_inicio_servicio,
                    fecha_finalizacion_servicio = @Fecha_finalizacion_servicio
                    WHERE id_monitoreo_servicio = @Id_monitoreo_servicio";

            var result = await db.ExecuteAsync(sql, new
            {
                monitoreo_Tarea_servicio.Idtareaservicio,
                monitoreo_Tarea_servicio.Fecha_inicio_servicio,
                monitoreo_Tarea_servicio.Fecha_finalizacion_servicio,
                monitoreo_Tarea_servicio.Id_monitoreo_servicio
            });

            return result > 0;
        }
    }
}
