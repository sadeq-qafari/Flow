using Core.Meteor;
using Core.Operations.Version.Dto;

namespace Core.Operations.Version.Commands
{
    public class AddVersion : DbInsertAsync<AddVersionInDto>
    {
        public AddVersion() : base("[Core].[Version]",
            "[ReleaseDate], [Description], [Title], [ApplicationId], [ServiceId], [IsAndroid], [IsIos], [IsPwa], [IsWeb], [IsPanel]",
            "@ReleaseDate, @Description, @Title, @ApplicationId, @ServiceId, @IsAndroid, @IsIos, @IsPwa, @IsWeb, @IsPanel")
        {
        }
    }
}

