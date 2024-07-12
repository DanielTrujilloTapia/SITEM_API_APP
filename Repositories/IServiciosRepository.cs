using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IServiciosRepository
    {
        Task<IEnumerable<cat_servicios>> GetAllServicios();
        Task<cat_servicios> GetDetails(int id);
        Task<bool> InsertServicios(cat_servicios cat_Servicios);
        Task<bool> UpdateServicios(cat_servicios cat_Servicios);
        Task<bool> DeleteServicios(cat_servicios cat_Servicios);
    }
}
