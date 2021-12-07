namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class Usuario : SimpleId<long>
    {
        // [DataMember]
        // [Required(ErrorMessage = "RA é obrigatório")]
        public string Ra { get; private set; }
        
        // [DataMember]
        // [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; private set; }
        
        // [DataMember]
        // [Required(ErrorMessage = "Senha é obrigatória")]
        public string Senha { get; private set; }
    }
}