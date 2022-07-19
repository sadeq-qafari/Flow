using Core.Meteor;
using Core.Operations.Service.Dto;

namespace Core.Operations.Service.Commands
{
    public class UpdateService : DbUpdateAsync<UpdateServiceInDto>
    {
        public UpdateService() : base("[Core].[Service]",
            "[Name]=@Name, [Title]=@Title")
        {
        }
    }
}
