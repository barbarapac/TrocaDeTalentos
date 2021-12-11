using System.Runtime.Serialization;
using Utfpr.Troca.De.Talentos.Domain.Abstractions;

namespace Utfpr.Troca.De.Talentos.Domain
{
    [DataContract]
    public class SimpleId<T> : ISimpleId<T>
    {
        [DataMember]
        public T Id { get; set; }
    }
}