using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Domain.Model;
using Cat.Domain.Port;

namespace Cat.Domain.Services
{
    public class CatService : ICatService
    {
        private readonly ICatAdapter _adapter;

        public CatService(ICatAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task<DomainCat> RetrieveByName(string name)
        {
            return await _adapter.RetrieveByName(name);
        }

        public async Task<List<DomainCat>> RetrieveByClassification(Classification classification)
        {
            return await _adapter.RetrieveByClassification(classification);
        }

        public async Task<List<DomainCat>> RetrieveAll()
        {
            return await _adapter.RetrieveAll();
        }
    }
}