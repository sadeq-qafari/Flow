using Core.Meteor;
using Tenant.Operations.Setting.Dto;

namespace Tenant.Operations.Setting.Commands
{
    public class AddSetting : DbInsertAsync<AddSettingInDto>
    {
        public AddSetting() : base("[Tenant].[Setting]",
            "[Title], [ServiceName], [Name], [TypeLookup], [Value], [Options], [RecommendedValue]",
            "@Title, @ServiceName, @Name, @TypeLookup, @Value, @Options, @RecommendedValue")
        {
        }
    }
}

