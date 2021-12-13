using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using FluentValidation.Results;
using Utfpr.Troca.De.Talentos.Domain.Abstractions;

namespace Utfpr.Troca.De.Talentos.Domain
{
    [DataContract]
    public class SimpleId<T> : ISimpleId<T>
    {
        [DataMember]
        public T Id { get; set; }
        
        [NotMapped]
        public ValidationResult ValidationResult  { get; internal set; }
        [NotMapped]
        public bool IsValid => this.ValidationResult.IsValid;
    }
}