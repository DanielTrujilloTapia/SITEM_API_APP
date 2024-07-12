using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface ITareaFallaRepository
    {
        Task<IEnumerable<tarea_falla>> GetAllTareaFalla();
        Task<tarea_falla> GetDetails(int id);
        Task<bool> InsertTareaFalla(tarea_falla tarea_Falla);
        Task<bool> UpdateTareaFalla(tarea_falla tarea_Falla);
        Task<bool> DeleteTareaFalla(tarea_falla tarea_Falla);
    }
}
