using Core.Meteor;
using Tenant.Operations.Setting.Dto;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingPage : DbQueryPage<SettingDto>
    {
        public GetSettingPage() : base("[Tenant].[Setting]")
        {
        }
        
    }
}