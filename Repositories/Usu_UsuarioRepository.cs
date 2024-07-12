using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Usu_UsuarioRepository : IUsuarioRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Usu_UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public async Task<bool> DeleteUsuario(usu_usuario usu_Usuario)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usu_usuario WHERE id_usuario = @Id_usuario";

            var result = await db.ExecuteAsync(sql, new { Id_usuario = usu_Usuario.Id_usuario });

            return result > 0;
        }

        public async Task<IEnumerable<usu_usuario>> GetAllUsuario()
        {
            var db = dbConnection();

            var sql = @"SELECT id_usuario, nom_usuario, contrasena, idusuestado, idusutipousuario, idusupuestousuario FROM usu_usuario";

            return await db.QueryAsync<usu_usuario>(sql, new { });
        }

        public async Task<usu_usuario> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_usuario, nom_usuario, contrasena, idusuestado, idusutipousuario, idusupuestousuario FROM usu_usuario WHERE id_usuario = @Id_usuario";

            return await db.QueryFirstOrDefaultAsync<usu_usuario>(sql, new { Id_usuario = id });

        }

        public async Task<bool> InsertUsuario(usu_usuario usu_Usuario)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO usu_usuario(nom_usuario, contrasena, idusuestado, idusutipousuario, idusupuestousuario ) VALUES (@Nom_usuario, @Contrasena, @Idusuestado, @Idusutipousuario, @Idusupuestousuario)";

            var result = await db.ExecuteAsync(sql, new
            { usu_Usuario.Nom_usuario, usu_Usuario.Contrasena, usu_Usuario.Idusuestado, usu_Usuario.Idusutipousuario, usu_Usuario.Idusupuestousuario});

            return result > 0;
        }

        public async Task<bool> UpdateUsuario(usu_usuario usu_Usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE usu_usuario SET 
                    nom_usuario = @Nom_usuario,
                    contrasena = @Contrasena, 
                    idusuestado = @Idusuestado, 
                    idusutipousuario = @Idusutipousuario,
                    idusupuestousuario = @Idusupuestousuario
                    WHERE id_usuario = @Id_usuario";

            var result = await db.ExecuteAsync(sql, new
            {
                usu_Usuario.Nom_usuario,
                usu_Usuario.Contrasena,
                usu_Usuario.Idusuestado,
                usu_Usuario.Idusutipousuario,
                usu_Usuario.Idusupuestousuario,
                usu_Usuario.Id_usuario
            });

            return result > 0;
        }
    }
}
