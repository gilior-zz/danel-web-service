using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication58.Dto;
using WebApplication58.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication58.Helpers;

namespace WebApplication58.Controllers
{
    [Route("api/data/{entities}/{entitiesType}/{dateFrom}/{dateTo}")]
    public class DataController : Controller
    {
        private IHodldingsRepository hodldingsRepository;

        public DataController(IHodldingsRepository HodldingsRepository)
        {
            this.hodldingsRepository = HodldingsRepository;
        }


        // api/data/12,13/3/12-12-2012/12-12-2014/accountGroupedHoldings/1
        [HttpGet("accountGroupedHoldings/{groupID}")]
        public IActionResult GetGroupedHodlings(DateTime? dateFrom = null,
                                                 DateTime? dateTo = null,
                                              string entities = "",
                                              Int16 entitiesType = 0,
                                             Int16 groupID = 0)
        {
            Hepler.GenerateModelState(dateFrom, dateTo, entities, groupID, entitiesType, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(dateFrom.Value, dateTo.Value, entities, entitiesType, groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }


        // api/data/12,13/3/12-12-2012/12-12-2014/accountFlatHoldings
        [HttpGet("accountFlatHoldings")]
        public IActionResult GetFlatHodlings(DateTime? dateFrom = null,
                                             DateTime? dateTo = null,
                                             string entities = "",
                                              Int16 entitiesType = 0
                                            )
        {
            Hepler.GenerateModelState(dateFrom, dateTo, entities, entitiesType, 1, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(dateFrom.Value, dateTo.Value, entities, entitiesType, 1);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }










    }
}
