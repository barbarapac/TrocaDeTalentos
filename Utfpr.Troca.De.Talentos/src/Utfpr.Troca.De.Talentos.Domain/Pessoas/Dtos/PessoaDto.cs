using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos
{
    public class PessoaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long IdUsuario { get; set; }
        public string Curso { get; set; }
        public string Campus { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public byte[] FotoPerfil { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}