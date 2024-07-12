using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IDatosPersonalesRepository
    {
        Task<IEnumerable<usu_datos_personales>> GetAllDatos();
        Task<usu_datos_personales> GetDetails(int id);
        Task<bool> InsertDatos(usu_datos_personales usu_Datos_personales);
        Task<bool> UpdateDatos(usu_datos_personales usu_Datos_personales);
        Task<bool> DeleteDatos(usu_datos_personales usu_Datos_personales);
    }
}
