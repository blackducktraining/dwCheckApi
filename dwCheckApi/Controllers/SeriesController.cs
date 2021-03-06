using Microsoft.AspNetCore.Mvc;
using System.Linq;
using dwCheckApi.DAL;
using dwCheckApi.DTO.Helpers;

namespace dwCheckApi.Controllers
{
    [Route("/[controller]")]
    public class SeriesController : BaseController
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        [HttpGet]
        public string Get()
        {
            return IncorrectUseOfApi();
        }

        // GET/5
        [HttpGet("Get/{id}")]
        public JsonResult GetById(int id)
        {
            var dbSeries = _seriesService.GetById(id);
            if (dbSeries == null)
            {
                return ErrorResponse("Not found");
            }
            
            return SingleResult(SeriesViewModelHelpers.ConvertToViewModel(dbSeries));
        }

        [HttpGet("GetByName")]
        public JsonResult GetByName(string seriesName)
        {
            if (string.IsNullOrWhiteSpace(seriesName))
            {
                return ErrorResponse("Series name is required");
            }

            var series = _seriesService.GetByName(seriesName);

            if (series == null)
            {
                return ErrorResponse("No Series found");
            }

            return SingleResult(SeriesViewModelHelpers.ConvertToViewModel(series));
        }

        [HttpGet("Search")]
        public JsonResult Search(string searchString)
        {
            var series = _seriesService
                .Search(searchString);

            if (!series.Any())
            {
                return ErrorResponse("Not Found");
            }
                            
            return MultipleResults(SeriesViewModelHelpers.ConvertToViewModels(series.ToList()));
        }
    }
}
