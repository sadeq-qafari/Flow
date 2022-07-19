using Core.Meteor;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuByIds : DbQueryByIds<Menu>
    {
        public GetMenuByIds() : base("[Core].[Menu]")
        {
        }
    }
}
