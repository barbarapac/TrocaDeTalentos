using Utfpr.Troca.De.Talentos.Domain.Areas;

namespace Utfpr.Troca.De.Talentos.Domain.UsuarioArea
{
    public class UsuarioArea : SimpleId<long>
    {
        private long _usuarioId;
        private long _areaId;
        
        public Usuario.Usuario Usuario  { get; private set; }
        public Area Area { get; private set; }
    }
}