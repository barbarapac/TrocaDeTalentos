using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Utfpr.Troca.De.Talentos.Domain.Areas;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class Usuario : SimpleId<long>
    {
        private long _usuarioId;
        
        public string Ra { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }
        public byte[] FotoPerfil { get; private set; }
        public IList<UsuarioArea> Areas { get; private set; } = new List<UsuarioArea>();
    }
}