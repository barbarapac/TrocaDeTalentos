namespace Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Ra { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }
    }
}