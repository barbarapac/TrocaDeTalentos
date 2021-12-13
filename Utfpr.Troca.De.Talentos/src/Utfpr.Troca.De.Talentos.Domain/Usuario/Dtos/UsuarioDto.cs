namespace Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Ra { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
    }
}