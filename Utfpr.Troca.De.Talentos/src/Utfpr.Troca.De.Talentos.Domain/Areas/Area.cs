namespace Utfpr.Troca.De.Talentos.Domain.Areas
{
    public class Area : SimpleId<long>
    {
        // [DataMember]
        // [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; private set; }   
    }
}