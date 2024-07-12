using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IMonitoreo_Tarea_FallaRepository
    {
        Task<IEnumerable<monitoreo_tarea_falla>> GetAllMonitoreoTareaFalla();
        Task<monitoreo_tarea_falla> GetDetails(int id);
        Task<bool> InsertMonitoreoTareaFalla(monitoreo_tarea_falla monitoreo_Tarea_falla);
        Task<bool> UpdateMonitoreoTareaFalla(monitoreo_tarea_falla monitoreo_Tarea_falla);
        Task<bool> DeleteMonitoreoTareaFalla(monitoreo_tarea_falla monitoreo_Tarea_falla);
    }
}
