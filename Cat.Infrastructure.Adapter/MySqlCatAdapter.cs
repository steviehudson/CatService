using Cat.Data.Models;
using Cat.Data.Repositories;
using Cat.Domain.Model;
using Cat.Domain.Port;

namespace Cat.Infrastructure.Adapter;

public class MySqlCatAdapter : ICatAdapter
{
    private readonly ICatRepository _repository;

    public MySqlCatAdapter(ICatRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<DomainCat> RetrieveByName(string name)
    {
        var catData = await _repository.RetrieveByName(name);
        return ToDomain(catData);
    }

    public async Task<List<DomainCat>> RetrieveByClassification(Classification classification)
    {
        var catData = await _repository.RetrieveByClassification(MapClassification(classification));
        return ToDomain(catData);
    }

    public async Task<List<DomainCat>> RetrieveAll()
    {
        var catData = await _repository.RetrieveAll();
        return ToDomain(catData);
    }
    
    private List<DomainCat> ToDomain(List<CatData> data)
    {
        return data.Select(ToDomain).ToList();
    }

    private DomainCat ToDomain(CatData data)
    {
        return new DomainCat(data.Name, data.Age, MapClassification(data.Classification));
    }

    private Classification MapClassification(ClassificationData catDataClassification)
    {
        switch (catDataClassification)
        {
            case ClassificationData.Tabby:
                return Classification.Tabby;
            case ClassificationData.Tortoiseshell:
                return Classification.Tortoiseshell;
            case ClassificationData.BlackAndWhite:
            default:
                return Classification.BlackAndWhite;
        }
    }
    
    private ClassificationData MapClassification(Classification catDataClassification)
    {
        switch (catDataClassification)
        {
            case Classification.Tabby:
                return ClassificationData.Tabby;
            case Classification.Tortoiseshell:
                return ClassificationData.Tortoiseshell;
            case Classification.BlackAndWhite:
            default:
                return ClassificationData.BlackAndWhite;
        }
    }
}