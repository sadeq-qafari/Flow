using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Operations.ModelPropertyLookup.Dto;
using Meteor.Operation;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupList : OperationAsync<GetModelPropertyLookupListInDto, IEnumerable<DropDownDto<object>>>
    {
        protected override Task ExecutionAsync()
        {
            var mp = SaanaaServices.GetModelProperty(Input.Service, Input.Model, Input.Property);
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
