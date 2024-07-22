using Dapper;
using MySql.Data.MySqlClient;
using SITEM_API_APP.Data;
using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public class Cat_Img_TareaRepository: ICatImgTareasRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public Cat_Img_TareaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteImg(cat_img_tarea cat_Img_tarea)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM cat_img_tarea WHERE id_img = @Id_img";

            var result = await db.ExecuteAsync(sql, new { Id_planta = cat_Img_tarea.Id_img });

            return result > 0;
        }

        public async Task<IEnumerable<cat_img_tarea>> GetAllImg()
        {
            var db = dbConnection();

            var sql = @"SELECT id_img, foto, idserviciotarea, idfallatarea FROM cat_img_tarea";

            return await db.QueryAsync<cat_img_tarea>(sql, new { });
        }

        public async Task<cat_img_tarea> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT id_img, foto, idserviciotarea, idfallatarea FROM cat_img_tarea WHERE id_img = @Id_img";

            return await db.QueryFirstOrDefaultAsync<cat_img_tarea>(sql, new { Id_img = id });

        }

        public async Task<bool> InsertImg(cat_img_tarea cat_Img_tarea)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO cat_img_tarea(foto, idserviciotarea, idfallatarea) VALUES (@Foto, @Idserviciotarea, @Idfallatarea)";

            var result = await db.ExecuteAsync(sql, new
            { cat_Img_tarea.Foto, cat_Img_tarea.Idserviciotarea, cat_Img_tarea.Idfallatarea });

            return result > 0;
        }

        public async Task<bool> UpdateImg(cat_img_tarea cat_Img_tarea)
        {
            var db = dbConnection();

            var sql = @"UPDATE cat_img_tarea SET 
                    foto = @Foto, 
                    idserviciotarea = @Idserviciotarea,
                    idfallatarea = @Idfallatarea
                    WHERE id_img = @Id_img";

            var result = await db.ExecuteAsync(sql, new
            {
                cat_Img_tarea.Foto,
                cat_Img_tarea.Idserviciotarea,
                cat_Img_tarea.Idfallatarea,
                cat_Img_tarea.Id_img
            });

            return result > 0;
        }
    }
}
