using System.Collections.Generic;
using System.Threading.Tasks;
using Utfpr.Troca.De.Talentos.Domain.Areas.Dtos;

namespace Utfpr.Troca.De.Talentos.QueryStack.Areas
{
    public interface IAreaQuerie
    {
        Task<IList<AreaDto>> ObterTodasAsAreasAsync();
    }
}