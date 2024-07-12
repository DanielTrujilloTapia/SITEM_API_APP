using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IPrioridadRepository
    {
        Task<IEnumerable<tareas_prioridad>> GetAllPrioridad();
        Task<tareas_prioridad> GetDetails(int id);
        Task<bool> InsertPrioridad(tareas_prioridad tareas_Prioridad);
        Task<bool> UpdatePrioridad(tareas_prioridad tareas_Prioridad);
        Task<bool> DeletePrioridad(tareas_prioridad tareas_Prioridad);
    }
}
