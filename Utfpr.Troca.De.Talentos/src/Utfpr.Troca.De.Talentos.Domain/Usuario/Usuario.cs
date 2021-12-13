using System.Collections.Generic;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Domain.Usuario
{
    public class Usuario : SimpleId<long>
    {
        private long _usuarioId;
        
        public string Ra { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }
        public IList<UsuarioArea.UsuarioArea> Areas { get; private set; } = new List<UsuarioArea.UsuarioArea>();
    }
}