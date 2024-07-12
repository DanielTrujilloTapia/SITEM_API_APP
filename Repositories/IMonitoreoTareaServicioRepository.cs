using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IMonitoreoTareaServicioRepository
    {
        Task<IEnumerable<monitoreo_tarea_servicio>> GetAllMonitoreoTareaServicio();
        Task<monitoreo_tarea_servicio> GetDetails(int id);
        Task<bool> InsertMonitoreoTareaServicio(monitoreo_tarea_servicio monitoreo_Tarea_servicio);
        Task<bool> UpdateMonitoreoTareaServicio(monitoreo_tarea_servicio monitoreo_Tarea_servicio);
        Task<bool> DeleteMonitoreoTareaServicio(monitoreo_tarea_servicio monitoreo_Tarea_servicio);
    }
}
