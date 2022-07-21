using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Domain.Model;

namespace Cat.Domain.Services
{
    public interface ICatService
    {
        Task<DomainCat> RetrieveByName(string bumble);
        Task<List<DomainCat>> RetrieveByClassification(Classification toString);
        Task<List<DomainCat>> RetrieveAll();
    }
}