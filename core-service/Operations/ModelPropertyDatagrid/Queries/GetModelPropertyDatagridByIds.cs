using Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridByIds : DbQueryByIds<ModelPropertyDatagrid>
    {
        public GetModelPropertyDatagridByIds() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
    }
}
