using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Usu_Estado_UsuarioRepository: IEstadoUsuarioRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Usu_Estado_UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public async Task<bool> DeleteEstado(usu_estado_usuario usu_Estado_usuario)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usu_estado_usuario WHERE id_estado = @Id_estado";

            var result = await db.ExecuteAsync(sql, new { Id_estado = usu_Estado_usuario.Id_estado });

            return result > 0;
        }

        public async Task<IEnumerable<usu_estado_usuario>> GetAllEstado()
        {
            var db = dbConnection();

            var sql = @"SELECT id_estado, nom_estado, descripcion_estado FROM usu_estado_usuario";

            return await db.QueryAsync<usu_estado_usuario>(sql, new { });
        }

        public async Task<usu_estado_usuario> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_estado, nom_estado, descripcion_estado FROM usu_estado_usuario WHERE id_estado = @Id_estado";

            return await db.QueryFirstOrDefaultAsync<usu_estado_usuario>(sql, new { Id_estado = id });

        }

        public async Task<bool> InsertEstado(usu_estado_usuario usu_Estado_usuario)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO usu_estado_usuario(id_estado, nom_estado, descripcion_estado) VALUES (@Id_estado, @Nom_estado, @Descripcion_estado)";

            var result = await db.ExecuteAsync(sql, new
            { usu_Estado_usuario.Id_estado, usu_Estado_usuario.Nom_estado, usu_Estado_usuario.Descripcion_estado});

            return result > 0;
        }

        public async Task<bool> UpdateEstado(usu_estado_usuario usu_Estado_usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE usu_estado_usuario SET 
                    nom_estado = @Nom_estado,
                    descripcion_estado = @Descripcion_estado
                    WHERE id_estado = @Id_estado";

            var result = await db.ExecuteAsync(sql, new
            {
                usu_Estado_usuario.Nom_estado,
                usu_Estado_usuario.Descripcion_estado,
                usu_Estado_usuario.Id_estado
            });

            return result > 0;
        }
    }
}
