using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Usu_Tipo_UsuarioRepository : ITipoUsuarioRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Usu_Tipo_UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public async Task<bool> DeleteTipo(usu_tipo_usuario usu_Tipo_usuario)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usu_tipo_usuario WHERE id_tipo = @Id_tipo";

            var result = await db.ExecuteAsync(sql, new { Id_tipo = usu_Tipo_usuario.Id_tipo });

            return result > 0;
        }

        public async Task<IEnumerable<usu_tipo_usuario>> GetAllTipo()
        {
            var db = dbConnection();

            var sql = @"SELECT id_tipo, nom_tipo, descripcion_tipo FROM usu_tipo_usuario";

            return await db.QueryAsync<usu_tipo_usuario>(sql, new { });
        }

        public async Task<usu_tipo_usuario> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_tipo, nom_tipo, descripcion_tipo FROM usu_tipo_usuario WHERE id_tipo = @Id_tipo";

            return await db.QueryFirstOrDefaultAsync<usu_tipo_usuario>(sql, new { Id_tipo = id });

        }

        public async Task<bool> InsertTipo(usu_tipo_usuario usu_Tipo_usuario)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO usu_tipo_usuario(id_tipo, nom_tipo, descripcion_tipo) VALUES (@Id_tipo, @Nom_tipo, @Descripcion_tipo)";

            var result = await db.ExecuteAsync(sql, new
            { usu_Tipo_usuario.Id_tipo, usu_Tipo_usuario.Nom_tipo, usu_Tipo_usuario.Descripcion_tipo});

            return result > 0;
        }

        public async Task<bool> UpdateTipo(usu_tipo_usuario usu_Tipo_usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE usu_tipo_usuario SET 
                    nom_tipo = @Nom_tipo,
                    descripcion_tipo = @Descripcion_tipo
                    WHERE id_tipo = @Id_tipo";

            var result = await db.ExecuteAsync(sql, new
            {
                usu_Tipo_usuario.Nom_tipo,
                usu_Tipo_usuario.Descripcion_tipo,
                usu_Tipo_usuario.Id_tipo
            });

            return result > 0;
        }
    }
}
