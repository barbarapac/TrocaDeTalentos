namespace Utfpr.Troca.De.Talentos.Domain.Abstractions
{
    public interface ISimpleId<T>
    {
        T Id { get; set; }
    }
}