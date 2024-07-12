using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IPuestoUsuarioRepository
    {
        Task<IEnumerable<usu_puesto_usuario>> GetAllPuesto();
        Task<usu_puesto_usuario> GetDetails(int id);
        Task<bool> InsertPuesto(usu_puesto_usuario usu_Puesto_usuario);
        Task<bool> UpdatePuesto(usu_puesto_usuario usu_Puesto_usuario);
        Task<bool> DeletePuesto(usu_puesto_usuario usu_Puesto_usuario);
    }
}
