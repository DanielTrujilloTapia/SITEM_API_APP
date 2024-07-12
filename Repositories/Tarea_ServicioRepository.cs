using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Tarea_ServicioRepository: ITareaServicioRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Tarea_ServicioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteTareaServicio(tarea_servicio tarea_Servicio)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM tarea_servicio WHERE id_tarea_servicio = @Id_tarea_servicio";

            var result = await db.ExecuteAsync(sql, new { Id_tarea_servicio = tarea_Servicio.Id_tarea_servicio });

            return result > 0;
        }

        public async Task<IEnumerable<tarea_servicio>> GetAllTareaServicio()
        {
            var db = dbConnection();

            var sql = @"SELECT id_tarea_servicio, nom_tarea_servicio, idcatservicios, idusuusuario_encargado, idusuusuario_ayudante, idusuusuario_admin, idcatplantas, fecha_publicacion_servicio, fecha_entega_servicio, idtareaestatus_servicio, idtareasprioridad FROM tarea_servicio";

            return await db.QueryAsync<tarea_servicio>(sql, new { });
        }

        public async Task<tarea_servicio> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_tarea_servicio, nom_tarea_servicio, idcatservicios, idusuusuario_encargado, idusuusuario_ayudante, idusuusuario_admin, idcatplantas, fecha_publicacion_servicio, fecha_entega_servicio, idtareaestatus_servicio, idtareasprioridad FROM tarea_servicio WHERE id_tarea_servicio = @Id_tarea_servicio";

            return await db.QueryFirstOrDefaultAsync<tarea_servicio>(sql, new { Id_tarea_servicio = id });

        }

        public async Task<bool> InsertTareaServicio(tarea_servicio tarea_Servicio)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO tarea_servicio(nom_tarea_servicio, idcatservicios, idusuusuario_encargado, idusuusuario_ayudante, idusuusuario_admin, idcatplantas, fecha_publicacion_servicio, fecha_entega_servicio, idtareaestatus_servicio, idtareasprioridad) VALUES (@Nom_tarea_servicio, @Idcatservicios, @Idusuusuario_encargado, @Idusuusuario_ayudante, @Idusuusuario_admin, @Idcatplantas, @Fecha_publicacion_servicio, @Fecha_entega_servicio, @Idtareaestatus_servicio, @Idtareasprioridad)";

            var result = await db.ExecuteAsync(sql, new
            { tarea_Servicio.Nom_tarea_servicio, tarea_Servicio.Idcatservicios, tarea_Servicio.Idusuusuario_encargado, tarea_Servicio.Idusuusuario_ayudante, tarea_Servicio.Idusuusuario_admin, tarea_Servicio.Idcatplantas, tarea_Servicio.Fecha_publicacion_servicio, tarea_Servicio.Fecha_entega_servicio, tarea_Servicio.Idtareaestatus_servicio, tarea_Servicio.Idtareasprioridad});

            return result > 0;
        }

        public async Task<bool> UpdateTareaServicio(tarea_servicio tarea_Servicio)
        {
            var db = dbConnection();

            var sql = @"UPDATE tarea_servicio SET 
                    nom_tarea_servicio = @Nom_tarea_servicio, 
                    idcatservicios = @Idcatservicios, 
                    idusuusuario_encargado = @Idusuusuario_encargado, 
                    idusuusuario_ayudante = @Idusuusuario_ayudante, 
                    idusuusuario_admin = @Idusuusuario_admin, 
                    idcatplantas = @Idcatplantas, 
                    fecha_publicacion_servicio = @Fecha_publicacion_servicio, 
                    fecha_entega_servicio = @Fecha_entega_servicio, 
                    idtareaestatus_servicio = @Idtareaestatus_servicio, 
                    idtareasprioridad = @Idtareasprioridad
                    WHERE id_tarea_servicio = @Id_tarea_servicio";

            var result = await db.ExecuteAsync(sql, new
            {
                tarea_Servicio.Nom_tarea_servicio,
                tarea_Servicio.Idcatservicios,
                tarea_Servicio.Idusuusuario_encargado,
                tarea_Servicio.Idusuusuario_ayudante,
                tarea_Servicio.Idusuusuario_admin,
                tarea_Servicio.Idcatplantas,
                tarea_Servicio.Fecha_publicacion_servicio,
                tarea_Servicio.Fecha_entega_servicio,
                tarea_Servicio.Idtareaestatus_servicio,
                tarea_Servicio.Idtareasprioridad,
                tarea_Servicio.Id_tarea_servicio

            });

            return result > 0;
        }
    }
}
