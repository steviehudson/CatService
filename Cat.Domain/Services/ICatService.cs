using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Data.Models;

namespace Cat.Domain.Services
{
    public interface ICatService
    {
        Task<CatData> RetrieveByName(string bumble);
        Task<List<CatData>> RetrieveByClassification(Classification toString);
        Task<List<CatData>> RetrieveAll();
    }
}