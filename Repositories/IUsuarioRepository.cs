using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<usu_usuario>> GetAllUsuario();
        Task<usu_usuario> GetDetails(int id);
        Task<bool> InsertUsuario(usu_usuario usu_Usuario);
        Task<bool> UpdateUsuario(usu_usuario usu_Usuario);
        Task<bool> DeleteUsuario(usu_usuario usu_Usuario);
    }
}
