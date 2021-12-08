using Utfpr.Troca.De.Talentos.Domain.Pessoas;

namespace Utfpr.Troca.De.Talentos.Domain.Areas
{
    public class Area : SimpleId<long>
    {
        private long _areaId;
        public string Descricao { get; private set; }
    }
}