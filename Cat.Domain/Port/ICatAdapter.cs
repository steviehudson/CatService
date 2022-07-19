using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Domain.Model;

namespace Cat.Domain.Port
{
    public interface ICatAdapter
    {
        Task<DomainCat> RetrieveByName(string name);
        Task<List<DomainCat>> RetrieveByClassification(Classification classification);
        Task<List<DomainCat>> RetrieveAll();
    }
}