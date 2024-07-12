using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Usu_Datos_PersonalesRepository: IDatosPersonalesRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Usu_Datos_PersonalesRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteDatos(usu_datos_personales usu_Datos_personales)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usu_datos_personales WHERE id_datos = @Id_datos";

            var result = await db.ExecuteAsync(sql, new { Id_datos = usu_Datos_personales.Id_datos });

            return result > 0;
        }

        public async Task<IEnumerable<usu_datos_personales>> GetAllDatos()
        {
            var db = dbConnection();

            var sql = @"SELECT id_datos, idusuusuario_datos, nombres, apellidos, edad, domicilio, sexo, correo, telefono FROM usu_datos_personales";

            return await db.QueryAsync<usu_datos_personales>(sql, new { });
        }

        public async Task<usu_datos_personales> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_datos, idusuusuario_datos, nombres, apellidos, edad, domicilio, sexo, correo, telefono FROM usu_datos_personales WHERE id_datos = @Id_datos";

            return await db.QueryFirstOrDefaultAsync<usu_datos_personales>(sql, new { Id_datos = id });

        }

        public async Task<bool> InsertDatos(usu_datos_personales usu_Datos_personales)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO usu_datos_personales(idusuusuario_datos, nombres, apellidos, edad, domicilio, sexo, correo, telefono) VALUES (@Idusuusuario_datos, @Nombres, @Apellidos, @Edad, @Domicilio, @Sexo, @Correo, @Telefono)";

            var result = await db.ExecuteAsync(sql, new
            { usu_Datos_personales.Idusuusuario_datos, usu_Datos_personales.Nombres, usu_Datos_personales.Apellidos, usu_Datos_personales.Edad, usu_Datos_personales.Domicilio, usu_Datos_personales.Sexo, usu_Datos_personales.Correo, usu_Datos_personales.Telefono });

            return result > 0;
        }

        public async Task<bool> UpdateDatos(usu_datos_personales usu_Datos_personales)
        {
            var db = dbConnection();

            var sql = @"UPDATE usu_datos_personales SET 
                    idusuusuario_datos = @Idusuusuario_datos,
                    nombres = @Nombres, 
                    apellidos = @Apellidos, 
                    edad = @Edad, 
                    domicilio = @Domicilio, 
                    sexo = @Sexo, 
                    correo = @Correo, 
                    telefono = @Telefono
                    WHERE id_datos = @Id_datos";

            var result = await db.ExecuteAsync(sql, new
            {
                usu_Datos_personales.Idusuusuario_datos,
                usu_Datos_personales.Nombres,
                usu_Datos_personales.Apellidos,
                usu_Datos_personales.Edad,
                usu_Datos_personales.Domicilio,
                usu_Datos_personales.Sexo,
                usu_Datos_personales.Correo,
                usu_Datos_personales.Telefono,
                usu_Datos_personales.Id_datos
            });

            return result > 0;
        }
    }
}
