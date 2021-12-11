using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands.Handlers;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Profiles;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces;
using Utfpr.Troca.De.Talentos.Infrastructure.Repositories;
using Utfpr.Troca.De.Talentos.QueryStack.Usuarios;
using Utfpr.Troca.De.Talentos.QueryStack.Usuarios.Imp;

namespace Utfpr.Troca.De.Talentos
{
    public static class NativeDependencyInjection
    {
        public static IServiceCollection RegistraTodosServicosAplicacao(this IServiceCollection services)
        {
            services
                .RegistraSwaggerGen()
                .RegistraTodosCommandHandlers()
                .RegistraTodosRepositorios()
                .AddAutoMapper(typeof(UsuarioDtoToUsuarioProfile))
                .AddMediatR(typeof(UsuarioCommandHandler).Assembly);
            return services;
        }
        
        private static IServiceCollection RegistraTodosCommandHandlers(this IServiceCollection services)
        {
            return services.AddScoped<IRequestHandler<UsuarioCriacaoAutenticacaoCommand, UsuarioDto>, UsuarioCommandHandler>();
        }
        
        private static IServiceCollection RegistraSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Troca de talentos - API",
                    Description = "Documentação API",
                    Version = "v1"
                });
            });

            return services;
        }
        
        private static IServiceCollection RegistraTodosRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioQuerie, UsuarioQuerie>();
            return services;
        }
    }
}