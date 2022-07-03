using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Data.Models;

namespace Cat.Data.Repositories
{
    public interface ICatRepository
    {
        Task<CatData> RetrieveByName(string name);
        Task<List<CatData>> RetrieveByClassification(Classification classification);
        Task<List<CatData>> RetrieveAll();
    }
}