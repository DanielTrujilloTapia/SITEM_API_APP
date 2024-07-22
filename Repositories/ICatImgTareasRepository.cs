using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface ICatImgTareasRepository
    {
        Task<IEnumerable<cat_img_tarea>> GetAllImg();
        Task<cat_img_tarea> GetDetails(int id);
        Task<bool> InsertImg(cat_img_tarea cat_Img_tarea);
        Task<bool> UpdateImg(cat_img_tarea cat_Img_tarea);
        Task<bool> DeleteImg(cat_img_tarea cat_Img_tarea);
    }
}
