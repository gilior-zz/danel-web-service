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
        public IActionResult GetGroupedHodlings(HoldingsParams holdingsParams)
        {
            Hepler.GenerateModelState(holdingsParams.dateFrom, holdingsParams.dateTo, holdingsParams.entities, holdingsParams.entitiesType, holdingsParams.groupID, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(holdingsParams.dateFrom, holdingsParams.dateTo, holdingsParams.entities, holdingsParams.entitiesType, holdingsParams.groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }


        // api/data/12,13/3/12-12-2012/12-12-2014/accountFlatHoldings
        [HttpGet("accountFlatHoldings")]
        public IActionResult GetFlatHodlings(HoldingsParams holdingsParams)
        {
            Hepler.GenerateModelState(holdingsParams.dateFrom, holdingsParams.dateTo, holdingsParams.entities, holdingsParams.entitiesType, holdingsParams.groupID, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(holdingsParams.dateFrom, holdingsParams.dateTo, holdingsParams.entities, holdingsParams.entitiesType, holdingsParams.groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }










    }
}
