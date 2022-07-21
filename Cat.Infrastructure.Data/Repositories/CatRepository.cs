using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Data.Models;

namespace Cat.Data.Repositories
{
    public class CatRepository : ICatRepository
    {
        public async Task<CatData> RetrieveByName(string name)
        {
            return new CatData(name, 4, ClassificationData.Tabby);
        }

        public async Task<List<CatData>> RetrieveByClassification(ClassificationData classification)
        {
            return new List<CatData>
            {
                new CatData("Bumble", 4, classification),
                new CatData("Bramble", 5, classification)
            };
        }

        public async Task<List<CatData>> RetrieveAll()
        {
            return new List<CatData>
            {
                new CatData("Bumble", 4, ClassificationData.Tabby),
                new CatData("Kit", 3, ClassificationData.BlackAndWhite),
                new CatData("Sky", 8, ClassificationData.Tortoiseshell)
            };
        }
    }
}