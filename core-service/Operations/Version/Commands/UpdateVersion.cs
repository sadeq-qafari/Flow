using Core.Meteor;
using Core.Operations.Version.Dto;

namespace Core.Operations.Version.Commands
{
    public class UpdateVersion : DbUpdateAsync<UpdateVersionInDto>
    {
        public UpdateVersion() : base("[Core].[Version]",
            "[ReleaseDate]=@ReleaseDate, [Description]=@Description, [Title]=@Title, [ApplicationId]=@ApplicationId, [ServiceId]=@ServiceId, [IsAndroid]=@IsAndroid, [IsIos]=@IsIos, [IsPwa]=@IsPwa, [IsWeb]=@IsWeb, [IsPanel]=@IsPanel")
        {
        }
    }
}
