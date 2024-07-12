using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface ITareaServicioRepository
    {
        Task<IEnumerable<tarea_servicio>> GetAllTareaServicio();
        Task<tarea_servicio> GetDetails(int id);
        Task<bool> InsertTareaServicio(tarea_servicio tarea_Servicio);
        Task<bool> UpdateTareaServicio(tarea_servicio tarea_Servicio);
        Task<bool> DeleteTareaServicio(tarea_servicio tarea_Servicio);
    }
}
