using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface IEstadoUsuarioRepository
    {
        Task<IEnumerable<usu_estado_usuario>> GetAllEstado();
        Task<usu_estado_usuario> GetDetails(int id);
        Task<bool> InsertEstado(usu_estado_usuario usu_Estado_usuario);
        Task<bool> UpdateEstado(usu_estado_usuario usu_Estado_usuario);
        Task<bool> DeleteEstado(usu_estado_usuario usu_Estado_usuario);
    }
}
