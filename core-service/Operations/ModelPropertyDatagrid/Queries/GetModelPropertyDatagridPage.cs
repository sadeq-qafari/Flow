using Core.Operations.ModelPropertyDatagrid.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridPage : SaanaaDbQueryPage<ModelPropertyDatagridDto>
    {
        public GetModelPropertyDatagridPage() : base("[Core].[ModelPropertyDatagrid]")
        {
        }

    }
}
