using Core.Operations.Service.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Commands
{
    public class UpdateService : SaanaaDbUpdateAsync<UpdateServiceInDto>
    {
        public UpdateService() : base("[Core].[Service]",
            "[Name]=@Name, [Title]=@Title")
        {
        }
    }
}
