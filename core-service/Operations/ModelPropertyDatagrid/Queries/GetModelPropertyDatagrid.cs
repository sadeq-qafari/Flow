using Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagrid : DbSelectAsync<ModelPropertyDatagrid?>
    {
        public GetModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
    }
}
