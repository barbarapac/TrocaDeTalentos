using System.Reflection.Metadata;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class Usuario : SimpleId<long>
    {
        public string Ra { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }
        public byte[] FotoPerfil { get; private set; }
    }
}