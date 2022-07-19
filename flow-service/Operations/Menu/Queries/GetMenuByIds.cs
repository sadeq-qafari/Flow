using Core.Meteor;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuByIds : DbQueryByIds<Menu>
    {
        public GetMenuByIds() : base("[Flow].[Menu]")
        {
        }
    }
}
