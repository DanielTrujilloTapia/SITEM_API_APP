using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Tarea_FallaRepository: ITareaFallaRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Tarea_FallaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteTareaFalla(tarea_falla tarea_Falla)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM tarea_falla WHERE id_tarea_falla = @Id_tarea_falla";

            var result = await db.ExecuteAsync(sql, new { Id_tarea_falla = tarea_Falla.Id_tarea_falla });

            return result > 0;
        }

        public async Task<IEnumerable<tarea_falla>> GetAllTareaFalla()
        {
            var db = dbConnection();

            var sql = @"SELECT id_tarea_falla, nom_tarea, descripcion_tarea, fecha_publicacion_falla, fecha_entrega_falla, idtareaestatus_falla, idusuario_admin, idusuario_encargado, idusuario_ayudante, idcatplanta, idtareaprioridad FROM tarea_falla";

            return await db.QueryAsync<tarea_falla>(sql, new { });
        }

        public async Task<tarea_falla> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_tarea_falla, nom_tarea, descripcion_tarea, fecha_publicacion_falla, fecha_entrega_falla, idtareaestatus_falla, idusuario_admin, idusuario_encargado, idusuario_ayudante, idcatplanta, idtareaprioridad FROM tarea_falla WHERE id_tarea_falla = @Id_tarea_falla";

            return await db.QueryFirstOrDefaultAsync<tarea_falla>(sql, new { Id_tarea_falla = id });

        }

        public async Task<bool> InsertTareaFalla(tarea_falla tarea_Falla)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO tarea_falla(nom_tarea, descripcion_tarea, fecha_publicacion_falla, fecha_entrega_falla, idtareaestatus_falla, idusuario_admin, idusuario_encargado, idusuario_ayudante, idcatplanta, idtareaprioridad) VALUES (@Nom_tarea, @Descripcion_tarea, @Fecha_publicacion_falla, @Fecha_entrega_falla, @Idtareaestatus_falla, @Idusuario_admin, @Idusuario_encargado, @Idusuario_ayudante, @Idcatplanta, @Idtareaprioridad)";

            var result = await db.ExecuteAsync(sql, new
            { tarea_Falla.Nom_tarea, tarea_Falla.Descripcion_tarea, tarea_Falla.Fecha_publicacion_falla, tarea_Falla.Fecha_entrega_falla, tarea_Falla.Idtareaestatus_falla, tarea_Falla.Idusuario_admin, tarea_Falla.Idusuario_encargado, tarea_Falla.Idusuario_ayudante, tarea_Falla.Idcatplanta, tarea_Falla.Idtareaprioridad});

            return result > 0;
        }

        public async Task<bool> UpdateTareaFalla(tarea_falla tarea_Falla)
        {
            var db = dbConnection();

            var sql = @"UPDATE tarea_falla SET 
                    nom_tarea = @Nom_tarea, 
                    descripcion_tarea = @Descripcion_tarea, 
                    fecha_publicacion_falla = @Fecha_publicacion_falla, 
                    fecha_entrega_falla = @Fecha_entrega_falla, 
                    idtareaestatus_falla = @Idtareaestatus_falla, 
                    idusuario_admin = @Idusuario_admin, 
                    idusuario_encargado = @Idusuario_encargado, 
                    idusuario_ayudante = @Idusuario_ayudante,
                    idcatplanta = @Idcatplanta, 
                    idtareaprioridad = @Idtareaprioridad
                    WHERE id_tarea_falla = @Id_tarea_falla";

            var result = await db.ExecuteAsync(sql, new
            {
                tarea_Falla.Nom_tarea,
                tarea_Falla.Descripcion_tarea,
                tarea_Falla.Fecha_publicacion_falla,
                tarea_Falla.Fecha_entrega_falla,
                tarea_Falla.Idtareaestatus_falla,
                tarea_Falla.Idusuario_admin,
                tarea_Falla.Idusuario_encargado,
                tarea_Falla.Idusuario_ayudante,
                tarea_Falla.Idcatplanta,
                tarea_Falla.Idtareaprioridad,
                tarea_Falla.Id_tarea_falla

            });

            return result > 0;
        }
    }
}
