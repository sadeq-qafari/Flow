using Core.Operations.ReportDbServer.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Commands
{
    public class ReportDbServerAdd : SaanaaDbInsertAsync<ReportDbServerAddInDto>
    {
        public ReportDbServerAdd() : base("[Core].[ReportDbServer]",
            @"[Title],
						[ConnectionString],
						[EngineTypeLookup]",
            @"@Title,
						@ConnectionString,
						@EngineTypeLookup")
        {
        }
    }
}

