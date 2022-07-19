using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Version.Dto;
using Meteor.Operation;

namespace Core.Operations.Version.Queries
{
    public class GetVersionExcel : DbQueryExcel<VersionDto>
    {
        public GetVersionExcel() : base("[Core].[Version]")
        {
        }
        
        protected override async Task<List<VersionDto>?> GetItems() =>
            (await OperationFactory!.New<GetVersionPage>().ExecuteAsync(Input))?.Items;
    }
}