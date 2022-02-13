using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Services.Statistics;

namespace VillaBNB.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statistics;

        public StatisticsApiController(IStatisticsService statistics)
            => this.statistics = statistics;

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
            => this.statistics.Total();
    }
}
