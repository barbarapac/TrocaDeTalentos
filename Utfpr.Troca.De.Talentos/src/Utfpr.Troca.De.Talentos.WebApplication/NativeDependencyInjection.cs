using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Commands;
using Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Commands.Handlers;
using Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Profiles;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands.Handlers;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Profiles;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Interfaces;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces;
using Utfpr.Troca.De.Talentos.Infrastructure.Repositories;
using Utfpr.Troca.De.Talentos.QueryStack.Areas;
using Utfpr.Troca.De.Talentos.QueryStack.Areas.Imp;
using Utfpr.Troca.De.Talentos.QueryStack.Pessoa;
using Utfpr.Troca.De.Talentos.QueryStack.Pessoa.Imp;
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
                .RegistraTodasAsQueries()
                .AddAutoMapper(typeof(UsuarioDtoToUsuarioProfile), typeof(PessoaDtoToPessoaProfile))
                .AddMediatR(typeof(UsuarioCommandHandler).Assembly, typeof(PessoaCommandHandler).Assembly);
            return services;
        }
        
        private static IServiceCollection RegistraTodosCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CriarUsuarioCommand, UsuarioDto>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<CriarPessoaCommand, PessoaDto>, PessoaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPessoaCommand, PessoaDto>, PessoaCommandHandler>();
            return services;
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
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            return services;
        }
        
        private static IServiceCollection RegistraTodasAsQueries(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioQuerie, UsuarioQuerie>();
            services.AddScoped<IAreaQuerie, AreaQuerie>();
            services.AddScoped<IPessoaQuerie, PessoaQuerie>();
            return services;
        }
    }
}