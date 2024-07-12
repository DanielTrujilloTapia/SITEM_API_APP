using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Usu_Puesto_UsuarioRepository: IPuestoUsuarioRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Usu_Puesto_UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public async Task<bool> DeletePuesto(usu_puesto_usuario usu_Puesto_usuario)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usu_puesto_usuario WHERE id_puesto = @Id_puesto";

            var result = await db.ExecuteAsync(sql, new { Id_puesto = usu_Puesto_usuario.Id_puesto });

            return result > 0;
        }

        public async Task<IEnumerable<usu_puesto_usuario>> GetAllPuesto()
        {
            var db = dbConnection();

            var sql = @"SELECT id_puesto, nom_puesto, descripcion_puesto FROM usu_puesto_usuario";

            return await db.QueryAsync<usu_puesto_usuario>(sql, new { });
        }

        public async Task<usu_puesto_usuario> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_puesto, nom_puesto, descripcion_puesto FROM usu_puesto_usuario WHERE id_puesto = @Id_puesto";

            return await db.QueryFirstOrDefaultAsync<usu_puesto_usuario>(sql, new { Id_puesto = id });

        }

        public async Task<bool> InsertPuesto(usu_puesto_usuario usu_Puesto_usuario)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO usu_puesto_usuario(id_puesto, nom_puesto, descripcion_puesto) VALUES (@Id_puesto, @Nom_puesto, @Descripcion_puesto)";

            var result = await db.ExecuteAsync(sql, new
            { usu_Puesto_usuario.Id_puesto, usu_Puesto_usuario.Nom_puesto, usu_Puesto_usuario.Descripcion_puesto });

            return result > 0;
        }

        public async Task<bool> UpdatePuesto(usu_puesto_usuario usu_Puesto_usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE usu_puesto_usuario SET 
                    nom_puesto = @Nom_puesto,
                    descripcion_puesto = @Descripcion_puesto
                    WHERE id_puesto = @Id_puesto";

            var result = await db.ExecuteAsync(sql, new
            {
                usu_Puesto_usuario.Nom_puesto,
                usu_Puesto_usuario.Descripcion_puesto,
                usu_Puesto_usuario.Id_puesto
            });

            return result > 0;
        }
    }
}
