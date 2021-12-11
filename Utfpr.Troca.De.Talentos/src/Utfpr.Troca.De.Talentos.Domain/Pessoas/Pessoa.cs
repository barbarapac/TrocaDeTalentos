using System;
using System.Net.Mail;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class Pessoa : SimpleId<long>
    {
        private long _usuarioId;
        
        public string Nome { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Curso { get; private set; }
        public string Campus { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public DateTime DataCadastro { get; set; }
    }
}