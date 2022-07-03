using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Data.Models;
using Cat.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cat.API.Controllers
{
    public class CatController : Controller
    {
        private readonly ICatService _catService;

        public CatController(ICatService catService)
        {
            _catService = catService;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("cat/{name:string}")]
        public async Task<CatData> RetrieveCatByName(string name)
        {
            return await _catService.RetrieveByName(name);
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("cats/{classification:string}")]
        public async Task<List<CatData>> RetrieveCatsByClassification(string classification)
        {
            var classificationParsed = (Classification)Enum.Parse(typeof(Classification), classification);
            return await _catService.RetrieveByClassification(classificationParsed);
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("cats")]
        public async Task<List<CatData>> RetrieveAllCats()
        {
            return await _catService.RetrieveAll();
        }
    }
}