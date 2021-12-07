namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class Pessoa : SimpleId<long>
    {
        
        private long _usuarioId;
        
        // [DataMember]
        public Usuario Usuario { get; private set; }
        
        // [DataMember]
        // [Required(ErrorMessage = "Senha é obrigatório")]
        public string Curso { get; private set; }
        
        // [DataMember]
        // [Required(ErrorMessage = "Campus é obrigatório")]
        public string Campus { get; private set; }
        
        // [DataMember]
        // [Required(ErrorMessage = "Cidade é obrigatória")]
        public string Cidade { get; private set; }
        
        // [DataMember]
        // [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; private set; }
    }
}