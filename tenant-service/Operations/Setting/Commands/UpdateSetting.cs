using Saanaa.Core.Meteor;
using Tenant.Operations.Setting.Dto;

namespace Tenant.Operations.Setting.Commands
{
    public class UpdateSetting : SaanaaDbUpdateAsync<UpdateSettingInDto>
    {
        public UpdateSetting() : base("[Tenant].[Setting]",
            "[Title]=@Title, [ServiceName]=@ServiceName, [Name]=@Name, [TypeLookup]=@TypeLookup, [Value]=@Value, [Options]=@Options, [RecommendedValue]=@RecommendedValue")
        {
        }
    }
}