using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Meteor.Dto;
using Core.Operations.ModelPropertyLookup.Dto;
using Meteor.Operation;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupList : OperationAsync<GetModelPropertyLookupListInDto, IEnumerable<DropDownDto<object>>>
    {
        protected override Task ExecutionAsync()
        {
            var mp = SqServices.GetModelProperty(Input.Service, Input.Model, Input.Property);
            if (mp != null)
            {
                Output = mp.LookupOptions.Select(x => new DropDownDto<object>()
                {
                    Label = new Dictionary<string, object?>()
                    {
                        {"title", x.Title}
                    },
                    Value = x.Value
                });
            }

            return Task.CompletedTask;
        }
    }
}
