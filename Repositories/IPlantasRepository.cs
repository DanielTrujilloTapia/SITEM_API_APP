using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IPlantasRepository
    {
        Task<IEnumerable<cat_plantas>> GetAllPlantas();
        Task<cat_plantas> GetDetails(int id);
        Task<bool> InsertPlantas(cat_plantas cat_Plantas);
        Task<bool> UpdatePlantas(cat_plantas cat_Plantas);
        Task<bool> DeletePlantas(cat_plantas cat_Plantas);
    }
}
