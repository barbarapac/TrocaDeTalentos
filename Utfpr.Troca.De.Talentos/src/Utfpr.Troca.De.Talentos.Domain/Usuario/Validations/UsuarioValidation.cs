using FluentValidation;

namespace Utfpr.Troca.De.Talentos.Domain.Usuario.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(usuario => usuario.Tipo).NotNull().WithMessage("Tipo de usuário é obrigatório");
            RuleFor(usuario => usuario.Email).NotNull().WithMessage("E-mail é obrigatório");
            RuleFor(usuario => usuario.Senha).NotNull().WithMessage("Senha é obrigatória");
            RuleFor(usuario => usuario.Ra).NotNull().WithMessage("Registro acadêmico é obrigatório");
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage("E-mail inválido");
        }
    }
}