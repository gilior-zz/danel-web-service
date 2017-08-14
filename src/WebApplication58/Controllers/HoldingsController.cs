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
    [Route("api/holdings")]
    public class HoldingsController : Controller
    {
        private IHodldingsRepository hodldingsRepository;


        public HoldingsController(IHodldingsRepository HodldingsRepository)
        {
            this.hodldingsRepository = HodldingsRepository;
        }       

        //api/holdings/accountHodlingsB?dateFrom=12-12-2012&dateTo=12-12-2012&entities=3,4&entitiesType=2&groupID=1
        [HttpGet("accountHodlingsB")]
        public IActionResult GetAccountHodlingsB(HoldingsParams holdingsParams)
        {
            Hepler.GenerateModelState(holdingsParams.dateFrom, holdingsParams.dateTo, holdingsParams.entities, holdingsParams.entitiesType, holdingsParams.groupID, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(holdingsParams.dateFrom, holdingsParams.dateTo, holdingsParams.entities, holdingsParams.entitiesType, holdingsParams.groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }



        // api/holdings/accountHodlings/12-12-2012/12-12-2012/4,3/3/4
        [HttpGet("accountHodlings/{dateFrom}/{dateTo}/{entities}/{entitiesType}/{groupID}")]
        public IActionResult LoadAccountHodlings(HoldingsParams holdingsParams)
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
