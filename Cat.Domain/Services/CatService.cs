using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Data.Models;
using Cat.Data.Repositories;

namespace Cat.Domain.Services
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;

        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<CatData> RetrieveByName(string name)
        {
            return await _catRepository.RetrieveByName(name);
        }

        public async Task<List<CatData>> RetrieveByClassification(Classification classification)
        {
            return await _catRepository.RetrieveByClassification(classification);
        }

        public async Task<List<CatData>> RetrieveAll()
        {
            return await _catRepository.RetrieveAll();
        }
    }
}