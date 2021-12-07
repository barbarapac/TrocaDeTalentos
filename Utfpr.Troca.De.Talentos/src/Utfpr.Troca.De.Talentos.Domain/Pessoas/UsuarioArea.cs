using System.Collections.Generic;
using Utfpr.Troca.De.Talentos.Domain.Areas;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas
{
    public class UsuarioArea : SimpleId<long>
    {
        private readonly IList<Area> _areas = new List<Area>();
        public IReadOnlyCollection<Area> Areas { get; private set; }
        public Usuario Usuario  { get; private set; }
    }
}