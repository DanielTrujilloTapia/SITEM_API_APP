using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IEstatusRepository
    {
        Task<IEnumerable<tareas_estatus>> GetAllEstatus();
        Task<tareas_estatus> GetDetails(int id);
        Task<bool> InsertEstatus(tareas_estatus tareas_Estatus);
        Task<bool> UpdateEstatus(tareas_estatus tareas_Estatus);
        Task<bool> DeleteEstatus(tareas_estatus tareas_Estatus);
    }
}
