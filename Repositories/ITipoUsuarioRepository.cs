using SITEM_API_APP.Model;

namespace SITEM_API_APP.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<IEnumerable<usu_tipo_usuario>> GetAllTipo();
        Task<usu_tipo_usuario> GetDetails(int id);
        Task<bool> InsertTipo(usu_tipo_usuario usu_Tipo_usuario);
        Task<bool> UpdateTipo(usu_tipo_usuario usu_Tipo_usuario);
        Task<bool> DeleteTipo(usu_tipo_usuario usu_Tipo_usuario);
    }
}
