using Core.Operations.Version.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Commands
{
    public class AddVersion : SaanaaDbInsertAsync<AddVersionInDto>
    {
        public AddVersion() : base("[Core].[Version]",
            "[ReleaseDate], [Description], [Title], [ApplicationId], [ServiceId], [IsAndroid], [IsIos], [IsPwa], [IsWeb], [IsPanel]",
            "@ReleaseDate, @Description, @Title, @ApplicationId, @ServiceId, @IsAndroid, @IsIos, @IsPwa, @IsWeb, @IsPanel")
        {
        }
    }
}

