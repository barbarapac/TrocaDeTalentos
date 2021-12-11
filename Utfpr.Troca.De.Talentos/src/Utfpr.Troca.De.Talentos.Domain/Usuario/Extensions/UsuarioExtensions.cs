using Utfpr.Troca.De.Talentos.Domain.Usuario.Validations;

namespace Utfpr.Troca.De.Talentos.Domain.Usuario.Extensions
{
    public static class UsuarioExtensions
    {
        public static Usuario Validation(this Usuario usuario)
        {
            var validationResult = new UsuarioValidation().Validate(usuario);
            usuario.ValidationResult = validationResult;
            return usuario;
        }
    }
}