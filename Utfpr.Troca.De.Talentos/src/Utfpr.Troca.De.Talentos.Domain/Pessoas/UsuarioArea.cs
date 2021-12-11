using System.Collections.Generic;
using Utfpr.Troca.De.Talentos.Domain.Areas;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class UsuarioArea : SimpleId<long>
    {
        private long _usuarioId;
        private long _areaId;
        
        public Usuario Usuario  { get; private set; }
        public Area Area { get; private set; }
    }
}