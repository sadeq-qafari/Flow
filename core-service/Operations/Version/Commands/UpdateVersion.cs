using Core.Operations.Version.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Commands
{
    public class UpdateVersion : SaanaaDbUpdateAsync<UpdateVersionInDto>
    {
        public UpdateVersion() : base("[Core].[Version]",
            "[ReleaseDate]=@ReleaseDate, [Description]=@Description, [Title]=@Title, [ApplicationId]=@ApplicationId, [ServiceId]=@ServiceId, [IsAndroid]=@IsAndroid, [IsIos]=@IsIos, [IsPwa]=@IsPwa, [IsWeb]=@IsWeb, [IsPanel]=@IsPanel")
        {
        }
    }
}
