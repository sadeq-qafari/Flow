using Core.Meteor;
using Core.Operations.ModelPropertyDatagrid.Dto;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridPage : DbQueryPage<ModelPropertyDatagridDto>
    {
        public GetModelPropertyDatagridPage() : base("[Core].[ModelPropertyDatagrid]")
        {
        }

    }
}
