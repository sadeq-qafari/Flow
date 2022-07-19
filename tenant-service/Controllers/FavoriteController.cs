using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.Favorite;
using Tenant.Operations.Favorite.Commands;
using Tenant.Operations.Favorite.Dtos;
using Tenant.Operations.Favorite.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class FavoriteController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FavoriteController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Favorite.Read")]
        [HttpGet]
        public Task<QueryPage<FavoriteDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetFavoritePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetFavoriteAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Favorite.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Favorite>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetFavoriteByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Favorite.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFavoriteExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Favorite.xlsx");


        [NeedPermission("Tenant.Favorite.Read")]
        [HttpGet("{id}")]
        public Task<Favorite?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetFavorite>().ExecuteAsync(m);

        [NeedPermission("Tenant.Favorite.Create")]
        [HttpPost]
        public Task<long> Add(FavoriteAddInDto m) =>
            _operationFactory.New<FavoriteAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Favorite.Update")]
        [HttpPut]
        public Task<bool> Update(FavoriteUpdateInDto m) =>
            _operationFactory.New<FavoriteUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Favorite.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<FavoriteRemove>().ExecuteAsync(m);

        // ========== Custom Actions

        [NeedPermission]
        [HttpPost("toggle")]
        public Task<bool> Toggle([FromBody] FavoriteToggleInDto m) =>
            _operationFactory.New<FavoriteToggle>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("check")]
        public Task<bool> Check([FromQuery] FavoriteCheckInDto m) =>
            _operationFactory.New<CheckFavoriteStatus>().ExecuteAsync(m);
    }
}
